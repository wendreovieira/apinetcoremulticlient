using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TemplateMultiClient.Domain.Entities;
using TemplateMultiClient.Domain.Interfaces.Repositories;

namespace TemplateMultiClient.Infra.Repositories
{
    public abstract class Repository<TContext, TEntity> : IRepository<TEntity>
    where TContext : DbContext
    where TEntity : Entity
    {
        private readonly TContext _context;

        public Repository(TContext context)
        {
            _context = context;
        }

        public void Add(TEntity entidade)
        {
            _context.Set<TEntity>().Add(entidade);
        }

        public void AddRange(IList<TEntity> entidades)
        {
            _context.Set<TEntity>().AddRange(entidades);
        }

        public IQueryable<TEntity> AsQueryable()
        {
            return _context.Set<TEntity>().AsQueryable().AsNoTracking();
        }

        public async Task<IList<TEntity>> GetAllAsync()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(Guid id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        public async Task<TEntity> GetByIdAsync(string id)
        {
            return await _context.Set<TEntity>().FindAsync(new Guid(id));
        }

        public IQueryable<TEntity> GetByIdAsQueryable(string id)
        {
            return _context.Set<TEntity>().AsQueryable().Where(x => x.Id == new Guid(id));
        }

        public IQueryable<TEntity> GetByIdAsQueryable(Guid id)
        {
            return _context.Set<TEntity>().AsQueryable().Where(x => x.Id == id);
        }

        public void Remove(TEntity entidade)
        {
            _context.Set<TEntity>().Remove(entidade);
        }

        public void Remove(Guid id)
        {
            var entidade = _context.Set<TEntity>().Find(id);
            _context.Set<TEntity>().Remove(entidade);
        }

        public void SetModifiedState(TEntity entidade)
        {
            _context.Entry(entidade).State = EntityState.Modified;
        }

        public void Update(TEntity entidade)
        {
            var local = _context.Set<TEntity>().Local.Where(x => x.Id == entidade.Id).FirstOrDefault();

            if (local != null)
                _context.Entry(local).State = EntityState.Detached;

            SetModifiedState(entidade);
        }
    }
}