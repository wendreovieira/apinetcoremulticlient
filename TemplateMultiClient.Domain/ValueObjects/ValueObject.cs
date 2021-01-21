using Flunt.Notifications;
using Flunt.Validations;
using TemplateMultiClient.Domain.Interfaces.Entities;

namespace TemplateMultiClient.Domain.ValueObjects
{
    public abstract class ValueObject : Notifiable, IContract
    {        
        public abstract Contract GetContract();        
    }
}