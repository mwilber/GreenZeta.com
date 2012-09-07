using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace GreenZeta.com.Models
{
    public class ScreenShot
    {
        public int id { get; set; }
        public string url { get; set; }
        public string caption { get; set; }
        public int projectId { get; set; }
    }

    public class ScreenShotDBContext : DbContext
    {
        public DbSet<ScreenShot> ScreenShots { get; set; }
    }
}