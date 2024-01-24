using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using PatientManagement.Models;
using System.Diagnostics;

namespace PatientManagement.Controllers
{
    public class AdminController : Controller
    {
        public IConfiguration Configuration { get; }

        public AdminController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Admin ad)
        {
            string connectionString = Configuration["ConnectionStrings:PatientConnection"];
            using (var con = new SqlConnection(connectionString))
            {
                using (var cmd = new SqlCommand("select dbo.AdminCheck(@UserName,@Password)", con))
                {
                    cmd.Parameters.AddWithValue("@UserName", ad.UserName);
                    cmd.Parameters.AddWithValue("@Password", ad.Password);


                    con.Open();
                    int c = Convert.ToInt32(cmd.ExecuteScalar());

                    if (c == 1)
                    {
                        return RedirectToAction("Index","Patients");
                       // Console.WriteLine("welcome User");
                       // con.Close();

                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Warning!Wrong Attempt");
                        return View(ad);
                    }
                }

            }
            return View(ad);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}