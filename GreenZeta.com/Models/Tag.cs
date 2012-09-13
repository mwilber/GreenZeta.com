using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace GreenZeta.com.Models
{
    public class Tag
    {
        public int TagID { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public virtual ICollection<ProjectTag> ProjectTags { get; set; }
    }

}