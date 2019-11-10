using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BudgetPerformanceApp4.ViewModel
{
    public class ExpenseVM
    {
        public int Id { get; set; }
        public int BudgetId { get; set; }
        public string ExpenseName { get; set; }
        public int ExpenseAmount { get; set; }
        public int Units { get; set; }
        public DateTime ExpenseDate { get; set; }
    }
}