using AlexGolikov.UrlShortener.Data.DB;
using AlexGolikov.UrlShortener.Domain.Contracts.Repositories.Base;
using AlexGolikov.UrlShortener.Domain.Models.Entities.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace AlexGolikov.UrlShortener.Data.Repositories.Base
{
    /// <summary>
    /// Base repository
    /// </summary>
    /// <typeparam name="TEntity">Entity type</typeparam>
    public class Repository<TEntity> : IRepository<TEntity>
       where TEntity : BaseEntity
    {
        private readonly UrlShortenerContext _urlShortenerContext;
        private readonly DbSet<TEntity> _entities;

        #region constructor
        public Repository(UrlShortenerContext urlShortenerContext)
        {
            _urlShortenerContext = urlShortenerContext;
            _entities = urlShortenerContext.Set<TEntity>();
        }
        #endregion

        public TEntity Get(Guid id)
        {
            return _entities.Find(id);
        }

        public IQueryable<TEntity> Get(bool tracking = false)
        {
            return tracking ? _entities.AsTracking() : _entities.AsNoTracking();
        }

        public IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> expression, bool tracking = false)
        {
            var entities = Get(tracking);
            return expression != null ? entities.Where(expression) : entities;
        }

        public void Add(TEntity entity)
        {
            _entities.Add(entity);
        }

        public void Update(TEntity entity)
        {
            _urlShortenerContext.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(TEntity entity)
        {
            _entities.Remove(entity);
        }
    }
}
