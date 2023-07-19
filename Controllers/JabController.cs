using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Data;
using Test.Models;

namespace Test.Controllers
{
    public class JabController : Controller
    {
        private readonly TestDBcontext ctx;

        public JabController(TestDBcontext ctx)
        {
            this.ctx = ctx;
        }

        // GET: JabController
        public ActionResult Index()
        {
            List<Jab> jabs = ctx.Jabs.ToList();
            return View(jabs);
        }

        // GET: JabController/Details/5
        public ActionResult Details(int id)
        {
            Jab jab = GetJab(id);
            return View(jab);
        }

        // GET: JabController/Create
        public ActionResult Create()
        {
            Jab jab = new Jab();
            return View(jab);
        }

        // POST: JabController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Jab jab)
        {
            try
            {
                ctx.Jabs.Add(jab);
                ctx.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: JabController/Edit/5
        public ActionResult Edit(int id)
        {
            Jab jab = GetJab(id);
            return View(jab);
        }

        // POST: JabController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Jab jab)
        {
            try
            {
                ctx.Jabs.Attach(jab);
                ctx.Entry(jab).State = EntityState.Modified;
                ctx.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: JabController/Delete/5
        public ActionResult Delete(int id)
        {
            Jab jab = GetJab(id);
            return View(jab);
        }

        // POST: JabController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Jab jab)
        {
            try
            {
                ctx.Jabs.Attach(jab);
                ctx.Entry(jab).State = EntityState.Deleted;
                ctx.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        private Jab GetJab(int id)
        {
            return ctx.Jabs.Where(t => t.Id == id).FirstOrDefault();
        }
    }
}
