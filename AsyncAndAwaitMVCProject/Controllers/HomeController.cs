using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using AsyncAndAwaitMVCProject.Models;

namespace AsyncAndAwaitMVCProject.Controllers
{
    public class HomeController : Controller
    {
        [AsyncTimeout(1200)]
        public async Task<ActionResult> Index()
        {
            var model = new HomePageModel();
            model.Message.Add($"Starting Action now: {DateTime.Now}");
            await GetAsyncHeadLines();
            await GetAsyncWeather();
            model.Message.Add($"Completing Action now: {DateTime.Now}");
            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        #region Helper Methods

        private Task GetAsyncWeather()
        {
           return Task.Delay(3000);
        }

        private Task GetAsyncHeadLines()
        {
            return Task.Delay(5000);
        }
        #endregion
    }
}