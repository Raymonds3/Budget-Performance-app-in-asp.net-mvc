using BudgetPerformanceApp4.Services;
using BudgetPerformanceApp4.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BudgetPerformanceApp4.Controllers
{
    public class KPiController : SecuredController
    {
        #region BudgetForExpense
        public ActionResult KPiBudgetExpense()
        {
            var model = KPiBudgetExpenseServices.GetAll(BPARepo);
            return View(model);
        }
        #endregion

        #region Expense in Budget
        public ActionResult KPiExpense(int budgetId)
        {
            var model = KPiExpenseServices.GetAll(BPARepo, budgetId);
            //sum the total expense
            List<ExpenseVM> data = new List<ExpenseVM>();
            Random rnd = new Random();
            for (int i = 1; i < 8; i++)
            {
                data.Add(new ExpenseVM() { ExpenseName = "Class-" + i.ToString(), ExpenseAmount = rnd.Next(10, 50) });
            }

            return View(model);
        }
        #endregion
    }
}