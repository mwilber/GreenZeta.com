using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using GreenZeta.com.Models;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace GreenZeta.com.DAL
{
    public class PortfolioContext : DbContext
    {
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectTag> ProjectTags { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<ScreenShot> ScreenShots { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}