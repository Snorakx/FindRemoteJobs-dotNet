using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetProject.Models
{
    public class UserFavouriteJob
    {
   
        public string UserId { get; set; }

        public int JobId { get; set; }

        public string Title { get; set; }

        public string Category { get; set; }

        public string Url { get; set; }




        public UserFavouriteJob(string userId, int jobId, string title, string category, string url)
        {
            UserId = userId;
            
            JobId = jobId;

            Title = title;

            Category = category;

            Url = url;
        }
    }


}


