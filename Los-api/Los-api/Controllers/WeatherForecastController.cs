using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Los_api.Controllers
{
    public class WeatherForecastController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
