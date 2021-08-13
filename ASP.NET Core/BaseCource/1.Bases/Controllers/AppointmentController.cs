using Microsoft.AspNetCore.Mvc;
using System;

namespace _1.Bases.Controllers
{
    public class AppointmentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Details(int id)
        {
            return Ok($"You have entered id = {id}");
        }
    }
}
