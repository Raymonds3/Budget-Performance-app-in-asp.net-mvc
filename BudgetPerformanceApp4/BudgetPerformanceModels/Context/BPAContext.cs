using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace BudgetPerformanceApp4.BudgetPerformanceModels.Context
{
    public class BPAContext : DbContext
    {
        public BPAContext() : base("BPAContext")
        {
            //Database.SetInitializer<ExorContext>(null);
        }

        public DbSet<Activities> Activities { get; set; }
        public DbSet<Budget> Budget { get; set; }
        public DbSet<BudgetPeriod> BudgetPeriod { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Expense> Expense { get; set; }
        public DbSet<Gender> Gender { get; set; }
        public DbSet<Mission> Mission { get; set; }
        public DbSet<Program> Program { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}