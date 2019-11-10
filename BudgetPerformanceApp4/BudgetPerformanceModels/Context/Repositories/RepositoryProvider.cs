using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BudgetPerformanceApp4.BudgetPerformanceModels.Context.Repositories
{
    public class RepositoryProvider
    {
        public BPAContext DbContext { get; set; }
        private readonly RepositoryFactories _repositoryFactories;
        protected Dictionary<Type, object> Repositories { get; private set; }

        public RepositoryProvider(RepositoryFactories repositoryFactories)
        {
            _repositoryFactories = repositoryFactories;
            Repositories = new Dictionary<Type, object>();
        }

        public Repository<T> GetRepositoryForEntityType<T>() where T : class
        {
            return GetRepository<Repository<T>>(_repositoryFactories.GetRepositoryFactoryForEntityType<T>());
        }

        public virtual T GetRepository<T>(Func<BPAContext, object> factory = null)
        {
            // look for T dictionary cache under typeof(T).
            object repoObj;
            Repositories.TryGetValue(typeof(T), out repoObj);
            if (repoObj != null)
            {
                return (T)repoObj;
            }
            // Not found or null; make one, add to dictionary cache, and return it.
            return MakeRepository<T>(factory, DbContext);
        }

        public virtual T MakeRepository<T>(Func<BPAContext, object> factory, BPAContext dbContext)
        {
            var f = factory ?? _repositoryFactories.GetRepositoryFactory<T>();
            if (f == null)
            {
                throw new NotImplementedException($"No factory for repository type, {typeof(T)}");
            }

            var repo = (T)f(dbContext);
            Repositories[typeof(T)] = repo;
            return repo;
        }

        public void SetRepository<T>(T repository)
        {
            Repositories[typeof(T)] = repository;
        }
    }
}