using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetProject.Database
{
    public class DotNetDbContext : IdentityDbContext
    {
        public DotNetDbContext(DbContextOptions<DotNetDbContext> options)
            : base(options)
        {

        }
    }
}
