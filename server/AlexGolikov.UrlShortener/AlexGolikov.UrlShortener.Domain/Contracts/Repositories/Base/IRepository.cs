using System;
using System.Linq;
using System.Linq.Expressions;

namespace AlexGolikov.UrlShortener.Domain.Contracts.Repositories.Base
{
    public interface IRepository { }

    public interface IRepository<TEntity> : IRepository
    {
        TEntity Get(Guid id);
        IQueryable<TEntity> Get(bool tracking = false);
        IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> expression, bool tracking = false);
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}
