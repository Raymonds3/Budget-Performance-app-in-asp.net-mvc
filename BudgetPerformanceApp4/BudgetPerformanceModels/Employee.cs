using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BudgetPerformanceApp4.BudgetPerformanceModels
{
    public class Employee
    {
        public int Id { get; set; }
        public string EmployeeNo { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeSurname { get; set; }
        public string HomeAddress { get; set; }
        public string Email { get; set; }
        public string ContactNo { get; set; }
        public int GenderId { get; set; }
        public int Age { get; set; }

        public void Validate()
        {
            if (GenderId <= 0)
                throw new Exception("GenderId is Required");

            if (string.IsNullOrWhiteSpace(EmployeeName))
                throw new Exception("Employee Name is Required");

            if (string.IsNullOrWhiteSpace(EmployeeNo))
                throw new Exception("EmployeeNo is Required");

            if (string.IsNullOrWhiteSpace(EmployeeSurname))
                throw new Exception("EmployeeSurname is Required");

            if (string.IsNullOrWhiteSpace(HomeAddress))
                throw new Exception("HomeAddress is Required");

            if (string.IsNullOrWhiteSpace(Email))
                throw new Exception("Email is Required");

            if (string.IsNullOrWhiteSpace(ContactNo))
                throw new Exception("ContactNo is Required");

            if (Age <= 0)
                throw new Exception("Age is Required");
        }
    }
}