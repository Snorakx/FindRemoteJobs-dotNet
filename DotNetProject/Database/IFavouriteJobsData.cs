using DotNetProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetProject.Database
{
    public interface IFavouriteJobsData
    {
        UserFavouriteJob Add(UserFavouriteJob newUserFavouriteJob);
        UserFavouriteJob Delete(int jobId, string username);
        UserFavouriteJob GetByUsernameAndId(int jobId, string username);
        IEnumerable<UserFavouriteJob> GetJobsByUsername(string username);
        int Commit();
    }
}
