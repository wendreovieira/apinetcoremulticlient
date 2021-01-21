using System.Collections.Generic;
using TemplateMultiClient.Domain.ValueObjects;

namespace TemplateMultiClient.Domain.Entities
{
    public class User : Entity
    {
        public User(Client client, string name, string email, Password password, IReadOnlyList<Permission> permissions, bool isAdmin)
        {
            Client = client;
            Name = name;
            Email = email;
            Password = password;
            Permissions = permissions;
            IsAdmin = isAdmin;
        }

        protected User() {}

        public Client Client { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public Password Password { get; set; }
        public IReadOnlyList<Permission> Permissions { get; set; }
        public bool IsAdmin { get; set; }
    }
}