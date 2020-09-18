using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarsTek.Data;
using MarsTek.Models;
using Microsoft.AspNetCore.Mvc;

namespace MarsTek.Controllers
{
    public class ServiceController : Controller
    {
        private readonly AppDbContext _context;

        public ServiceController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            IEnumerable<Service> objList = _context.Service;
            return View(objList);
        }
        // GET - Create
        public IActionResult Create()
        {
            return View();
        }

        // POST - Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Service obj)
        {
            if(ModelState.IsValid)
            {
                _context.Service.Add(obj);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        // GET - Edit
        public IActionResult Edit(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _context.Service.Find(id);
            if(obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }
        // POST - Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Service obj)
        {
            if (ModelState.IsValid)
            {
                _context.Service.Update(obj);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        // GET - Delete
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _context.Service.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }
        // POST - Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteService(int? id)
        {
            var obj = _context.Service.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
                _context.Service.Remove(obj);
                _context.SaveChanges();
                return RedirectToAction("Index");
        }
    }
}
