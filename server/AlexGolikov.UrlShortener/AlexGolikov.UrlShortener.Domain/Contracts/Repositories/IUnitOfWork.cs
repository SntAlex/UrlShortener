using System;
using AlexGolikov.UrlShortener.Domain.Contracts.Repositories.Base;
using AlexGolikov.UrlShortener.Domain.Models.Entities.Base;

namespace AlexGolikov.UrlShortener.Domain.Contracts.Repositories
{
    /// <summary>
    /// Unit of work interface
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Get repository by entity type
        /// </summary>
        /// <typeparam name="TEntity">Entity</typeparam>
        /// <returns>Repository</returns>
        IRepository<TEntity> GetRepository<TEntity>()
            where TEntity : BaseEntity;

        /// <summary>
        /// Save changes in db
        /// </summary>
        void Commit();
    }
}
