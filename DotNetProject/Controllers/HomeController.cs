using DotNetProject.Database;
using DotNetProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace DotNetProject.Controllers
{
    public class HomeController : Controller
    {

    
       
        private readonly ILogger<HomeController> _logger;
        private readonly IFavouriteJobsData favouriteJobsData;

        public HomeController(ILogger<HomeController> logger, IFavouriteJobsData favouriteJobsData)
        {
            _logger = logger;

            this.favouriteJobsData = favouriteJobsData;
        }

        public async Task<IActionResult> Index(string searchString)
        {
            JobsListModel JobList = new JobsListModel();
            using (var httpClient = new HttpClient())
            {
                var apiUrl = searchString != null ? $"https://remotive.io/api/remote-jobs?search={searchString}" : $"https://remotive.io/api/remote-jobs?limit=10";
                using (var response = await httpClient.GetAsync(apiUrl))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                     JobList = JsonConvert.DeserializeObject<JobsListModel>(apiResponse);
                }
            }
            return View(JobList);
        }

        public IActionResult AddToFavourite(string url, string title, string category, int id )
        {
            var job = new UserFavouriteJob(User.Identity.Name, id, title, category, url );
            favouriteJobsData.Add(job);
            var commit = favouriteJobsData.Commit();
            if(commit == 0)
            {
                ViewBag.Message = "ERROR";
                return View("Error");
            }
                return RedirectToAction("Index");
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
