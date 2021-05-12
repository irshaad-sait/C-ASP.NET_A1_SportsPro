using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportsPro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsPro.Controllers
{
    public class CustomerController : Controller
    {
        private SportsProContext context { get; set; }

        public CustomerController(SportsProContext ctx)
        {
            context = ctx;

        }
        // GET: CustomerController
        public ActionResult Index()
        {
            var Customers = context.Customers.Include(c => c.Country).OrderBy(c=>c.LastName).ToList();
            return View(Customers);
        }

        // GET: CustomerController/Details/5
        public ActionResult Details(int id)
        {
            ViewBag.Countries = context.Countries.OrderBy(c => c.Name).ToList();
            var Customer = context.Customers.Find(id);
            return View(Customer);
        }

        // GET: CustomerController/Create
        public ActionResult Create()
        {
            ViewBag.Countries = context.Countries.OrderBy(c => c.Name).ToList();
            return View();
        }

        // POST: CustomerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Customer collection)
        {
            try
            {
                context.Customers.Add(collection);
                context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomerController/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.Countries = context.Countries.OrderBy(c => c.Name).ToList();
            var Customer = context.Customers.Find(id);
            return View(Customer);
        }

        // POST: CustomerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Customer collection)
        {
            try
            {
                context.Customers.Update(collection);
                context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomerController/Delete/5
        public ActionResult Delete(int id)
        {

            var Customer = context.Customers.Find(id);
            return View(Customer);
        }

        // POST: CustomerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Customer collection)
        {
            try
            {
                context.Customers.Remove(collection);
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
