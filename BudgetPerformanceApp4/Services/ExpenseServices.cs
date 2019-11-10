using BudgetPerformanceApp4.BudgetPerformanceModels;
using BudgetPerformanceApp4.BudgetPerformanceModels.Context.Repositories;
using BudgetPerformanceApp4.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BudgetPerformanceApp4.Services
{
    public class ExpenseServices
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

        public static void Create(ExpenseVM model, BPARepo bpaRepo)
        {
            var expense = new Expense()
            {
                BudgetId = model.BudgetId,
                ExpenseName = model.ExpenseName,
                ExpenseAmount = model.ExpenseAmount,
                Units = model.Units,
                ExpenseDate = model.ExpenseDate,
            };

            expense.Validate();
            var exist = bpaRepo.Expense.GetAll().Any(x => x.BudgetId == expense.BudgetId
                                                    && x.ExpenseName.Trim().ToLower() == expense.ExpenseName.Trim().ToLower());
            if (!exist)
                bpaRepo.Expense.Create(expense);
            else
                throw new Exception($"{model.ExpenseName} already exist for the country");
        }

        public static ExpenseVM GetById(int id, BPARepo bpaRepo)
        {
            var expense = bpaRepo.Expense.GetById(id);
            var model = new ExpenseVM()
            {
                Id = expense.Id,
                BudgetId = expense.BudgetId,
                ExpenseName = expense.ExpenseName,
                ExpenseAmount = expense.ExpenseAmount,
                Units = expense.Units,
                ExpenseDate = expense.ExpenseDate,
            };
            return model;
        }

        internal static void Update(ExpenseVM model, BPARepo bpaRepo)
        {
            var expense = bpaRepo.Expense.GetById(model.Id);
            expense.BudgetId = model.BudgetId;
            expense.ExpenseName = model.ExpenseName;
            expense.ExpenseAmount = model.ExpenseAmount;
            expense.Units = model.Units;
            expense.ExpenseDate = model.ExpenseDate;

            expense.Validate();
            var exist = bpaRepo.Expense.GetAll().Any(x => x.BudgetId == expense.BudgetId
                                                    && x.ExpenseName.Trim().ToLower() == expense.ExpenseName.Trim().ToLower()
                                                    && x.Id != expense.Id);
            if (!exist)
                bpaRepo.Expense.Update(expense);
            else
                throw new Exception($"{model.ExpenseName} already exist for the country");
        }

        internal static ExpenseVM GetNew(BPARepo bpaRepo, int budgetId)
        {
            return new ExpenseVM()
            {
                BudgetId = budgetId,
            };
        }
    }
}