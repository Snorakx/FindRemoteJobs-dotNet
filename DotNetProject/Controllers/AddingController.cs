using DotNetProject.Database;
using DotNetProject.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AddingController : ControllerBase
    {
        private readonly IFavouriteJobsData favouriteJobsData;

        public AddingController(IFavouriteJobsData favouriteJobsData)
        {
            this.favouriteJobsData = favouriteJobsData;
        }

        public AddNewItemResponse Post(JobModel job)
        {
            var userFavouriteJob = new UserFavouriteJob
            {

                UserId = User.Identity.Name,
                JobId = job.Id,
                Title = job.Title,
                Category = job.Category,
                Url = job.Url

            };
          

            favouriteJobsData.Add(userFavouriteJob);

            var response = new AddNewItemResponse();

           var x = favouriteJobsData.Commit();
            if(x == 1)
            {
                response = new AddNewItemResponse()
                {
                    success = true,
                    addedJob = userFavouriteJob
                };
            }
            else
            {
                response = new AddNewItemResponse()
                {
                    success = false,
                    addedJob = userFavouriteJob
                };
            }

             


                return response;
          
        }

    }
}
