using Logiwa.Core.Interfaces;
using System;

namespace Logiwa.Entity
{
    /// <summary>
    /// EF ile ilgili transaction yönetimini sağlar.
    /// Author : Ali Özdemir
    /// </summary>
    public class EntityFrameworkUnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext _context;

        public EntityFrameworkUnitOfWork(ApplicationContext context)
        {
            _context = context;
        }

        ~EntityFrameworkUnitOfWork()
        {
            Dispose(false);
        }

        /// <summary>
        /// EF üzerinden açılan transaction commit edilir.
        /// </summary>
        public void Commit()
        {
            _context.SaveChanges();
        }

        /// <summary>
        /// GC Dispose.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Dispose pattern.
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing && _context != null)
            {
                _context.Dispose();
            }
        }
    }
}