using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace GreenZeta.com.Models
{
    public class Tag
    {
        public int id { get; set; }
        public string name { get; set; }
        public string type { get; set; }
    }

    public class TagDBContext : DbContext
    {
        public DbSet<Tag> Tags { get; set; }

        public DbSet<ProjectTag> ProjectTags { get; set; }
    }
}