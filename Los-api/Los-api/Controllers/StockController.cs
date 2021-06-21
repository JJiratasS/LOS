using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Los_api.Controllers
{
    [Produces("application/json")]
    [Route("api/Stocks")]
    public class StockController : Controller
    {
        private readonly IOptions<ProductItemController> appSettings;

        public StockController(IOptions<ProductItemController> app)
        {
            appSettings = app;
        }

        [HttpPost]
        [Route("getproductid")]
        public IActionResult GetProductItems()
        {
            var list = new List<string>();
            list.Add("02");
            list.Add("WT02");
            list.Add("1");
            return Ok(list);
        }
        public ActionResult Index()
        {
            return View();
        }
    }
}