using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab4.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace Lab4.Controllers
{
    public class CountryController : Controller
    {
        // GET: CountryController
        public ActionResult Index()
        {
            var context = new worldContext();
            var list = context.Country.ToList();
            var list2 = new List<Country>();
            foreach (Country country in list)
            {
                country.NationalFlag = convertPath(country);
                list2.Add(country);
            }
            return View(list2);
        }

        // GET: CountryController/Details/5
        public ActionResult Detail(string id)
        {
            var context = new worldContext();
            if (id == null)
            {
                return NotFound();
            }
            var country = context.Country.FirstOrDefault(c => c.Code.Equals(id));
            country.NationalFlag = convertPath(country);
            if (country == null)
            {
                return NotFound();
            }

            return View(country);
        }

        public ActionResult AddorEdit(string id)
        {
            var context = new worldContext();
            if (id == null || id.Length == 0)
            {
                return View(new Country());
            }
            else
            {
                return View(context.Country.Find(id));
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddorEdit([Bind("Code, Name, Region, NationalFlag")] Country country)
        {
            var context = new worldContext();
            var currentCountry = context.Country.Find(country.Code);
            if (ModelState.IsValid)
            {
                if (currentCountry == null)
                {
                    context.Add(country);
                }
                else
                {
                    currentCountry.Name = country.Name;
                    currentCountry.Region = country.Region;
                    currentCountry.NationalFlag = country.NationalFlag;
                    context.Update(currentCountry);
                }
                await context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(country);
        }

        // GET: CountryController/Delete/5
        public ActionResult Delete(string id)
        {
            var context = new worldContext();
            if (id == null)
            {
                return NotFound();
            }
            var country = context.Country.FirstOrDefault(c => c.Code.Equals(id));
            context.Country.Remove(country);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private string convertPath(Country country)
        {
            var path = country.NationalFlag.Replace('\\', '/');
            var host = Request.GetDisplayUrl().Split("Country");
            var fullPath = host[0] + path;
            return fullPath;
        }
    }
}
