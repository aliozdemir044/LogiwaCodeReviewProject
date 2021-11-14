using Logiwa.Core.Types;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Logiwa.Core.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        /// <summary>
        /// Queryable olarak belirtilen expressiona göre verileri getirir.
        /// </summary>
        /// <param name="where">Expression</param>
        /// <returns>T IQuerayble</returns>
        IQueryable<T> Find(Expression<Func<T, Boolean>> where);

        /// <summary>
        /// Id ile tek bir veri getirir.
        /// </summary>
        /// <param name="id">long</param>
        /// <returns></returns>
        T Get(long id);

        /// <summary>
        /// Queryable olarak entity üzerinde işlem yapılmasını sağlar.
        /// </summary>
        /// <returns></returns>
        IQueryable<T> GetQueryable();

        /// <summary>
        /// Insert işlemleri için kullanılır.
        /// </summary>
        /// <param name="entity">T</param>
        void Insert(T entity);

        /// <summary>
        /// Update için kullanılır.
        /// </summary>
        /// <param name="entity">T</param>
        void Update(T entity);

        /// <summary>
        /// Hard delete yapar.
        /// </summary>
        /// <param name="entity">T</param>
        void Delete(T entity);

    }
}