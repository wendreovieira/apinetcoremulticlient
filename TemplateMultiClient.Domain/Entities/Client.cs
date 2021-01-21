namespace TemplateMultiClient.Domain.Entities
{
    public class Client : Entity
    {
        public Client(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }
    }
}