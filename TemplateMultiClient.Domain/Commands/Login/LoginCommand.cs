using Flunt.Notifications;
using MediatR;
using TemplateMultiClient.Domain.Interfaces.Commands;
using TemplateMultiClient.Domain.ValueObjects;

namespace TemplateMultiClient.Domain.Commands.Login
{
    public class LoginCommand : Notifiable, ICommand, IRequest<Response<LoginCommandView>>
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public void Validate()
        {
            AddNotifications(new Email(Email).GetContract());
            AddNotifications(new Password(Password).GetContract());
        }
    }
}