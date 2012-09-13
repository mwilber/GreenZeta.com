using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace GreenZeta.com.Models
{
    public class ProjectTag
    {
        public int ProjectTagID { get; set; }
        public int ProjectID { get; set; }
        public int TagID { get; set; }
        public virtual Project Project { get; set; }
        public virtual Tag Tag { get; set; }
    }

}