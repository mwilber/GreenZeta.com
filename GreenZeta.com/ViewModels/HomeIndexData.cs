using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GreenZeta.com.Models;

namespace GreenZeta.com.ViewModels
{
    public class HomeIndexData
    {
        public IEnumerable<Tag> tagCloud { get; set; }
        public IEnumerable<Project> featuredProjects { get; set; }
    }
}