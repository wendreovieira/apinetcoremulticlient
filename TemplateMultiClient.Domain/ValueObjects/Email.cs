using Flunt.Validations;

namespace TemplateMultiClient.Domain.ValueObjects
{
    public class Email : ValueObject
    {
        public Email(string value)
        {                        
            Value = value;

            if (!IsValidEmail(Value))
                AddNotification("Email", "Invalid email.");
            
            AddNotifications(GetContract());
        }

        public string Value { get; private set; }

        public override Contract GetContract()
        {
            return new Contract()
                .Requires()
                .IsNotNullOrEmpty(Value, "Email", Labels.RequiredField());
        }

        private bool IsValidEmail(string email)
        {
            try 
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch 
            {
                return false;
            }
        }
    }
}