using DotNetProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetProject.Database
{
    public class SqlFavouriteJobsData : IFavouriteJobsData
    {

        private readonly DotNetDbContext dotNetDbContext;

        public SqlFavouriteJobsData(DotNetDbContext dotNetDbContext)
        {
            this.dotNetDbContext = dotNetDbContext;
        }

        public UserFavouriteJob Add(UserFavouriteJob newUserFavouriteJob)
        {
            dotNetDbContext.Add(newUserFavouriteJob);
            return newUserFavouriteJob;
        }

        public int Commit()
        {
            try
            {
               return dotNetDbContext.SaveChanges();
            }
            catch (Exception e)
            {
                return 0;
            }
        }

        public UserFavouriteJob Delete(int jobId, string username)
        {
            var userFavouriteJob = GetByUsernameAndId(jobId, username);
            if (userFavouriteJob != null)
            {
                dotNetDbContext.UserFavouriteJob.Remove(userFavouriteJob);
            }
            return userFavouriteJob;
        }

        public IEnumerable<UserFavouriteJob> GetJobsByUsername(string username)
        {
            return dotNetDbContext.UserFavouriteJob.Where(x => x.UserId == username)
                                                 .Select(x=>x);
        }

        public UserFavouriteJob GetByUsernameAndId(int jobId, string username)
        {
            return dotNetDbContext.UserFavouriteJob.Where(x => x.JobId == jobId && x.UserId == username)
                                                 .FirstOrDefault();

        }
    }
}
