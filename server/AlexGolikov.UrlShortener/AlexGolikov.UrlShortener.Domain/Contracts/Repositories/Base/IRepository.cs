using System;
using System.Linq;
using System.Linq.Expressions;

namespace AlexGolikov.UrlShortener.Domain.Contracts.Repositories.Base
{
    /// <summary>
    /// Base repository interface
    /// </summary>
    public interface IRepository { }

    /// <summary>
    /// Base repository interface with entity type
    /// </summary>
    /// <typeparam name="TEntity">Entity</typeparam>
    public interface IRepository<TEntity> : IRepository
    {
        /// <summary>
        /// Get entity by id
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns>Entity</returns>
        TEntity Get(Guid id);

        /// <summary>
        /// Get entities
        /// </summary>
        /// <param name="tracking">Track entities or not</param>
        /// <returns>Entities</returns>
        IQueryable<TEntity> Get(bool tracking = false);

        /// <summary>
        /// Get entities by expression
        /// </summary>
        /// <param name="expression">Expression</param>
        /// <param name="tracking">Track entities or not</param>
        /// <returns>Entities</returns>
        IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> expression, bool tracking = false);

        /// <summary>
        /// Add entity
        /// </summary>
        /// <param name="entity">Entity</param>
        void Add(TEntity entity);

        /// <summary>
        /// Update entity
        /// </summary>
        /// <param name="entity">Entity</param>
        void Update(TEntity entity);

        /// <summary>
        /// Delete entity
        /// </summary>
        /// <param name="entity">Entity</param>
        void Delete(TEntity entity);
    }
}
