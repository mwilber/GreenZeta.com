using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using GreenZeta.com.Models;

namespace GreenZeta.com.DAL
{
    public class PortfolioInitializer : DropCreateDatabaseIfModelChanges<PortfolioContext>
    {
        protected override void Seed(PortfolioContext context)
        {
            var projects = new List<Project>
            {
                new Project {alias = "nrns",title = "Arby's Need a Reuben Now Syndrome",caption = "Custom facebook app built to promote Arby's Reuben sandwich.",description = "Custom facebook app built to promote Arby's Reuben sandwich. Features a quiz, background coupon printing, and youtube video carousel.",link = "http://www.facebook.com/arbys/app_379499542065071",icon = "nrns.jpg",launchDate = DateTime.Parse("2012-02-10")},
                new Project { 
                                alias = "bca", 
                                title = "Estée Lauder Breast Cancer Awareness",
                                caption = "Facebook app built for the Estée Lauder Companies' Breast Cancer Awareness Campaign 2011.",
                                description = "Custom facebook app built for the Estée Lauder Companies' Breast Cancer Awareness Campaign 2011. This app had a world wide release, in 14 languages, featured in over 40 facebook pages and received over 10,000 posts in the first week. Posts are geocoded based on the user's facebook location and displayed in a google map. Included back-end administration for moderating posts and managing events.",
                                link = "http://apps.facebook.com/esteebcaen/",
                                icon = "bca.jpg",
                                launchDate = DateTime.Parse("2012-02-10") 
                            },
                new Project { 
                                alias = "pgatlas", 
                                title = "PG Atlas: Mapping",
                                caption = "Redesign of PGAtlas.com, a web based GIS tool used by staff and REALTORS for Prince George County, Maryland.",
                                description = "Redesign of PGAtlas.com, a web based GIS tool used by staff and REALTORS for Prince George County, Maryland. Site was brought up to modern standards including ArcServer 9.3, ESRI JavaScript API, custom web services in asp.net, an AJAX based front-end and an improved user interface.",
                                link = "http://162.84.98.237/pgatlas/Default_Mapping.aspx",
                                icon = "pgatlas.jpg",
                                launchDate = DateTime.Parse("2009-10-30") 
                            }
            };
            projects.ForEach(s => context.Projects.Add(s));
            context.SaveChanges();

            var tags = new List<Tag>
            {
                new Tag { name = "Click3X", type="client" },
                new Tag { name = "Northrop Grumman", type="client" },
                new Tag { name="Facebook", type="medium" },
                new Tag { name="WebSite", type="medium" }
            };
            tags.ForEach(s => context.Tags.Add(s));
            context.SaveChanges();

            var projectTags = new List<ProjectTag>
            {
                new ProjectTag { ProjectID = 1, TagID = 1 },
                new ProjectTag { ProjectID = 1, TagID = 3 },
                new ProjectTag { ProjectID = 2, TagID = 1 },
                new ProjectTag { ProjectID = 2, TagID = 3 },
                new ProjectTag { ProjectID = 3, TagID = 2 },
                new ProjectTag { ProjectID = 3, TagID = 4 },
            };
            projectTags.ForEach(s => context.ProjectTags.Add(s));
            context.SaveChanges();

            var screenShots = new List<ScreenShot>
            {
                new ScreenShot { caption = "Photo 1", url = "nrns/nrns1.jpg", ProjectID = 1 },
                new ScreenShot { caption = "Photo 2", url = "nrns/nrns2.jpg", ProjectID = 1 },
                new ScreenShot { caption = "Photo 3", url = "nrns/nrns3.jpg", ProjectID = 1 },
                new ScreenShot { caption = "Photo 4", url = "nrns/nrns4.jpg", ProjectID = 1 }
            };
            screenShots.ForEach(s => context.ScreenShots.Add(s));
            context.SaveChanges();
        }
    }
}