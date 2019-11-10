using BudgetPerformanceApp4.BudgetPerformanceModels.Context.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace BudgetPerformanceApp4.Controllers
{
    public class SecuredController : Controller
    {
        // GET: Secured
        public BPARepo BPARepo;
        protected override void Initialize(RequestContext requestContext)
        {
            try
            {
                base.Initialize(requestContext);
                if (BPARepo == null)
                    BPARepo = new BPARepo();
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }

        }

        protected void SetViewError(Exception ex)
        {
            ModelState.AddModelError("", GetInnerExceptionMessage(ex));
        }

        private static string GetInnerExceptionMessage(Exception ex)
        {
            while (ex.InnerException != null)
            {
                ex = ex.InnerException;
            }
            return ex.Message;
        }

        public string RenderViewToString(string viewName, object model)
        {
            ViewData.Model = model;
            using (var sw = new StringWriter())
            {
                var viewResult = ViewEngines.Engines.FindPartialView(ControllerContext, viewName);
                if (viewResult.View == null)
                    throw new Exception($"View not found name: {viewName}");

                var viewContext = new ViewContext(ControllerContext, viewResult.View, ViewData, TempData, sw);
                viewResult.View.Render(viewContext, sw);
                viewResult.ViewEngine.ReleaseView(ControllerContext, viewResult.View);
                return sw.GetStringBuilder().ToString();
            }
        }

        public JsonResult ThrowJsonError(Exception ex)
        {
            var msg = ex.Message;
            return ThrowJsonError(msg);
        }

        public JsonResult ThrowJsonError(string message)
        {
            Response.StatusCode = (int)System.Net.HttpStatusCode.BadRequest;
            Response.StatusDescription = message;
            return Json(new { Message = message }, JsonRequestBehavior.AllowGet);
        }
    }
}