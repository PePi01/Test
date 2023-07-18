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
        }public ActionResult Custom(int id)
        {
            Pet pet = GetPet(id);
            return View(pet);
        }

        // GET: PetController/Details/5
        public ActionResult Details(int id)
        {
            Pet pet = GetPet(id);
            return View(pet);
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
            Pet pet = GetPet(id);
            return View(pet);
        }

        // POST: PetController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Pet pet)
        {
            try
            {
                ctx.Pets.Attach(pet);
                ctx.Entry(pet).State = EntityState.Modified;
                ctx.SaveChanges();
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
            Pet pet = GetPet(id);
            return View(pet);
        }

        // POST: PetController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Pet pet)
        {
            try
            {
                ctx.Pets.Attach(pet);
                ctx.Entry(pet).State = EntityState.Deleted;
                ctx.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        private Pet GetPet(int id)
        {
            return ctx.Pets.Where(t => t.Id == id).FirstOrDefault();
        }
    }
}
