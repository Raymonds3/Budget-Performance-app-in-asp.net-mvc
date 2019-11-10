using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BudgetPerformanceApp4.ViewModel
{
    public class ExpensesVM
    {
        public List<ExpenseVM> Expenses { get; set; }
        public int BudgetId { get; set; }
    }
}