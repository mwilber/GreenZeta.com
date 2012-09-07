using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace GreenZeta.com.Models
{
    public class ProjectTag
    {
        public int id { get; set; }
        public int projectId { get; set; }
        public int tagId { get; set; }
    }

    public class ProjectTagDBContext : DbContext
    {
        public DbSet<ProjectTag> ProjectTags { get; set; }
    }
}