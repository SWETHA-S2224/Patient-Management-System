using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using PatientManagement.Models;
using System;

namespace PatientManagement.Controllers
{
    public class SignUpController : Controller
    {
        private readonly PatientContext _context;

        public SignUpController(PatientContext context)
        {
            _context = context;
        }
        
        
    }
}

