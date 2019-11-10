using BudgetPerformanceApp4.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BudgetPerformanceApp4.BudgetPerformanceModels.Context.Repositories;
using BudgetPerformanceApp4.BudgetPerformanceModels;

namespace BudgetPerformanceApp4.Helpers
{
    public static class SelectListHelper
    {
        private static List<SelectListItem> CreateSelectListItems<T>(IList<T> entities, Func<T, object> funcToGetValue, Func<T, object> funcToGetText)
        {
            var items = entities
                .Select(x => new SelectListItem
                {
                    Value = funcToGetValue(x).ToString(),
                    Text = funcToGetText(x).ToString()
                }).ToList();

            return items;
        }

        private static SelectList CreateSelectList<T>(IList<T> entities, Func<T, object> funcToGetValue, Func<T, object> funcToGetText)
        {
            var items = CreateSelectListItems(entities, funcToGetValue, funcToGetText);

            return new SelectList(items, "Value", "Text");
        }

        private static SelectList CreateFromEnum<TEnum>() where TEnum : struct, IComparable, IFormattable, IConvertible
        {
            var items = new List<SelectListItem>();

            foreach (var listItem in Enum.GetValues(typeof(TEnum)))
            {
                items.Add(new SelectListItem
                {
                    Text = listItem.ToString().Depascalise(),
                    Value = Convert.ToInt32(listItem).ToString()
                });
            }

            return CreateSelectList(items, i => i.Value, i => i.Text);
        }

        private static SelectList CreateFromEnumStrings<TEnum>() where TEnum : struct, IComparable, IFormattable, IConvertible
        {
            var items = new List<string>();
            foreach (var listItem in Enum.GetValues(typeof(TEnum)))
            {
                items.Add(listItem.ToString());
            }

            return CreateSelectList(items, i => i, i => i.Depascalise());
        }

        public static SelectList GetEmpty()
        {
            return new SelectList(new List<SelectListItem>());
        }

        //public static SelectList GetRoles()
        //{
        //    var roles = CreateFromEnumStrings<RolesEnum>();
        //    return roles;
        //}

        public static SelectList GetMission()
        {
            BPARepo repo = new BPARepo();
            var missions = new List<Mission>();
            var mission = new Mission()
            {
                Id = 0,
                Name = "Please Select",
            };
            missions.Add(mission);
            missions.AddRange(repo.Mission.GetAll().ToList());

            return CreateSelectList(missions, x => x.Id, x => x.Name);
        }

        public static SelectList GetEmployee()
        {
            BPARepo repo = new BPARepo();
            var employees = new List<Employee>();
            var employee = new Employee()
            {
                Id = 0,
                EmployeeName = "Please Select",
            };
            employees.Add(employee);
            employees.AddRange(repo.Employee.GetAll().ToList());

            return CreateSelectList(employees, x => x.Id, x => x.EmployeeName);
        }

        public static SelectList GetDepartment()
        {
            BPARepo repo = new BPARepo();
            var departments = new List<Department>();
            var department = new Department()
            {
                Id = 0,
                Name = "Please Select",
            };
            departments.Add(department);
            departments.AddRange(repo.Department.GetAll().ToList());

            return CreateSelectList(departments, x => x.Id, x => x.Name);
        }

        public static SelectList GetProgram()
        {
            BPARepo repo = new BPARepo();
            var programs = new List<Program>();
            var program = new Program()
            {
                Id = 0,
                Name = "Please Select",
            };
            programs.Add(program);
            programs.AddRange(repo.Program.GetAll().ToList());

            return CreateSelectList(programs, x => x.Id, x => x.Name);
        }

        public static SelectList GetActivity()
        {
            BPARepo repo = new BPARepo();
            var activities = new List<Activities>();
            var activity = new Activities()
            {
                Id = 0,
                Name = "Please Select",
            };
            activities.Add(activity);
            activities.AddRange(repo.Activities.GetAll().ToList());

            return CreateSelectList(activities, x => x.Id, x => x.Name);
        }

        public static SelectList GetBudgetPeriod()
        {
            BPARepo repo = new BPARepo();
            var budgetPeriods = new List<BudgetPeriod>();
            var budgetPeriod = new BudgetPeriod()
            {
                Id = 0,
                Name = "Please Select",
            };
            budgetPeriods.Add(budgetPeriod);
            budgetPeriods.AddRange(repo.BudgetPeriod.GetAll().ToList());

            return CreateSelectList(budgetPeriods, x => x.Id, x => x.Name);
        }

        public static SelectList GetBudget()
        {
            BPARepo repo = new BPARepo();
            var budgets = new List<Budget>();
            var budget = new Budget()
            {
                Id = 0,
                BudgetName = "Please Select",
            };
            budgets.Add(budget);
            budgets.AddRange(repo.Budget.GetAll().ToList());

            return CreateSelectList(budgets, x => x.Id, x => x.BudgetName);
        }
    }
}