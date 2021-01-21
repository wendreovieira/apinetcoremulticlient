using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TemplateMultiClient.Domain.Interfaces.Repositories
{
    public interface IUnitOfWork<TContext>
    where TContext : DbContext
    {
        Task BeginTransaction();
        Task CommitTransaction();
        Task RollbackTransaction();
    }
}