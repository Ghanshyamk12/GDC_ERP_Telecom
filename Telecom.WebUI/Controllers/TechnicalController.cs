using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Telecom.WebUI.Controllers
{
    public class TechnicalController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [AcceptVerbs("GET")]
        public string ParmitDatabaseSwap()
        {
            string status = null;

            string getDatabaseSwap = HttpContext.Session.GetString("DatabaseSwap");
            if (getDatabaseSwap == "true")
            {
                HttpContext.Session.SetString("DatabaseSwap", "false");
                status = "Database swap is enabled";
            }
            else
            {
                HttpContext.Session.SetString("DatabaseSwap", "true");
                status = "Database swap is disabled";
            }
                
            return status;
        }
    }
}