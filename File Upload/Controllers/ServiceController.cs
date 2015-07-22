using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TextMatch.Controllers
{
    public class ServiceController : Controller
    {

        /// <summary>
        /// Seaarch for sub-string in the supplied text and return a CSV list of character positions
        /// </summary>
        /// <param name="text">Text to search in</param>
        /// <param name="subText">sub-text to search for</param>
        /// <returns></returns>
        public JsonResult TextMatches(string text, string subText)
        {

            var matchService = new Services.StringSearchService();

            var matchesAsCsv = matchService.MatchString(text, subText);

            if (string.IsNullOrEmpty(matchesAsCsv))
            {
                matchesAsCsv = "There is no output";
            }

            return Json(matchesAsCsv, JsonRequestBehavior.AllowGet);
        }
    }
}
