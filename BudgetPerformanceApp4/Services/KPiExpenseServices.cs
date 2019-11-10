using BudgetPerformanceApp4.BudgetPerformanceModels;
using BudgetPerformanceApp4.BudgetPerformanceModels.Context.Repositories;
using BudgetPerformanceApp4.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BudgetPerformanceApp4.Services
{
    public class KPiExpenseServices
    {
        public static ExpensesVM GetAll(BPARepo bpaRepo, int budgetId)
        {
            var expenses = bpaRepo.Expense.GetAll().Where(x => x.BudgetId == budgetId).ToList();
            var expenseVMs = new List<ExpenseVM>();

            foreach (var expense in expenses)
            {
                var expenseVM = new ExpenseVM()
                {
                    Id = expense.Id,
                    BudgetId = expense.BudgetId,
                    ExpenseName = expense.ExpenseName,
                    ExpenseAmount = expense.ExpenseAmount,
                    Units = expense.Units,
                    ExpenseDate = expense.ExpenseDate,
                };
                expenseVMs.Add(expenseVM);
            }
            var model = new ExpensesVM()
            {
                Expenses = expenseVMs,
                BudgetId = budgetId,
            };
            return model;
        }
    }
}