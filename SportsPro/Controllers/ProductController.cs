using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportsPro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsPro.Controllers
{
    public class ProductController : Controller
    {
        private SportsProContext context { get; set; }
        // GET: ProductManagerController
        public ProductController(SportsProContext ctx)
        {
            context = ctx;
        }

        public ActionResult Index()
        {
            var products = context.Products.ToList();
            return View(products);
        }

        // GET: ProductManagerController/Details/5
        public ActionResult Details(int id)
        {
            var products = context.Products.Find(id);
            return View(products);
        }

        // GET: ProductManagerController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductManagerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product collection)
        {
            try
            {
                context.Products.Add(collection);
                context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductManagerController/Edit/5
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var product = context.Products.Find(id);
            return View(product);
        }

        // POST: ProductManagerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Product collection)
        {
            try
            {
                context.Products.Update(collection);
                context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductManagerController/Delete/5
        public ActionResult Delete(int id)
        {
            var products = context.Products.Find(id);
            return View(products);
        }

        // POST: ProductManagerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Product collection)
        {
            try
            {
                //var product = context.Products.Find(id);
                context.Products.Remove(collection);
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
