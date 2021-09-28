using AlexGolikov.UrlShortener.Data.DB;
using AlexGolikov.UrlShortener.Data.Repositories.Base;
using AlexGolikov.UrlShortener.Domain.Contracts.Repositories;
using AlexGolikov.UrlShortener.Domain.Contracts.Repositories.Base;
using AlexGolikov.UrlShortener.Domain.Models.Entities.Base;
using System;
using System.Collections.Generic;

namespace AlexGolikov.UrlShortener.Data.Repositories
{
    /// <summary>
    /// Unit of work
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        private readonly UrlShortenerContext _urlShortenerContext;
        private readonly IDictionary<string, IRepository> _repositories;
        private bool _disposed;

        #region constructor
        public UnitOfWork(UrlShortenerContext urlShortenerContext)
        {
            _urlShortenerContext = urlShortenerContext;
            _repositories = new Dictionary<string, IRepository>();
        }
        #endregion

        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : BaseEntity
        {
            var typeName = typeof(TEntity).FullName;

            if (typeName != null && !_repositories.ContainsKey(typeName))
            {
                _repositories.Add(typeName, new Repository<TEntity>(_urlShortenerContext));
            }

            return (IRepository<TEntity>)_repositories[typeName ?? throw new InvalidOperationException("Entity type is null")];
        }

        public void Commit()
        {
            _urlShortenerContext.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _urlShortenerContext.Dispose();
                }
            }
            _disposed = true;
        }
    }
}
