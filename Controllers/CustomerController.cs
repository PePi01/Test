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
    public class CustomerController : Controller
    {
        private readonly TestDBcontext ctx;

        public CustomerController(TestDBcontext context)
        {
            ctx = context;
        }
        public IActionResult Index()
        {
            List<Customer> customers = ctx.Customers.ToList();
            return View(customers);
        }
        // /Views/Customer/Create.cshtml /Views/Shared/Create.cshtml

        public ActionResult Details(int id)
        {
            Customer cus = GetCustomer(id);
            return View(cus);
        }

        public IActionResult Create()
        {
            Customer customer = new Customer();
            return View(customer);
        }

        [HttpPost]
        public IActionResult Create(Customer customer)
        {
            ctx.Customers.Add(customer);
            ctx.SaveChanges();

            return RedirectToAction(nameof(Index));
        }


        public IActionResult Edit(int id)
        {
            Customer cus = GetCustomer(id);
            return View(cus);
        }
        [HttpPost]
        public IActionResult Edit(Customer customer)
        {
            ctx.Customers.Attach(customer);
            ctx.Entry(customer).State = EntityState.Modified;
            ctx.SaveChanges();

            return RedirectToAction(nameof(Index));
        }


        public IActionResult Delete(int id)
        {
            Customer cus = GetCustomer(id);
            return View(cus);
        }
        [HttpPost]
        public IActionResult Delete(Customer customer)
        {
            ctx.Customers.Attach(customer);
            ctx.Entry(customer).State = EntityState.Deleted;
            ctx.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
        private Customer GetCustomer(int id)
        {
            return ctx.Customers.Where(t => t.Id == id).FirstOrDefault();
        }
    }
}
