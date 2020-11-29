using Depot.Business.Interfaces;
using Depot.Business.Models;
using Depot.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Depot.Data.Repository
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        protected readonly DepotContext Db;
        protected readonly DbSet<TEntity> DbSet;

        public Repository(DepotContext db)
        {
            Db = db;
            DbSet = db.Set<TEntity>();
        }

        public IQueryable<TEntity> Buscar(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.AsNoTracking().Where(predicate);
        }

        public virtual async Task<TEntity> ObterPorId(int id)
        {
            return await DbSet.FindAsync(id);
        }

        public virtual async Task<List<TEntity>> ObterTodos()
        {
            return await DbSet.ToListAsync();
        }

        public virtual async Task Adicionar(TEntity entity)
        {
            DbSet.Add(entity);
            await SaveChanges();
        }

        public virtual async Task Atualizar(TEntity entity)
        {
            
            DbSet.Update(entity);
            await SaveChanges();
        }

        public async Task Remover(int id)
        {
            var entity = await ObterPorId(id);
            if (entity != null)
            {
                DbSet.Remove(entity);
                await SaveChanges();
            }
        }

        public async Task<int> SaveChanges()
        {
            return await Db.SaveChangesAsync();
        }


        public void Dispose()
        {
           Db?.Dispose();                  
        }
           
    }
}
