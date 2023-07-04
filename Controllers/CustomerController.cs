using Microsoft.AspNetCore.Mvc;
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
    }
}
