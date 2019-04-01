using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace catalyst_project
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //Seed the database
            PeopleContext context = new PeopleContext();

            //if there aren't any users in the database, add a few test users
            if(context.People.ToList().Count == 0)
            {
                Person p1 = new Person();
                p1.Id = 1;
                p1.Name = "Bob";
                p1.Address = "Fancy Street, 1 London Way, UK";
                p1.Age = 57;
                p1.Interests = "Eating fancy tuna with a fancy little fork.";
                p1.ImagePath = "/Content/Images/fine-gentleman.jpg";

                Person p2 = new Person();
                p2.Id = 2;
                p2.Name = "Alice";
                p2.Address = "No where near Bob, that fancy pants is insufferable.";
                p2.Age = 45;
                p2.Interests = "The simple pleasures in life.";
                p2.ImagePath = "/Content/Images/alice.jpg";

                context.People.Add(p1);
                context.People.Add(p2);
                context.SaveChanges();
            }
        }
    }
}
