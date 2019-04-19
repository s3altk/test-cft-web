using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using TestCft.Models;

namespace TestCft.Controllers
{
    public class AppsController : Controller
    {
        private readonly DbModel _context;

        public AppsController(DbModel context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Info(Guid id)
        {
            var app = _context.Apps.Include(p => p.Requests).FirstOrDefault(p => p.Id == id);

            return PartialView(app);
        }
    }
}