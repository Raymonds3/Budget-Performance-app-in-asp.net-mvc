using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BudgetPerformanceApp4.BudgetPerformanceModels
{
    public class Activities
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ManagerId { get; set; }
        public string Objective { get; set; }

        public void Validate()
        {
            if (ManagerId <= 0)
                throw new Exception("Manager is Required");

            if (string.IsNullOrWhiteSpace(Name))
                throw new Exception("Name is Required");

            if (string.IsNullOrWhiteSpace(Objective))
                throw new Exception("Objective is Required");
        }
    }
}