using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MvcBrowserJobs.Models;
using Newtonsoft.Json;

namespace BrowserJobs.Controllers
{
    public class JobsController : Controller
    {
        public List<Jobs> lstJobs = null;
        public JobsController()
        {
            var myJsonString = System.IO.File.ReadAllText("Models/Jobs.json");
            lstJobs = JsonConvert.DeserializeObject<List<Jobs>>(myJsonString);
        }

        public IActionResult Index()
        {
            return View(lstJobs);
        }

        public IActionResult Find(string profesion, string departamento, string municipio)
        {
            List<Jobs> lstResultJobs = new List<Jobs>();
            lstResultJobs = lstJobs.Where(jobs => jobs.Profesion.ToLower().Contains(profesion.ToLower()))
            .Where(jobs => jobs.Departamento.ToLower().Contains(departamento.ToLower())).ToList(); 

            /* foreach (var item in lstJobs)
            {
                if(item.Profesion.ToLower().Contains(profesion.ToLower()) || item.Departamento.ToLower().Contains(departamento.ToLower()) || item.Municipio.ToLower().Contains(municipio.ToLower()))
                    lstResultJobs.Add(item);
            } */
            return View("Index", lstResultJobs);
        }

        public IActionResult Details(int id){

            foreach (var item in lstJobs)
            {
                if(item.Id == id)
                    return View(item);
            }
            return View(new Jobs());
        }
    }
}