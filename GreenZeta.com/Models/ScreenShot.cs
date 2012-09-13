using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace GreenZeta.com.Models
{
    public class ScreenShot
    {
        public int ScreenShotID { get; set; }
        public string url { get; set; }
        public string caption { get; set; }
        public int ProjectID { get; set; }
        public virtual Project Project { get; set; }
    }

}