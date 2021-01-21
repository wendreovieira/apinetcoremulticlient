using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using TemplateMultiClient.Domain.Interfaces.Repositories;

namespace TemplateMultiClient.Infra.Repositories
{
    public class UnitOfWork<TContext> : IUnitOfWork<TContext>
    where TContext : DbContext
    {
        private readonly TContext _context;
        private IDbContextTransaction _transaction;

        public UnitOfWork(TContext context)
        {
            _context = context;
        }    

        public async Task CommitTransaction()
        {            
            await _transaction.CommitAsync();
            await _context.SaveChangesAsync();
            _transaction = null;
        }

        public async Task BeginTransaction()
        {
            _transaction = await _context.Database.BeginTransactionAsync();
        }

        public async Task RollbackTransaction()
        {
            await _transaction.RollbackAsync();
        }        
    }
}