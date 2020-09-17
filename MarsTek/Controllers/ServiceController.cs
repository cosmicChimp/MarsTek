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
        public IActionResult Create()
        {
            return View();
        }
    }
}
