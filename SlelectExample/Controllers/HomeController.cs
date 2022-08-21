using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SlelectExample.Data;
using SlelectExample.Models;
using SlelectExample.ViewModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SlelectExample.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger )
        //{
        //    _logger = logger;
        //}
        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult List()
        {
            List<Customer> customers = _context.Customers
                .Include(c=>c.Country)
                .Include(cy => cy.State)
                .Include(cz=>cz.City)
                .ToList();
            return View(customers);
        }

        public IActionResult Create()
        {
            CustomerCreateModel customerCreateModel = new CustomerCreateModel();

            customerCreateModel.Customer = new Customer();
            List<SelectListItem> coutries = _context.Countries.OrderBy(n => n.CountryName).Select(n =>
            new SelectListItem
            {
                Value = n.CountryID.ToString(),
                Text = n.CountryName
            }).ToList();

            customerCreateModel.Countries = coutries;
            return View(customerCreateModel);


        }
        [HttpPost]
        public IActionResult Create(CustomerCreateModel cust)
        {
            _context.Add(cust.Customer);
            _context.SaveChanges();
            return RedirectToAction("List");
        }


        [HttpGet]
        public ActionResult GetState(int CountryID)
        {
            List<SelectListItem> statesSel = _context.States
                    .Where(c => c.CountryID == CountryID)
                    .OrderBy(n => n.StateName).Select(n =>
                      new SelectListItem
                      {
                          Value = n.StateID.ToString(),
                          Text = n.StateName
                      }
                    ).ToList();
            return Json(statesSel);
        }
        [HttpGet]
        public ActionResult GetCity(int StateID ,int CountryID)
        {
            List<SelectListItem> citiesSel = _context.Cities
                    .Where(c => c.StateID == StateID)
                    .OrderBy(n => n.CityName).Select(n =>
                      new SelectListItem
                      {
                          Value = n.CityID.ToString(),
                          Text = n.CityName
                      }
                    ).ToList();
            return Json(citiesSel);
        }
        

        public IActionResult Edit(int id)
        {
            
            CustomerCreateModel customerCreateModel = new CustomerCreateModel();

            customerCreateModel.Customer = new Customer();
            customerCreateModel.Customer = _context.Customers.Find(id);
            List<SelectListItem> coutries = _context.Countries.OrderBy(n => n.CountryName).Select(n =>
            new SelectListItem
            {
                Value = n.CountryID.ToString(),
                Text = n.CountryName
            }).ToList();


            List<SelectListItem> states = _context.States
                    .Where(c => c.CountryID == customerCreateModel.Customer.CountryID)
                    .OrderBy(n => n.StateName).Select(n =>
                      new SelectListItem
                      {
                          Value = n.StateID.ToString(),
                          Text = n.StateName
                      }
                    ).ToList();


            List<SelectListItem> cities = _context.Cities
                    .Where(c => c.StateID == customerCreateModel.Customer.StateID)
                    .OrderBy(n => n.CityName).Select(n =>
                      new SelectListItem
                      {
                          Value = n.CityID.ToString(),
                          Text = n.CityName
                      }
                    ).ToList();
            customerCreateModel.Countries = coutries;
            customerCreateModel.States = states;
            customerCreateModel.Cities = cities;
            
            return View(customerCreateModel);


        }
        [HttpPost]
        public IActionResult Edit(CustomerCreateModel cust)
        {
            _context.Update(cust.Customer);
            _context.SaveChanges();
            return RedirectToAction("List");
        }

        public IActionResult Details(int id)
        {
            var result = _context.Customers.Where(e => e.CustomerId == id).FirstOrDefault();

            var CountryName = _context.Countries.Where(e => e.CountryID == result.CountryID).FirstOrDefault();
            var StateName = _context.States.Where(e => e.StateID == result.StateID).FirstOrDefault();

            var CityName = _context.Cities.Where(e => e.CityID == result.CityID).FirstOrDefault();
            ViewBag.countryName = CountryName.CountryName;
            ViewBag.stateName = StateName.StateName;
            ViewBag.cityName = CityName.CityName;
            CustomerCreateModel customerCreateModel = new CustomerCreateModel();

            customerCreateModel.Customer = new Customer();
            customerCreateModel.Customer = _context.Customers.Find(id);
            

            return View(customerCreateModel);


        }
     
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _context.Customers.FindAsync(id);

                _context.Customers.Remove(result);
                await _context.SaveChangesAsync();
                return RedirectToAction("List");
         
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
