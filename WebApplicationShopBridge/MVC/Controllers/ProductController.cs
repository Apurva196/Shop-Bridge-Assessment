using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using MVC.Models;

namespace MVC.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            IEnumerable<Products> prodList;
            HttpResponseMessage response = GlobalVariables.webAPIClient.GetAsync("Products").Result;
            prodList = response.Content.ReadAsAsync<IEnumerable<Products>>().Result;
            return View(prodList);
        }
    }
}