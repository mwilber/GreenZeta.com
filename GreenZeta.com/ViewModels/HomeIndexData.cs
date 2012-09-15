using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GreenZeta.com.Models;

namespace GreenZeta.com.ViewModels
{
    public class HomeIndexData
    {
        public IEnumerable<Project> tagCloud { get; set; }
        public IEnumerable<Project> featuredProjects { get; set; }
        public IEnumerable<Project> featuredProduct { get; set; }
        public IEnumerable<Project> Products { get; set; }
    }
}