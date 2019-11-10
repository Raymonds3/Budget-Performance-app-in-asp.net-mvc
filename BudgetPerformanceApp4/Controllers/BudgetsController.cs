using BudgetPerformanceApp4.Services;
using BudgetPerformanceApp4.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BudgetPerformanceApp4.Controllers
{
    public class BudgetsController : SecuredController
    {
        // GET: Budgets
        public ActionResult Budget()
        {
            var model = BudgetServices.GetAll(BPARepo);
            return View(model);
        }

        public ActionResult CreateBudget()
        {
            var model = BudgetServices.GetNew(BPARepo);
            return View(model);
        }

        //update

        [HttpPost]
        public ActionResult CreateBudget(BudgetVM model)
        {
            try
            {
                BudgetServices.Create(model, BPARepo);

                return RedirectToAction("Budget");
            }
            catch (Exception ex)
            {
                SetViewError(ex);
                return View(model);
            }
        }

        public ActionResult UpdateBudget(int id)
        {
            var model = BudgetServices.GetById(id, BPARepo);
            return View(model);
        }

        [HttpPost]
        public ActionResult UpdateBudget(BudgetVM model)
        {
            try
            {
                BudgetServices.Update(model, BPARepo);

                return RedirectToAction("Budget");
            }
            catch (Exception ex)
            {
                SetViewError(ex);
                return View(model);
            }
        }
    }
}