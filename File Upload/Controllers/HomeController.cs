using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TextMatch.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            var model = new ViewModels.HomeModel();

            model.Text = "Polly put the kettle on, polly put the kettle on, polly put the kettle on we’ll all have tea";

            return View(model);
        }

    }
}
