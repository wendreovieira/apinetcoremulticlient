namespace TemplateMultiClient.Domain.Commands.Login
{
    public class LoginCommandView
    {
        public LoginCommandView(string token, string userName, string clientName)
        {
            Token = token;
            UserName = userName;
            ClientName = clientName;
        }

        public string Token { get; set; }
        public string UserName { get; set; }
        public string ClientName { get; set; }
    }
}
