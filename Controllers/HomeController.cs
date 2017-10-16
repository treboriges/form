using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Form;
using DbConnection;
using Form.Models;

namespace Form.Controllers
{
    public class HomeController : Controller
    {
        private readonly DbConnector _dbConnector;

        public HomeController(DbConnector connect)
        {
            _dbConnector = connect;
        }

        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            // List<Dictionary<string, object>> AllUsers = _dbConnector.Query("SELECT * FROM users");
            ViewBag.errors = ModelState.Values;
            return View("index");
            // Other code
        }
        [HttpPost]
        [Route("process")]
        public IActionResult Method(string first_name, string last_name, int age, string email_address, string password)
        {
            User NewUser = new User
            {
                first_name = first_name,
                last_name = last_name,
                age = age,
                email_address = email_address,
                password = password
            };
            if (TryValidateModel(NewUser) == false)
            {
                ViewBag.errors = ModelState.Values;
                return View("Index");
            }
            else{
                return RedirectToAction("success");
            }
            ;

        }
        [HttpGet]
        [Route("success")]
        public IActionResult Success()
        {
            return View("method");
        }
    }
}
