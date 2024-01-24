using Microsoft.AspNetCore.Mvc;
using PatientManagement.Models;
using System.Diagnostics;

namespace PatientManagement.Controllers
{
    public class MainController : Controller
    {
        public IActionResult MainPage()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
