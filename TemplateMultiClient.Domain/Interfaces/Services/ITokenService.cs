using TemplateMultiClient.Domain.Entities;

namespace TemplateMultiClient.Domain.Interfaces.Services
{
    public interface ITokenService
    {
         string CreateToken(Client client, User user);
    }
}