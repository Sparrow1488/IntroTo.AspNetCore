using _2.DbWork.Database;
using _2.DbWork.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace _2.DbWork.Controllers
{
    public class CarsController : Controller
    {
        private CarsDbContext _db;

        public CarsController(CarsDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Car> carsList = _db.Cars;
            return View(carsList);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Car car)
        {
            _db.Cars.Add(car);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
