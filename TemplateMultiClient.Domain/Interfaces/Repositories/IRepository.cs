using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TemplateMultiClient.Domain.Entities;

namespace TemplateMultiClient.Domain.Interfaces.Repositories
{
    public interface IRepository<TEntity>
    where TEntity : Entity
    {
        void Remove(Guid id);
        void Remove(TEntity entidade);
        void Update(TEntity entidade);
        void Add(TEntity entidade);
        Task<TEntity> GetByIdAsync(Guid id);
        Task<TEntity> GetByIdAsync(string id);
        IQueryable<TEntity> GetByIdAsQueryable(string id);
        IQueryable<TEntity> GetByIdAsQueryable(Guid id);
        Task<IList<TEntity>> GetAllAsync();
        IQueryable<TEntity> AsQueryable();
        void AddRange(IList<TEntity> entidades);
        void SetModifiedState(TEntity entidade);
    } 
}