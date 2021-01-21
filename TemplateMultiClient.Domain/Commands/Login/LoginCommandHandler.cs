using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TemplateMultiClient.Domain.Commands.Login;
using TemplateMultiClient.Domain.Interfaces.Repositories;
using TemplateMultiClient.Domain.Interfaces.Services;
using TemplateMultiClient.Domain.Queries;
using TemplateMultiClient.Domain.ValueObjects;

namespace TemplateMultiClient.Domain.Commands
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, Response<LoginCommandView>>
    {
        private readonly IUserRepository _repository;
        private readonly ITokenService _tokenService;

        public LoginCommandHandler(IUserRepository repository, ITokenService tokenService)
        {
            _repository = repository;
            _tokenService = tokenService;
        }

        public Task<Response<LoginCommandView>> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            request.Validate();

            if (!request.Invalid)
                return Task.FromResult(new Response<LoginCommandView>(false, request.Notifications, null));
            
            var user = _repository
                .AsQueryable()
                .AsNoTracking()
                .Include(x => x.Client)                
                .FirstOrDefault(LoginQuery.GetByEmailAndPassword(request.Email, new Password(request.Password)));

            if (user == null)
            {
                request.AddNotification("User", Labels.RegisterNotFound());
                return Task.FromResult(new Response<LoginCommandView>(false, request.Notifications, null));
            }

            var token = _tokenService.CreateToken(user.Client, user);

            return Task.FromResult(
                new Response<LoginCommandView>(
                        true,
                        null,
                        new LoginCommandView(token, user.Name, user.Client.Name)
                    )
            ); ;
        }
    }
}