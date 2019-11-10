using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BudgetPerformanceApp4.BudgetPerformanceModels.Context.Repositories
{
    public class BPARepo : IDisposable
    {
        public BPAContext DbContext { get; set; }
        private RepositoryProvider RepositoryProvider { get; set; }

        public Repository<Activities> Activities => GetStandardRepo<Activities>();
        public Repository<Budget> Budget => GetStandardRepo<Budget>();
        public Repository<BudgetPeriod> BudgetPeriod => GetStandardRepo<BudgetPeriod>();
        public Repository<Department> Department => GetStandardRepo<Department>();
        public Repository<Employee> Employee => GetStandardRepo<Employee>();
        public Repository<Expense> Expense => GetStandardRepo<Expense>();
        public Repository<Gender> Gender => GetStandardRepo<Gender>();
        public Repository<Mission> Mission => GetStandardRepo<Mission>();
        public Repository<Program> Program => GetStandardRepo<Program>();

        public BPARepo()
        {
            DbContext = new BPAContext();
            SetContextDefaults();
            CreateRepositories();
        }

        private void CreateRepositories()
        {
            var repositoryFactories = new RepositoryFactories();

            RepositoryProvider = new RepositoryProvider(repositoryFactories)
            {
                DbContext = DbContext
            };
        }

        public void Commit()
        {
            DbContext.SaveChanges();
        }

        private void SetContextDefaults()
        {
            // Do NOT enable proxied entities, else serialization fails
            DbContext.Configuration.ProxyCreationEnabled = false;
            // Load navigation properties explicitly
            DbContext.Configuration.LazyLoadingEnabled = false;
        }

        private Repository<T> GetStandardRepo<T>() where T : class
        {
            return RepositoryProvider.GetRepositoryForEntityType<T>();
        }

        public void Dispose()
        {
            RepositoryProvider = null;
            DbContext.Dispose();
        }
    }
}