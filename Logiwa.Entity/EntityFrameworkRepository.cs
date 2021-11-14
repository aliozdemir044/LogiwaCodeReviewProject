using Logiwa.Core.Interfaces;
using Logiwa.Core.Types;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;


namespace Logiwa.Entity
{
    public class EntityFrameworkRepository<T> : IRepository<T> where T : BaseEntity
    {
        private DbSet<T> _entities;


        public EntityFrameworkRepository(ApplicationContext context)
        {
            _entities = context.Set<T>();
        }

        /// <summary>
        /// Queryable olarak belirtilen expressiona göre verileri getirir.
        /// </summary>
        /// <param name="where">Expression</param>
        /// <returns>T IQuerayble</returns>
        public IQueryable<T> Find(Expression<Func<T, Boolean>> where)
        {
            return _entities.Where(where);
        }

        public T Get(long id)
        {
            return _entities.SingleOrDefault(s => s.Id == id);
        }

        /// <summary>
        /// Queryable olarak entity üzerinde işlem yapılmasını sağlar.
        /// </summary>
        /// <returns>T IQueryable</returns>
        public virtual IQueryable<T> GetQueryable()
        {
            return _entities.AsNoTracking();
        }

        public void Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            _entities.Add(entity);
        }

        public void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            _entities.Update(entity);
        }

        public void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            _entities.Remove(entity);
        }
    }
}