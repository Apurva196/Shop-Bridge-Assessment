using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCrudwithAPI.Models;

namespace MvcCrudwithAPI.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product/Index
        public ActionResult Index()
        {
            using (DbModel dbModel = new DbModel())
            {
                return View(dbModel.Products.ToList());
            }
        }

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            using (DbModel dbModel = new DbModel())
            {
                return View(dbModel.Products.Where(x => x.ProductID == id).FirstOrDefault());
            }
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // TODO: Add insert logic here
                    using (DbModel dbModel = new DbModel())
                    {
                        {
                            dbModel.Products.Add(product);
                            dbModel.SaveChanges();
                        }
                    }
                    return RedirectToAction("Index");
                }
                catch(Exception ex)
                {
                    return View(ex.Message);
                }
            }
            ModelState.AddModelError(" ", "Error");
            return View();
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            using (DbModel dbModel = new DbModel())
            {
                return View(dbModel.Products.Where(x => x.ProductID == id).FirstOrDefault());
            }
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Product product)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // TODO: Add update logic here
                    using (DbModel dbModel = new DbModel())
                    {
                        dbModel.Entry(product).State = EntityState.Modified;
                        dbModel.SaveChanges();
                    }
                    return RedirectToAction("Index");
                }
                catch(Exception ex)
                {
                    return View(ex.Message);
                }
            }
            ModelState.AddModelError(" ", "Error");
            return View();

        }

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            using (DbModel dbModel = new DbModel())
            {
                return View(dbModel.Products.Where(x => x.ProductID == id).FirstOrDefault());
            }
        }

        // POST: Product/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // TODO: Add update logic here
                    using (DbModel dbModel = new DbModel())
                    {
                        Product product = dbModel.Products.Where(x => x.ProductID == id).FirstOrDefault();
                        dbModel.Products.Remove(product);
                        dbModel.SaveChanges();
                    }
                    return RedirectToAction("Index");
                }
                catch(Exception ex)
                {
                    return View(ex.Message);
                }
            }
            ModelState.AddModelError(" ", "Error");
            return View();
        }
    }
}
