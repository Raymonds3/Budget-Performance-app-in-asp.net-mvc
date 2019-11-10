using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BudgetPerformanceApp4.ViewModel
{
    public class BudgetVM
    {
        public int Id { get; set; }
        public string BudgetName { get; set; }
        public int BudgetAmount { get; set; }
        public int DepartmentId { get; set; }
        public int ProgramId { get; set; }
        public int ActivityId { get; set; }
        public int BudgetPeriodId { get; set; }
        public int Months { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}