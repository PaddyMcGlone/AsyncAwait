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
        
        [AsyncTimeout(1200)] //A Timeout annotation for methods, sets timeout limit
        // Annotation below is used to display special views on screen - instead of default custom error pages
        //I love this annotation
        [HandleError(ExceptionType = typeof(TimeoutException), View = "MySpecialTimeoutErrorView")]
        public async Task<ActionResult> Index()
        {
            var model = new HomePageModel();
            model.Message.Add($"Starting Action now: {DateTime.Now}");
            try
            {
                await GetAsyncHeadLines();
                await GetAsyncWeather();
            }
            catch(Exception exception)
            {
                Console.WriteLine($"There has been an error: {exception.Message}");
                Console.WriteLine($"Inner exception: {exception.InnerException}");
            }
            
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