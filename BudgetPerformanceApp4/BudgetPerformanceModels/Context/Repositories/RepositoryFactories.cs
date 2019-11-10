using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BudgetPerformanceApp4.BudgetPerformanceModels.Context.Repositories
{
    public class RepositoryFactories
    {
        private readonly IDictionary<Type, Func<BPAContext, object>> _repositoryFactories;

        public RepositoryFactories()
        {
            _repositoryFactories = new Dictionary<Type, Func<BPAContext, object>>();
        }

        public RepositoryFactories(IDictionary<Type, Func<BPAContext, object>> factories, int? userId)
        {
            _repositoryFactories = factories;
        }

        public Func<BPAContext, object> GetRepositoryFactory<T>()
        {
            Func<BPAContext, object> factory;
            _repositoryFactories.TryGetValue(typeof(T), out factory);
            return factory;
        }

        public Func<BPAContext, object> GetRepositoryFactoryForEntityType<T>() where T : class
        {
            return GetRepositoryFactory<T>() ?? DefaultEntityRepositoryFactory<T>();
        }

        protected virtual Func<BPAContext, object> DefaultEntityRepositoryFactory<T>() where T : class
        {
            return dbStockDBContext => new Repository<T>(dbStockDBContext);
        }
    }
}