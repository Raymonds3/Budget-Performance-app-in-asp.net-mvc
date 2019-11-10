using BudgetPerformanceApp4.BudgetPerformanceModels;
using BudgetPerformanceApp4.BudgetPerformanceModels.Context.Repositories;
using BudgetPerformanceApp4.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BudgetPerformanceApp4.Services
{
    public class MissionServices
    {
        public static List<MissionVM> GetAll(BPARepo bpaRepo)
        {
            var missions = bpaRepo.Mission.GetAll().ToList();
            var model = new List<MissionVM>();

            foreach (var mission in missions)
            {
                var missionVM = new MissionVM()
                {
                    Id = mission.Id,
                    Name = mission.Name,
                    Created = mission.Created,
                    Modified = mission.Modified,
                };
                model.Add(missionVM);
            }

            return model;
        }

        public static void Create(MissionVM model, BPARepo bpaRepo)
        {
            var mission = new Mission()
            {
                Name = model.Name,
                Created = DateTime.Now,
                Modified = DateTime.Now,
            };

            mission.Validate();
            var exist = bpaRepo.Mission.GetAll().Any(x => x.Name.Trim().ToLower() == mission.Name.Trim().ToLower());
            if (!exist)
                bpaRepo.Mission.Create(mission);
            else
                throw new Exception($"{model.Name} already exist");
        }

        public static MissionVM GetById(int id, BPARepo bpaRepo)
        {
            var mission = bpaRepo.Mission.GetById(id);
            var model = new MissionVM()
            {
                Id = mission.Id,
                Name = mission.Name,
                Created = mission.Created,
                Modified = mission.Modified,
            };
            return model;
        }

        internal static void Update(MissionVM model, BPARepo bpaRepo)
        {
            var mission = bpaRepo.Mission.GetById(model.Id);
            mission.Name = model.Name;
            mission.Modified = DateTime.Now;

            mission.Validate();
            var exist = bpaRepo.Mission.GetAll().Any(x => x.Name.Trim().ToLower() == mission.Name.Trim().ToLower()
                                                    && x.Id != mission.Id);
            if (!exist)
                bpaRepo.Mission.Update(mission);
            else
                throw new Exception($"{model.Name} already exist");
        }

        internal static MissionVM GetNew(BPARepo bpaRepo)
        {
            return new MissionVM();
        }
    }
}