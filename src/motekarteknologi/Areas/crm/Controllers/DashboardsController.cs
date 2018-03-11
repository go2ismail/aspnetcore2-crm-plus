using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace motekarteknologi.Areas.crm.Controllers
{
    [Area("crm")]
    public class DashboardsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}