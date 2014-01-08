using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using GreenZeta.com.Models;

namespace GreenZeta.com.ViewModels
{
    public class HomeDevData
    {
        public IEnumerable<Project> tagCloud { get; set; }
        public IEnumerable<Project> featuredProjects { get; set; }
        public IEnumerable<Project> featuredProduct { get; set; }
        public IEnumerable<Project> Products { get; set; }

        public ArrayList arrGamma { get; set; }
    }
}