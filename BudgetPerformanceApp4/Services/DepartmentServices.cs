using BudgetPerformanceApp4.BudgetPerformanceModels;
using BudgetPerformanceApp4.BudgetPerformanceModels.Context.Repositories;
using BudgetPerformanceApp4.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BudgetPerformanceApp4.Services
{
    public class DepartmentServices
    {
        public static List<DepartmentVM> GetAll(BPARepo bpaRepo)
        {
            var departments = bpaRepo.Department.GetAll().ToList();
            var model = new List<DepartmentVM>();

            foreach (var department in departments)
            {
                var departmentVM = new DepartmentVM()
                {
                    Id = department.Id,
                    Name = department.Name,
                    Created = department.Created,
                    Modified = department.Modified,
                };
                model.Add(departmentVM);
            }

            return model;
        }

        public static void Create(DepartmentVM model, BPARepo bpaRepo)
        {
            var department = new Department()
            {
                Name = model.Name,
                Created = DateTime.Now,
                Modified = DateTime.Now,
            };

            department.Validate();
            var exist = bpaRepo.Mission.GetAll().Any(x => x.Name.Trim().ToLower() == department.Name.Trim().ToLower());
            if (!exist)
                bpaRepo.Department.Create(department);
            else
                throw new Exception($"{model.Name} already exist");
        }

        public static DepartmentVM GetById(int id, BPARepo bpaRepo)
        {
            var department = bpaRepo.Department.GetById(id);
            var model = new DepartmentVM()
            {
                Id = department.Id,
                Name = department.Name,
                Created = department.Created,
                Modified = department.Modified,
            };
            return model;
        }

        internal static void Update(DepartmentVM model, BPARepo bpaRepo)
        {
            var department = bpaRepo.Department.GetById(model.Id);
            department.Name = model.Name;
            department.Modified = DateTime.Now;

            department.Validate();
            var exist = bpaRepo.Department.GetAll().Any(x => x.Name.Trim().ToLower() == department.Name.Trim().ToLower()
                                                    && x.Id != department.Id);
            if (!exist)
                bpaRepo.Department.Update(department);
            else
                throw new Exception($"{model.Name} already exist");
        }

        internal static DepartmentVM GetNew(BPARepo bpaRepo)
        {
            return new DepartmentVM();
        }
    }
}