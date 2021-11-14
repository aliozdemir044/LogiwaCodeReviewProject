using System;

namespace Logiwa.Core.Interfaces
{
    /// <summary>
    /// EF ile ilgili transaction yönetimini sağlar.
    /// Author : Ali Özdemir
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// EF üzerinden açılan transaction commit edilir.
        /// </summary>
        void Commit();
    }
}