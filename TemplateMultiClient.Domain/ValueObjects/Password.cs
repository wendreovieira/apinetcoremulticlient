using System.Text;
using Flunt.Validations;

namespace TemplateMultiClient.Domain.ValueObjects
{
    public class Password : ValueObject
    {
        private readonly string _password;
        public Password(string password)
        {
            _password = password;
            AddNotifications(GetContract());

            if (!Invalid)
                Value = CreateMD5(password);
        }
        
        public string Value { get; private set; }

        public override Contract GetContract()
        {
            return new Contract()
                .Requires()
                .HasMinLengthIfNotNullOrEmpty(_password, 3, "Password", Labels.FieldHasMinLen(3))
                .HasMaxLengthIfNotNullOrEmpty(_password, 50, "Password", Labels.FieldHasMaxLen(50));
        }

        private string CreateMD5(string input)
        {
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);
                
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }
    }
}