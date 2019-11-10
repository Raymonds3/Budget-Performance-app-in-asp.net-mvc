using BudgetPerformanceApp4.BudgetPerformanceModels;
using BudgetPerformanceApp4.BudgetPerformanceModels.Context.Repositories;
using BudgetPerformanceApp4.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BudgetPerformanceApp4.Services
{
    public class KPiBudgetExpenseServices
    {
        public static List<BudgetExpenseVM> GetAll(BPARepo bpaRepo)
        {
            var budgetExpenses = bpaRepo.Budget.GetAll().ToList();
            var model = new List<BudgetExpenseVM>();

            foreach (var budgetExpense in budgetExpenses)
            {
                var budgetExpenseVM = new BudgetExpenseVM()
                {
                    Id = budgetExpense.Id,
                    BudgetName = budgetExpense.BudgetName,
                    BudgetAmount = budgetExpense.BudgetAmount,
                    DepartmentId = budgetExpense.DepartmentId,
                    ProgramId = budgetExpense.ProgramId,
                    ActivityId = budgetExpense.ActivityId,
                    BudgetPeriodId = budgetExpense.BudgetPeriodId,
                    Months = budgetExpense.Months,
                    StartDate = budgetExpense.StartDate,
                    EndDate = budgetExpense.EndDate,
                };
                model.Add(budgetExpenseVM);
            }

            return model;
        }
    }
}