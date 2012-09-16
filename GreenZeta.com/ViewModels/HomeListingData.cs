using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GreenZeta.com.Models;

namespace GreenZeta.com.ViewModels
{
    public class HomeListingData
    {
        public IEnumerable<Project> projects { get; set; }
        public string tag { get; set; }
    }
}