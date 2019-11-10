using BudgetPerformanceApp4.Services;
using BudgetPerformanceApp4.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BudgetPerformanceApp4.Controllers
{
    public class ConfigurationsController : SecuredController
    {
        #region Mission
        public ActionResult Mission()
        {
            var model = MissionServices.GetAll(BPARepo);
            return View(model);
        }

        public ActionResult CreateMission()
        {
            var model = MissionServices.GetNew(BPARepo);
            return View(model);
        }

        //update

        [HttpPost]
        public ActionResult CreateMission(MissionVM model)
        {
            try
            {
                MissionServices.Create(model, BPARepo);

                return RedirectToAction("Mission");
            }
            catch (Exception ex)
            {
                SetViewError(ex);
                return View(model);
            }
        }

        public ActionResult UpdateMission(int id)
        {
            var model = MissionServices.GetById(id, BPARepo);
            return View(model);
        }

        [HttpPost]
        public ActionResult UpdateMission(MissionVM model)
        {
            try
            {
                MissionServices.Update(model, BPARepo);

                return RedirectToAction("Mission");
            }
            catch (Exception ex)
            {
                SetViewError(ex);
                return View(model);
            }
        }
        #endregion

        #region Department
        public ActionResult Department()
        {
            var model = DepartmentServices.GetAll(BPARepo);
            return View(model);
        }

        public ActionResult CreateDepartment()
        {
            var model = DepartmentServices.GetNew(BPARepo);
            return View(model);
        }

        //update

        [HttpPost]
        public ActionResult CreateDepartment(DepartmentVM model)
        {
            try
            {
                DepartmentServices.Create(model, BPARepo);

                return RedirectToAction("Department");
            }
            catch (Exception ex)
            {
                SetViewError(ex);
                return View(model);
            }
        }

        public ActionResult UpdateDepartment(int id)
        {
            var model = DepartmentServices.GetById(id, BPARepo);
            return View(model);
        }

        [HttpPost]
        public ActionResult UpdateDepartment(DepartmentVM model)
        {
            try
            {
                DepartmentServices.Update(model, BPARepo);

                return RedirectToAction("Department");
            }
            catch (Exception ex)
            {
                SetViewError(ex);
                return View(model);
            }
        }
        #endregion

        #region Program
        public ActionResult Program()
        {
            var model = ProgramServices.GetAll(BPARepo);
            return View(model);
        }

        public ActionResult CreateProgram()
        {
            var model = ProgramServices.GetNew(BPARepo);
            return View(model);
        }

        //update

        [HttpPost]
        public ActionResult CreateProgram(ProgramVM model)
        {
            try
            {
                ProgramServices.Create(model, BPARepo);

                return RedirectToAction("Program");
            }
            catch (Exception ex)
            {
                SetViewError(ex);
                return View(model);
            }
        }

        public ActionResult UpdateProgram(int id)
        {
            var model = ProgramServices.GetById(id, BPARepo);
            return View(model);
        }

        [HttpPost]
        public ActionResult UpdateProgram(ProgramVM model)
        {
            try
            {
                ProgramServices.Update(model, BPARepo);

                return RedirectToAction("Program");
            }
            catch (Exception ex)
            {
                SetViewError(ex);
                return View(model);
            }
        }
        #endregion

        #region BudgetPeriod
        public ActionResult BudgetPeriod()
        {
            var model = BudgetPeriodServices.GetAll(BPARepo);
            return View(model);
        }

        public ActionResult CreateBudgetPeriod()
        {
            var model = BudgetPeriodServices.GetNew(BPARepo);
            return View(model);
        }

        //update

        [HttpPost]
        public ActionResult CreateBudgetPeriod(BudgetPeriodVM model)
        {
            try
            {
                BudgetPeriodServices.Create(model, BPARepo);

                return RedirectToAction("BudgetPeriod");
            }
            catch (Exception ex)
            {
                SetViewError(ex);
                return View(model);
            }
        }

        public ActionResult UpdateBudgetPeriod(int id)
        {
            var model = BudgetPeriodServices.GetById(id, BPARepo);
            return View(model);
        }

        [HttpPost]
        public ActionResult UpdateBudgetPeriod(BudgetPeriodVM model)
        {
            try
            {
                BudgetPeriodServices.Update(model, BPARepo);

                return RedirectToAction("BudgetPeriod");
            }
            catch (Exception ex)
            {
                SetViewError(ex);
                return View(model);
            }
        }
        #endregion

        #region Activity
        public ActionResult Activity()
        {
            var model = ActivityServices.GetAll(BPARepo);
            return View(model);
        }

        public ActionResult CreateActivity()
        {
            var model = ActivityServices.GetNew(BPARepo);
            return View(model);
        }

        //update

        [HttpPost]
        public ActionResult CreateActivity(ActivityVM model)
        {
            try
            {
                ActivityServices.Create(model, BPARepo);

                return RedirectToAction("Activity");
            }
            catch (Exception ex)
            {
                SetViewError(ex);
                return View(model);
            }
        }

        public ActionResult UpdateActivity(int id)
        {
            var model = ActivityServices.GetById(id, BPARepo);
            return View(model);
        }

        [HttpPost]
        public ActionResult UpdateActivity(ActivityVM model)
        {
            try
            {
                ActivityServices.Update(model, BPARepo);

                return RedirectToAction("Activity");
            }
            catch (Exception ex)
            {
                SetViewError(ex);
                return View(model);
            }
        }
        #endregion
    }
}