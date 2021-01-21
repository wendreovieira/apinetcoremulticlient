using System;
using Flunt.Notifications;

namespace TemplateMultiClient.Domain.Entities
{
    public abstract class Entity : Notifiable
    {
        public Guid Id { get; private set; }
    }
}