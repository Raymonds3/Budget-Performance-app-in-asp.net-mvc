using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BudgetPerformanceApp4.BudgetPerformanceModels
{
    public class Budget
    {
        public int Id { get; set; }
        public string BudgetName { get; set; }
        public int BudgetAmount { get; set; }
        public int DepartmentId { get; set; }
        public int ProgramId { get; set; }
        public int ActivityId { get; set; }
        public int BudgetPeriodId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Months { get; set; }

        public void Validate()
        {
            if (DepartmentId <= 0)
                throw new Exception("Department is Required");

            if (ProgramId <= 0)
                throw new Exception("Program is Required");

            if (ActivityId <= 0)
                throw new Exception("Activity is Required");

            if (BudgetPeriodId <= 0)
                throw new Exception("BudgetPeriod is Required");

            if (Months <= 0)
                throw new Exception("Months is Required");

            if (BudgetAmount <= 0)
                throw new Exception("Budget Amount is Required");

            if (string.IsNullOrWhiteSpace(BudgetName))
                throw new Exception("Name is Required");

            if (StartDate == null || StartDate == DateTime.MinValue)
                throw new Exception("StartDate is Required");

            if (EndDate == null || EndDate == DateTime.MinValue)
                throw new Exception("EndDate is Required");
        }
    }
}