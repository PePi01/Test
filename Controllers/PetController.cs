using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Data;
using Test.Models;

namespace Test.Controllers
{
    public class PetController : Controller
    {
        private readonly TestDBcontext ctx;

        public PetController(TestDBcontext ctx)
        {
            this.ctx = ctx;
        }

        // GET: PetController
        public ActionResult Index()
        {
            List<Pet> pets = ctx.Pets.ToList();
            return View(pets);
        }

        // GET: PetController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }


        //--
        

        //--
        // GET: PetController/Create
        public ActionResult Create()
        {
            Pet pet = new Pet();
            return View(pet);
        }

        // POST: PetController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Pet pet)
        {
            try
            {
                ctx.Pets.Add(pet);
                ctx.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PetController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PetController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PetController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PetController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
