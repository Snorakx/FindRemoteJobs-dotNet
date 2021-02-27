using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetProject.Models
{

    public class AddNewItemResponse
    {
        public bool success { get; set; }

        public UserFavouriteJob addedJob { get; set; }
    }
}
