using BudgetPerformanceApp4.BudgetPerformanceModels;
using BudgetPerformanceApp4.BudgetPerformanceModels.Context.Repositories;
using BudgetPerformanceApp4.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BudgetPerformanceApp4.Services
{
    public class BudgetServices
    {
        public static List<BudgetVM> GetAll(BPARepo bpaRepo)
        {
            var budgets = bpaRepo.Budget.GetAll().ToList();
            var model = new List<BudgetVM>();

            foreach (var budget in budgets)
            {
                var budgetVM = new BudgetVM()
                {
                    Id = budget.Id,
                    BudgetName = budget.BudgetName,
                    BudgetAmount = budget.BudgetAmount,
                    DepartmentId = budget.DepartmentId,
                    ProgramId = budget.ProgramId,
                    ActivityId = budget.ActivityId,
                    BudgetPeriodId = budget.BudgetPeriodId,
                    Months = budget.Months,
                    StartDate = budget.StartDate,
                    EndDate = budget.EndDate,
                };
                model.Add(budgetVM);
            }

            return model;
        }

        public static void Create(BudgetVM model, BPARepo bpaRepo)
        {
            var budget = new Budget()
            {
                BudgetName = model.BudgetName,
                BudgetAmount = model.BudgetAmount,
                DepartmentId = model.DepartmentId,
                ProgramId = model.ProgramId,
                ActivityId = model.ActivityId,
                BudgetPeriodId = model.BudgetPeriodId,
                Months = model.Months,
                StartDate = model.StartDate,
                EndDate = model.EndDate,
            };

            budget.Validate();
            var exist = bpaRepo.Budget.GetAll().Any(x => x.BudgetName.Trim().ToLower() == budget.BudgetName.Trim().ToLower());
            if (!exist)
                bpaRepo.Budget.Create(budget);
            else
                throw new Exception($"{model.BudgetName} already exist");
        }

        public static BudgetVM GetById(int id, BPARepo bpaRepo)
        {
            var budget = bpaRepo.Budget.GetById(id);
            var model = new BudgetVM()
            {
                Id = budget.Id,
                BudgetName = budget.BudgetName,
                BudgetAmount = budget.BudgetAmount,
                DepartmentId = budget.DepartmentId,
                ProgramId = budget.ProgramId,
                ActivityId = budget.ActivityId,
                BudgetPeriodId = budget.BudgetPeriodId,
                Months = budget.Months,
                StartDate = budget.StartDate,
                EndDate = budget.EndDate,
            };
            return model;
        }

        internal static void Update(BudgetVM model, BPARepo bpaRepo)
        {
            var budget = bpaRepo.Budget.GetById(model.Id);
            budget.BudgetName = model.BudgetName;
            budget.BudgetAmount = model.BudgetAmount;
            budget.DepartmentId = model.BudgetAmount;
            budget.ProgramId = model.ProgramId;
            budget.ActivityId = model.ActivityId;
            budget.BudgetPeriodId = model.BudgetPeriodId;
            budget.Months = model.Months;
            budget.StartDate = model.StartDate;
            budget.EndDate = model.EndDate;

            budget.Validate();
            var exist = bpaRepo.Budget.GetAll().Any(x => x.BudgetName.Trim().ToLower() == budget.BudgetName.Trim().ToLower()
                                                    && x.Id != budget.Id);
            if (!exist)
                bpaRepo.Budget.Update(budget);
            else
                throw new Exception($"{model.BudgetName} already exist");
        }

        internal static BudgetVM GetNew(BPARepo bpaRepo)
        {
            return new BudgetVM();
        }
    }
}