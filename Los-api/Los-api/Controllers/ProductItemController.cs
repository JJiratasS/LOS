using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Los_api.Controllers
{
    [Produces("application/json")]
    [Route("api/Products")]
    public class ProductItemController : Controller
    {
        private IConfiguration configuation;
        public IActionResult Index()
        {
            return View();
        }

        public ProductItemController(IConfiguration iConfig)
        {
            configuation = iConfig;
        }

        [HttpPost]
        [Route("getproductid")]
        public IActionResult GetProductItems()
        {
            var list = new List<string>();
            list.Add("02");
            list.Add("WT02");
            list.Add("");
            list.Add("1000");
            return Ok(list);
        }
    }
}
