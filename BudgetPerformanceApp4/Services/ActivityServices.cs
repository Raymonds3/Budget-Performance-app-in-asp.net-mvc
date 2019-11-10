using BudgetPerformanceApp4.BudgetPerformanceModels;
using BudgetPerformanceApp4.BudgetPerformanceModels.Context.Repositories;
using BudgetPerformanceApp4.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BudgetPerformanceApp4.Services
{
    public class ActivityServices
    {
        public static List<ActivityVM> GetAll(BPARepo bpaRepo)
        {
            var activities = bpaRepo.Activities.GetAll().ToList();
            var model = new List<ActivityVM>();

            foreach (var activity in activities)
            {
                var activityVM = new ActivityVM()
                {
                    Id = activity.Id,
                    Name = activity.Name,
                    ManagerId = activity.ManagerId,
                    Objective = activity.Objective,
                };
                model.Add(activityVM);
            }

            return model;
        }

        public static void Create(ActivityVM model, BPARepo bpaRepo)
        {
            var activity = new Activities()
            {
                Name = model.Name,
                ManagerId = model.ManagerId,
                Objective = model.Objective,
            };

            activity.Validate();
            var exist = bpaRepo.Activities.GetAll().Any(x => x.Name.Trim().ToLower() == activity.Name.Trim().ToLower());
            if (!exist)
                bpaRepo.Activities.Create(activity);
            else
                throw new Exception($"{model.Name} already exist");
        }

        public static ActivityVM GetById(int id, BPARepo bpaRepo)
        {
            var activity = bpaRepo.Activities.GetById(id);
            var model = new ActivityVM()
            {
                Id = activity.Id,
                Name = activity.Name,
                ManagerId = activity.ManagerId,
                Objective = activity.Objective,
            };
            return model;
        }

        internal static void Update(ActivityVM model, BPARepo bpaRepo)
        {
            var activity = bpaRepo.Activities.GetById(model.Id);
            activity.Name = model.Name;
            activity.ManagerId = model.ManagerId;
            activity.Objective = model.Objective;

            activity.Validate();
            var exist = bpaRepo.Activities.GetAll().Any(x => x.Name.Trim().ToLower() == activity.Name.Trim().ToLower()
                                                    && x.Id != activity.Id);
            if (!exist)
                bpaRepo.Activities.Update(activity);
            else
                throw new Exception($"{model.Name} already exist");
        }

        internal static ActivityVM GetNew(BPARepo bpaRepo)
        {
            return new ActivityVM();
        }
    }
}