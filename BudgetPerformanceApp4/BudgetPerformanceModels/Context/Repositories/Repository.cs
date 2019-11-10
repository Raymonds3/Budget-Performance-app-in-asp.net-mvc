using BenGribaudoLLC.IEnumerableHelpers.DataReaderAdapter;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Transactions;
using System.Web;

namespace BudgetPerformanceApp4.BudgetPerformanceModels.Context.Repositories
{
    public class Repository<T> where T : class
    {
        private readonly BPAContext _bpaDbContext;
        public DbSet<T> DbSet { get; set; }

        public Repository(BPAContext bpaDbContext)
        {
            _bpaDbContext = bpaDbContext;
            DbSet = _bpaDbContext.Set<T>();
        }

        public T GetById(int id)
        {
            return DbSet.Find(id);
        }

        /// <summary>
        /// Gets by id and throws an exception if not found
        /// </summary>
        public T GetByIdWithException(int id)
        {
            var entity = DbSet.Find(id);
            if (entity == null)
                throw new Exception($"{typeof(T).Name} not found for id {id}");

            return entity;
        }

        public IQueryable<T> GetAll()
        {
            return DbSet;
        }

        public bool Exists(int id)
        {
            return DbSet.Find(id) != null;
        }

        public bool Exists(Expression<Func<T, bool>> predicate)
        {
            return DbSet.Any(predicate);
        }

        public void Create(List<T> entities)
        {
            using (var transaction = new TransactionScope())
            {
                foreach (var entity in entities)
                {
                    var dbEntityEntry = _bpaDbContext.Entry(entity);

                    if (dbEntityEntry.State != EntityState.Detached)
                    {
                        dbEntityEntry.State = EntityState.Added;
                    }
                }
                DbSet.AddRange(entities);

                _bpaDbContext.SaveChanges();
                transaction.Complete();
            }
        }

        public T Create(T entity)
        {
            using (var transaction = new TransactionScope())
            {
                var dbEntityEntry = _bpaDbContext.Entry(entity);

                if (dbEntityEntry.State != EntityState.Detached)
                {
                    dbEntityEntry.State = EntityState.Added;
                }
                else
                {
                    DbSet.Add(entity);
                }
                _bpaDbContext.SaveChanges();
                transaction.Complete();

                return entity;
            }
        }

        public T Update(T entity)
        {
            using (var transaction = new TransactionScope())
            {
                var dbEntityEntry = _bpaDbContext.Entry(entity);

                if (dbEntityEntry.State != EntityState.Detached)
                {
                    DbSet.Attach(entity);
                }

                dbEntityEntry.State = EntityState.Modified;
                var xxx = _bpaDbContext.SaveChanges();
                transaction.Complete();

                return entity;
            }
        }

        public void Update(List<T> entities)
        {
            using (var transaction = new TransactionScope())
            {
                foreach (var entity in entities)
                {
                    var dbEntityEntry = _bpaDbContext.Entry(entity);

                    if (dbEntityEntry.State != EntityState.Detached)
                    {
                        DbSet.Attach(entity);
                    }
                    dbEntityEntry.State = EntityState.Modified;
                }
                _bpaDbContext.SaveChanges();
                transaction.Complete();
            }
        }

        public void Delete(int id)
        {
            using (var transaction = new TransactionScope())
            {
                T entity = GetById(id);
                if (entity == null) return;

                Delete(entity);

                transaction.Complete();
            }
        }

        public void Delete(T entity)
        {
            using (var transaction = new TransactionScope())
            {
                var dbEntityEntry = _bpaDbContext.Entry(entity);

                if (dbEntityEntry.State != EntityState.Deleted)
                {
                    dbEntityEntry.State = EntityState.Deleted;
                }
                else
                {
                    DbSet.Attach(entity);
                    DbSet.Remove(entity);
                }

                _bpaDbContext.SaveChanges();
                transaction.Complete();
            }
        }

        public void Delete(List<T> entities)
        {
            using (var transaction = new TransactionScope())
            {
                foreach (var entity in entities)
                {
                    var dbEntityEntry = _bpaDbContext.Entry(entity);

                    if (dbEntityEntry.State != EntityState.Deleted)
                    {
                        dbEntityEntry.State = EntityState.Deleted;
                    }
                    else
                    {
                        DbSet.Attach(entity);
                        DbSet.Remove(entity);
                    }
                }

                _bpaDbContext.SaveChanges();
                transaction.Complete();
            }
        }

        public void BulkInsert(List<T> entities)
        {
            Type classType = typeof(T);
            var tableName = classType.Name.ToString();
            string cs = ConfigurationManager.ConnectionStrings["BPAContext"].ConnectionString;
            using (SqlConnection sqlConn = new SqlConnection(cs))
            {
                var xxx = sqlConn.ConnectionTimeout;
                sqlConn.Open();

                using (SqlBulkCopy bulkCopy = new SqlBulkCopy(cs, SqlBulkCopyOptions.KeepIdentity) { BulkCopyTimeout = xxx })
                {
                    bulkCopy.DestinationTableName = tableName;
                    var asDataReaderOfObjects = entities.AsDataReaderOfObjects();
                    bulkCopy.WriteToServer(asDataReaderOfObjects);
                }
                sqlConn.Close();
            }
        }
    }
}