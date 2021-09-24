using System;
using AlexGolikov.UrlShortener.Domain.Contracts.Repositories.Base;
using AlexGolikov.UrlShortener.Domain.Models.Entities.Base;

namespace AlexGolikov.UrlShortener.Domain.Contracts.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<TEntity> GetRepository<TEntity>()
            where TEntity : BaseEntity;
        void Commit();
    }
}
