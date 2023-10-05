using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using FilterRLC.Models;
namespace FilterRLC.Controllers
{
    public class FilterController : Controller
    {
        private static FilterParams selectedFilter;
        public static int ID;
        [HttpGet]
        public IActionResult FilterForm()
        {
            return View();
        }
        [HttpPost]
        public IActionResult FilterForm(FilterParams filterParams)
        {
            if (ModelState.IsValid)
            {
                filterParams.ID = Repository.Filters.Count();
                Repository.AddFilter(filterParams);
                return View("Confirmation", filterParams);
            }
            else
            {
                return View();
            }
        }
        [HttpGet]
        public IActionResult FilterEdit(int id)
        {

                ID = id;
                FilterParams filter_copy = Repository.Filters.Where(elem => elem.ID == id).
                Select(item => item).First();
                FilterParams filter = Repository.Filters.Where(elem => elem.ID == id).
                Select(item => item).First();
                Repository.DeleteFilter(filter);
                return View();


        }
        [HttpPost]
        public IActionResult FilterEdit(FilterParams filterParams)
        {
            if (ModelState.IsValid)
            {
                Repository.EditFilter(filterParams, ID);
                return View("Confirmation_edit", filterParams);
            }
            else
            {
                return View();
            }

        }
        public IActionResult ListFilters()
        {
            return View(Repository.Filters);
        }
        public IActionResult Waveform(int id)
        {
            FilterParams filter = Repository.Filters.Where(elem => elem.ID == id).
            Select(item => item).First();
            selectedFilter = filter;
           
            return View(filter);
        }
        public ViewResult Delete(int id)
        {
            FilterParams filter = Repository.Filters.Where(elem => elem.ID == id).
            Select(item => item).First();
            Repository.DeleteFilter(filter);
            return View(filter);
        }
        [HttpPost]
        public JsonResult JsonData2()
        {
            var results = Transmittance.GetTransmittance(selectedFilter);
            return Json(results);
        }
        [HttpPost]
        public JsonResult JsonData()
        {
            var results = Transmittance.Envelope(selectedFilter);
            return Json(results);
        }
        public IActionResult Welcome(string name, int number = 1)
        {
            ViewData["Message"] = "Hello " + name;
            ViewData["NumTimes"] = number;
            return View();
        }
    }
}