using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab4.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lab4.Controllers
{
    public class CityController : Controller
    {
        // GET: CityController
        public ActionResult Index()
        {
            var context = new worldContext();
            return View(context.City.ToList());
        }

        // GET: CityController/Details/5
        public ActionResult Detail(int id)
        {
            var context = new worldContext();
            if (id == null)
            {
                return NotFound();
            }
            var city = context.City.FirstOrDefault(c => c.Id.Equals(id));
            if (city == null)
            {
                return NotFound();
            }

            return View(city);
        }

        public ActionResult AddorEdit(int id)
        {
            var context = new worldContext();
            if (id == 0)
            {
                ViewBag.ListCountry = context.Country.ToList();
                return View(new City());
            }
            else
            {
                ViewBag.ListCountry = context.Country.ToList();
                return View(context.City.Find(id));
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddorEdit([Bind("Name, CountryCode, District, Population")] City city)
        {
            var context = new worldContext();
            var currentCity = context.City.Where(c => c.Name.Equals(city.Name)).FirstOrDefault();
            if (ModelState.IsValid)
            {
                if (currentCity == null)
                {
                    context.Add(city);
                }
                else
                {
                    currentCity.Name = city.Name;
                    currentCity.CountryCode = city.CountryCode;
                    currentCity.District = city.District;
                    currentCity.Population = city.Population;
                    context.Update(currentCity);
                }
                await context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(city);
        }

        // GET: CityController/Delete/5
        public ActionResult Delete(int id)
        {
            var context = new worldContext();
            if (id == 0)
            {
                return NotFound();
            }
            var city = context.City.FirstOrDefault(c => c.Id.Equals(id));
            if (city == null)
            {
                return NotFound();
            }

            return View(city);
        }

        // POST: CityController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int? id)
        {
            try
            {
                var context = new worldContext();
                if (id == 0)
                {
                    return NotFound();
                }
                var city = context.City.FirstOrDefault(c => c.Id == id);
                context.City.Remove(city);
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
