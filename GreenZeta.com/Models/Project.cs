using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace GreenZeta.com.Models
{
    public class Project
    {
        public int          id { get; set; }
        public string       alias { get; set; }
        public string       title { get; set; }
        public string       caption { get; set; }
        public string       description { get; set; }
        public string       link { get; set; }
        public DateTime     launchDate { get; set; }
    }

    public class ProjectDBContext : DbContext
    {
        public DbSet<Project> Projects { get; set; }
    }
}