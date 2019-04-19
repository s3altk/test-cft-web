using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using TestCft.Models;
using TestCft.ViewModels;

namespace TestCft.Controllers
{
    public class RequestsController : Controller
    {
        private readonly DbModel _context;

        public RequestsController(DbModel context)
        {
            _context = context;
        }

        [Route("")]
        [Route("/requests")]
        public IActionResult Get(int page = 1)
        {
            var requestIndexView = new RequestIndexView()
            {
                RequestsPerPage = 10,
                CurrentPage = page,
                Requests = _context.Requests
            };

            return View(requestIndexView);
        }

        [Route("/requests/create")]
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Apps = _context.Apps;

            return View();
        }

        [HttpPost]
        public IActionResult Create(Request request)
        {
            if (ModelState.IsValid)
            {
                _context.Requests.Add(request);
                _context.SaveChanges();

                return RedirectToAction("Get");
            }

            ViewBag.Apps = _context.Apps;

            return View(request);
        }

        [Route("/requests/edit")]
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Apps = _context.Apps;

            var request = _context.Requests.Include(p => p.App).FirstOrDefault(p => p.Id == id);

            return View(request);
        }

        [HttpPost]
        public IActionResult Edit(Request request)
        {
            if (ModelState.IsValid)
            {
                _context.Requests.Update(request);
                _context.SaveChanges();

                return RedirectToAction("Get");
            }

            ViewBag.Apps = _context.Apps;

            return View(request);
        }

        [HttpGet]
        public IActionResult Info(int id)
        {
            var request = _context.Requests.Include(p => p.App).FirstOrDefault(p => p.Id == id);

            return PartialView(request);
        }
    }
}