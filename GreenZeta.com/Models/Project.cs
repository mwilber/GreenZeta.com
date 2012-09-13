using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace GreenZeta.com.Models
{
    public class Project
    {
        public int          ProjectID { get; set; }
        public string       alias { get; set; }
        public string       title { get; set; }
        public string       caption { get; set; }
        public string       description { get; set; }
        public string       link { get; set; }
        public string       icon { get; set; }
        public DateTime     launchDate { get; set; }
        public virtual ICollection<ProjectTag> ProjectTags { get; set; }
        public virtual ICollection<ScreenShot> ScreenShots { get; set; }
    }
}