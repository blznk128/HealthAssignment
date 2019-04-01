using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace catalyst_project.Controllers
{
    public class PeopleController : ApiController
    {
        private PeopleContext context;

        public PeopleController(){
            context = new PeopleContext();
        }
        
        public List<Person> Get()
        {
            return context.People.ToList();
            
        }

        [Route("api/people/{searchText}")]
        public List<Person> Get(string searchText)
        {
            return context.People.Where(p => p.Name.Contains(searchText)).ToList();
        }

        public void Post(Person p){
            context.People.Add(p);
            context.SaveChanges();
        }

        public void Delete()
        {
            List<Person> allPeople = context.People.ToList();
            context.People.RemoveRange(allPeople);
            context.SaveChanges();
        }
    }
}
