using Flunt.Notifications;
using System.Collections.Generic;

namespace TemplateMultiClient.Domain.Commands
{
    public class Response<TEntity>
    {
        public Response() { }
        
        public Response(bool success, IReadOnlyCollection<Notification> errors, TEntity result)
        {
            Success = success;
            Errors = errors;
            Result = result;
        }

        public bool Success { get; set; }
        public IReadOnlyCollection<Notification> Errors { get; set; }
        public TEntity Result { get; set; }
    }
}
