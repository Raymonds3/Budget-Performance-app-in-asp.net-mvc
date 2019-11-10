using BudgetPerformanceApp4.BudgetPerformanceModels;
using BudgetPerformanceApp4.BudgetPerformanceModels.Context.Repositories;
using BudgetPerformanceApp4.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BudgetPerformanceApp4.Services
{
    public class ProgramServices
    {
        public static List<ProgramVM> GetAll(BPARepo bpaRepo)
        {
            var programs = bpaRepo.Program.GetAll().ToList();
            var model = new List<ProgramVM>();

            foreach (var program in programs)
            {
                var programVM = new ProgramVM()
                {
                    Id = program.Id,
                    Name = program.Name,
                    Created = program.Created,
                    Modified = program.Modified,
                };
                model.Add(programVM);
            }

            return model;
        }

        public static void Create(ProgramVM model, BPARepo bpaRepo)
        {
            var program = new Program()
            {
                Name = model.Name,
                Created = DateTime.Now,
                Modified = DateTime.Now,
            };

            program.Validate();
            var exist = bpaRepo.Program.GetAll().Any(x => x.Name.Trim().ToLower() == program.Name.Trim().ToLower());
            if (!exist)
                bpaRepo.Program.Create(program);
            else
                throw new Exception($"{model.Name} already exist");
        }

        public static ProgramVM GetById(int id, BPARepo bpaRepo)
        {
            var program = bpaRepo.Program.GetById(id);
            var model = new ProgramVM()
            {
                Id = program.Id,
                Name = program.Name,
                Created = program.Created,
                Modified = program.Modified,
            };
            return model;
        }

        internal static void Update(ProgramVM model, BPARepo bpaRepo)
        {
            var program = bpaRepo.Program.GetById(model.Id);
            program.Name = model.Name;
            program.Modified = DateTime.Now;

            program.Validate();
            var exist = bpaRepo.Program.GetAll().Any(x => x.Name.Trim().ToLower() == program.Name.Trim().ToLower()
                                                    && x.Id != program.Id);
            if (!exist)
                bpaRepo.Program.Update(program);
            else
                throw new Exception($"{model.Name} already exist");
        }

        internal static ProgramVM GetNew(BPARepo bpaRepo)
        {
            return new ProgramVM();
        }
    }
}