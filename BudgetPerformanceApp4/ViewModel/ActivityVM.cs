using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BudgetPerformanceApp4.ViewModel
{
    public class ActivityVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ManagerId { get; set; }
        public string Objective { get; set; }
    }
}