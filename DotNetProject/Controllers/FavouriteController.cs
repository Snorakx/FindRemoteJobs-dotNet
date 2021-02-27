using DotNetProject.Database;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetProject.Controllers
{
    public class FavouriteController : Controller
    {
        private readonly IFavouriteJobsData favouriteJobsData;

        public FavouriteController(IFavouriteJobsData favouriteJobsData)
        {
            this.favouriteJobsData = favouriteJobsData;
        }

        public IActionResult Index()
        {
            var favouriteJobsList = favouriteJobsData.GetJobsByUsername(User.Identity.Name);

            return View(favouriteJobsList);
        }
        public IActionResult SearchJobs(string title)
        {
            var favouriteJobsList = favouriteJobsData.GetJobsByNameAndUsername(title, User.Identity.Name);

            return View("Index", favouriteJobsList);
        }
        public  IActionResult DeleteFavourite(int id)
        {
            favouriteJobsData.Delete(id, User.Identity.Name);
            
             favouriteJobsData.Commit();

            return RedirectToAction("Index");

        }
    }
}
