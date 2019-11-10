using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BudgetPerformanceApp4.BudgetPerformanceModels
{
    public class Expense
    {
        public int Id { get; set; }
        public int BudgetId { get; set; }
        public string ExpenseName { get; set; }
        public int ExpenseAmount { get; set; }
        public int Units { get; set; }
        public DateTime ExpenseDate { get; set; }
        public int BudgetAmount { get; set; }

        public void Validate()
        {
            if (BudgetId <= 0)
                throw new Exception("Budget is Required");

            if (ExpenseAmount <= 0)
                throw new Exception("ExpenseAmount is Required");

            if (Units <= 0)
                throw new Exception("Units is Required");

            if (string.IsNullOrWhiteSpace(ExpenseName))
                throw new Exception("ExpenseName is Required");

            if (ExpenseDate == null || ExpenseDate == DateTime.MinValue)
                throw new Exception("ExpenseDate is Required");

        }
    }
}