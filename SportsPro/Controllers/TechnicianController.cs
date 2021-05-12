using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SportsPro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsPro.Controllers
{
    public class TechnicianController : Controller
    {
        private SportsProContext context { get; set; }

        public TechnicianController(SportsProContext ctx)
        {
            context = ctx;
           
        }
        // GET: TechnicianController
        public ActionResult Index()
        {
            var technicians = context.Technicians.ToList();
            return View(technicians);
        }

        // GET: TechnicianController/Details/5
        public ActionResult Details(int id)
        {
            var technician = context.Technicians.Find(id);
            return View(technician);
        }

        // GET: TechnicianController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TechnicianController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Technician collection)
        {
            try
            {
                context.Technicians.Add(collection);
                context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TechnicianController/Edit/5
        public ActionResult Edit(int id)
        {
            var technician = context.Technicians.Find(id);
            return View(technician);
        }

        // POST: TechnicianController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Technician collection)
        {
            try
            {
                context.Technicians.Update(collection);
                context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TechnicianController/Delete/5
        public ActionResult Delete(int id)
        {

            var technician = context.Technicians.Find(id);
            return View(technician);
        }

        // POST: TechnicianController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Technician collection)
        {
            try
            {
                context.Technicians.Remove(collection);
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
