using BudgetPerformanceApp4.Services;
using BudgetPerformanceApp4.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BudgetPerformanceApp4.Controllers
{
    public class ExpenseController : SecuredController
    {
        #region BudgetForExpense
        public ActionResult BudgetExpense()
        {
            var model = BudgetExpenseServices.GetAll(BPARepo);
            return View(model);
        }
        #endregion

        #region Expense in Budget
        public ActionResult Expense(int budgetId)
        {
            var model = ExpenseServices.GetAll(BPARepo, budgetId);
            return View(model);
        }

        public ActionResult CreateExpense(int budgetId)
        {
            var model = ExpenseServices.GetNew(BPARepo, budgetId);
            return View(model);
        }

        [HttpPost]
        public ActionResult CreateExpense(ExpenseVM model)
        {
            try
            {
                ExpenseServices.Create(model, BPARepo);

                return RedirectToAction("Expense", new { budgetId = model.BudgetId });
            }
            catch (Exception ex)
            {
                SetViewError(ex);
                return View(model);
            }
        }

        public ActionResult UpdateExpense(int id)
        {
            var model = ExpenseServices.GetById(id, BPARepo);
            return View(model);
        }

        [HttpPost]
        public ActionResult UpdateExpense(ExpenseVM model)
        {
            try
            {
                ExpenseServices.Update(model, BPARepo);

                return RedirectToAction("Expense", new { budgetId = model.BudgetId });
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