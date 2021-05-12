using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportsPro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsPro.Controllers
{
    public class IncidentController : Controller
    {
        private SportsProContext context { get; set; }

        public IncidentController(SportsProContext ctx)
        {
            context = ctx;

        }
        // GET: IncidentController
        public ActionResult Index()
        {
            var Incidents = context.Incidents.Include(c => c.Customer).Include(p=>p.Product).Include(t=>t.Technician).OrderBy(i => i.Title).ToList();
            return View(Incidents);
        }

        // GET: IncidentController/Details/5
        public ActionResult Details(int id)
        {
            var Incident = context.Incidents.Find(id);
            return View(Incident);
        }

        // GET: IncidentController/Create
        public ActionResult Create()
        {
            ViewBag.Customers = context.Customers.OrderBy(c => c.FirstName).ToList();
            ViewBag.Products = context.Products.OrderBy(p => p.Name).ToList();
            ViewBag.Technicians = context.Technicians.OrderBy(t => t.Name).ToList();
            return View();
        }

        // POST: IncidentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Incident collection)
        {
            try
            {
                context.Incidents.Add(collection);
                context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: IncidentController/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.Customers = context.Customers.OrderBy(c => c.FirstName).ToList();
            ViewBag.Products = context.Products.OrderBy(p => p.Name).ToList();
            ViewBag.Technicians = context.Technicians.OrderBy(t => t.Name).ToList();
            var Incident = context.Incidents.Find(id);
            return View(Incident);
        }

        // POST: IncidentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Incident collection)
        {
            try
            {
                context.Incidents.Update(collection);
                context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: IncidentController/Delete/5
        public ActionResult Delete(int id)
        {

            var Incident = context.Incidents.Find(id);
            return View(Incident);
        }

        // POST: IncidentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Incident collection)
        {
            try
            {
                context.Incidents.Remove(collection);
                context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
