using DotNetProject.Models;
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
        
        public DbSet<UserFavouriteJob> UserFavouriteJob { get; set; }
        public DotNetDbContext(DbContextOptions<DotNetDbContext> options)
            : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<UserFavouriteJob>()
                .HasKey(c => new { c.JobId, c.UserId });

        }
    }
}
