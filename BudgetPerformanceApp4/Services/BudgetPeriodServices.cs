using BudgetPerformanceApp4.BudgetPerformanceModels;
using BudgetPerformanceApp4.BudgetPerformanceModels.Context.Repositories;
using BudgetPerformanceApp4.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BudgetPerformanceApp4.Services
{
    public class BudgetPeriodServices
    {
        public static List<BudgetPeriodVM> GetAll(BPARepo bpaRepo)
        {
            var budgetPeriods = bpaRepo.BudgetPeriod.GetAll().ToList();
            var model = new List<BudgetPeriodVM>();

            foreach (var budgetPeriod in budgetPeriods)
            {
                var budgetPeriodVM = new BudgetPeriodVM()
                {
                    Id = budgetPeriod.Id,
                    Name = budgetPeriod.Name,
                };
                model.Add(budgetPeriodVM);
            }

            return model;
        }

        public static void Create(BudgetPeriodVM model, BPARepo bpaRepo)
        {
            var budgetPeriod = new BudgetPeriod()
            {
                Name = model.Name,
            };

            budgetPeriod.Validate();
            var exist = bpaRepo.BudgetPeriod.GetAll().Any(x => x.Name.Trim().ToLower() == budgetPeriod.Name.Trim().ToLower());
            if (!exist)
                bpaRepo.BudgetPeriod.Create(budgetPeriod);
            else
                throw new Exception($"{model.Name} already exist");
        }

        public static BudgetPeriodVM GetById(int id, BPARepo bpaRepo)
        {
            var budgetPeriod = bpaRepo.BudgetPeriod.GetById(id);
            var model = new BudgetPeriodVM()
            {
                Id = budgetPeriod.Id,
                Name = budgetPeriod.Name,
            };
            return model;
        }

        internal static void Update(BudgetPeriodVM model, BPARepo bpaRepo)
        {
            var budgetPeriod = bpaRepo.BudgetPeriod.GetById(model.Id);
            budgetPeriod.Name = model.Name;

            budgetPeriod.Validate();
            var exist = bpaRepo.BudgetPeriod.GetAll().Any(x => x.Name.Trim().ToLower() == budgetPeriod.Name.Trim().ToLower()
                                                    && x.Id != budgetPeriod.Id);
            if (!exist)
                bpaRepo.BudgetPeriod.Update(budgetPeriod);
            else
                throw new Exception($"{model.Name} already exist");
        }

        internal static BudgetPeriodVM GetNew(BPARepo bpaRepo)
        {
            return new BudgetPeriodVM();
        }
    }
}