using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using NPOI.SS.Util;
using PatientManagement.Models;
using System;
using System.Data;
using System.Globalization;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PatientManagement.Controllers
{
    public class PatientsController : Controller
    {
        public IConfiguration Configuration { get; }

        public PatientsController(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public ActionResult Index()

        {
            List<Detail> detailList = new List<Detail>();
            string connectionString = Configuration["ConnectionStrings:PatientConnection"];
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = "select * from Detail";
                SqlCommand cmd = new SqlCommand(sql, connection);
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        Detail dt = new Detail();
                        dt.PatientId=Convert.ToInt32(sdr["PatientId"]);
                        dt.PatientName=Convert.ToString(sdr["PatientName"]);
                        dt.Symptoms=Convert.ToString(sdr["Symptoms"]);
                        dt.AdmittedDate=Convert.ToDateTime(sdr["Admitted_Date"]);
                        dt.MedicalTest=Convert.ToString(sdr["Medical_Test"]);
                        dt.DischargedDate=Convert.ToDateTime(sdr["Discharged_Date"]);
                        dt.Address=Convert.ToString(sdr["Address_"]);
                        dt.MblNo=Convert.ToString(sdr["Mbl_No"]);
                        detailList.Add(dt);
                    }
                    connection.Close();
                }

            }
            return View(detailList);
        }
        [HttpGet]
        public ActionResult Create() 
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Detail detail)
        {
            string connectionString = Configuration["ConnectionStrings:PatientConnection"];
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = $"Insert Into Detail(PatientName,Symptoms,Admitted_Date,Medical_Test,Discharged_Date,Address_,Mbl_No) Values ('{detail.PatientName}','{detail.Symptoms}','{detail.AdmittedDate}','{detail.MedicalTest}','{detail.DischargedDate}','{detail.Address}','{detail.MblNo}')";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
            ViewBag.Result = "Success";
            return RedirectToAction("Index");
            
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            Detail detail = new Detail();
            string connectionString = Configuration["ConnectionStrings:PatientConnection"];
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                Console.WriteLine("Hi"+id);
                string sql = $"select * from Detail where PatientId='{id}'";
                SqlCommand cmd = new SqlCommand(sql, connection);
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        string format = "mm/dd/yyyy";
                        detail.PatientId=Convert.ToInt32(sdr["PatientId"]);
                        detail.PatientName=Convert.ToString(sdr["PatientName"]);
                        detail.Symptoms=Convert.ToString(sdr["Symptoms"]);
                        detail.AdmittedDate=Convert.ToDateTime(sdr["Admitted_Date"]);
                        detail.MedicalTest=Convert.ToString(sdr["Medical_Test"]);
                        detail.DischargedDate=Convert.ToDateTime(sdr["Discharged_Date"]);
                        detail.Address=Convert.ToString(sdr["Address_"]);
                        detail.MblNo=Convert.ToString(sdr["Mbl_No"]);

                    }
                    connection.Close();
                }

            }
            return View(detail);
        }

        [HttpPost]
        public IActionResult Update(Detail detail, int id)
        {
            string connectionString = Configuration["ConnectionStrings:PatientConnection"];
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = $"Update Detail SET PatientName='{detail.PatientName}',Symptoms='{detail.Symptoms}',Admitted_Date='{detail.AdmittedDate}',Medical_Test='{detail.MedicalTest}',Discharged_Date='{detail.DischargedDate}',Address_='{detail.Address}',Mbl_No='{detail.MblNo}' where PatientId='{id}'";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            Detail detail = new Detail();
            string connectionString = Configuration["ConnectionStrings:PatientConnection"];
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = $"select * from Detail where PatientId='{id}'";
                SqlCommand cmd = new SqlCommand(sql, connection);
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {

                        detail.PatientId=Convert.ToInt32(sdr["PatientId"]);
                        detail.PatientName=Convert.ToString(sdr["PatientName"]);
                        detail.Symptoms=Convert.ToString(sdr["Symptoms"]);
                        detail.AdmittedDate=Convert.ToDateTime(sdr["Admitted_Date"]);
                        detail.MedicalTest=Convert.ToString(sdr["Medical_Test"]);
                        detail.DischargedDate=Convert.ToDateTime(sdr["Discharged_Date"]);
                        detail.Address=Convert.ToString(sdr["Address_"]);
                        detail.MblNo=Convert.ToString(sdr["Mbl_No"]);

                    }
                    connection.Close();
                }

            }
            return View(detail);
        }

        [HttpPost]
        public IActionResult Delete(Detail dt,int id)
        {
            string connectionString = Configuration["ConnectionStrings:PatientConnection"];
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = $"Delete from Detail where PatientId='{dt.PatientId}'";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public IActionResult Detail(int id)
        {
            Detail detail = new Detail();
            string connectionString = Configuration["ConnectionStrings:PatientConnection"];
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = $"select * from Detail where PatientId='{id}'";
                SqlCommand cmd = new SqlCommand(sql, connection);
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        detail.PatientId=Convert.ToInt32(sdr["PatientId"]);
                        detail.PatientName=Convert.ToString(sdr["PatientName"]);
                        detail.Symptoms=Convert.ToString(sdr["Symptoms"]);
                        detail.AdmittedDate=Convert.ToDateTime(sdr["Admitted_Date"]);
                        detail.MedicalTest=Convert.ToString(sdr["Medical_Test"]);
                        detail.DischargedDate=Convert.ToDateTime(sdr["Discharged_Date"]);
                        detail.Address=Convert.ToString(sdr["Address_"]);
                        detail.MblNo=Convert.ToString(sdr["Mbl_No"]);
                    }
                    connection.Close();
                }

            }
            return View(detail);
        }

        //User Login
        public static string connection = "Data Source=ICPU0076\\SQLEXPRESS;Initial Catalog=Patient;Persist Security Info=False;User ID=sa;Password=sql@123;Pooling=False;Multiple Active Result Sets=False;Encrypt=False;Trust Server Certificate=False;Command Timeout=0";
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(Detail dt)
        {
            using (var con = new SqlConnection(connection))
            {
                using (var cmd = new SqlCommand("select dbo.UserCheck(@PatientId,@PatientName)", con))
                {
                    cmd.Parameters.AddWithValue("@PatientId", dt.PatientId);
                    cmd.Parameters.AddWithValue("@PatientName", dt.PatientName);
                    con.Open();
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    if (count == 1)
                    {
                        int id = dt.PatientId;
                        return RedirectToAction("UserDetail", new { id });
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Patient name or Patient Id is incorrect or not found");
                        return View(dt);
                    }
                }
            }
        }

        [HttpGet]
        public IActionResult UserDetail(int id)
        {
            Detail detail = new Detail();
            string connectionString = Configuration["ConnectionStrings:PatientConnection"];
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = $"select * from Detail where PatientId='{id}'";
                SqlCommand cmd = new SqlCommand(sql, connection);
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        detail.PatientId=Convert.ToInt32(sdr["PatientId"]);
                        detail.PatientName=Convert.ToString(sdr["PatientName"]);
                        detail.Symptoms=Convert.ToString(sdr["Symptoms"]);
                        detail.AdmittedDate=Convert.ToDateTime(sdr["Admitted_Date"]);
                        detail.MedicalTest=Convert.ToString(sdr["Medical_Test"]);
                        detail.DischargedDate=Convert.ToDateTime(sdr["Discharged_Date"]);
                        detail.Address=Convert.ToString(sdr["Address_"]);
                        detail.MblNo=Convert.ToString(sdr["Mbl_No"]);
                    }
                    connection.Close();
                }
                return View(detail);
            }
            
        }

        [HttpGet]
        public IActionResult UserUpdate(int id)
        {
            Detail detail = new Detail();
            string connectionString = Configuration["ConnectionStrings:PatientConnection"];
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = $"select * from Detail where PatientId='{id}'";
                SqlCommand cmd = new SqlCommand(sql, connection);
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        string format = "mm/dd/yyyy";
                        detail.PatientId=Convert.ToInt32(sdr["PatientId"]);
                        detail.PatientName=Convert.ToString(sdr["PatientName"]);
                        detail.Symptoms=Convert.ToString(sdr["Symptoms"]);
                        detail.AdmittedDate=Convert.ToDateTime(sdr["Admitted_Date"]);
                        detail.MedicalTest=Convert.ToString(sdr["Medical_Test"]);
                        detail.DischargedDate=Convert.ToDateTime(sdr["Discharged_Date"]);
                        detail.Address=Convert.ToString(sdr["Address_"]);
                        detail.MblNo=Convert.ToString(sdr["Mbl_No"]);

                    }
                    connection.Close();
                }

            }
            return View(detail);
        }

        [HttpPost]
        public IActionResult UserUpdate(Detail detail,int id)
        {
            string connectionString = Configuration["ConnectionStrings:PatientConnection"];
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = $"Update Detail SET PatientName='{detail.PatientName}',Symptoms='{detail.Symptoms}',Admitted_Date='{detail.AdmittedDate}',Medical_Test='{detail.MedicalTest}',Discharged_Date='{detail.DischargedDate}',Address_='{detail.Address}',Mbl_No='{detail.MblNo}' where PatientId='{id}'";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    id = detail.PatientId;
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                    return RedirectToAction("UserDetail", new { id });
                }
               
            }
           
        }
    }
}