using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using catalyst_project.Controllers;
using catalyst_project;
using System.Collections.Generic;

namespace CatalystUnitTests
{
    [TestClass]
    public class TestPeopleController
    {
        private static Person tp1;

        [ClassInitialize]
        public static void Initialize(TestContext tc)
        {
            tp1 = new Person();
            tp1.Name = "test user";
            tp1.Age = 22;
            tp1.Interests = "mundane list of interests";
            tp1.ImagePath = "not relevant";
            tp1.Id = 1;
            tp1.Address = "Somwhere in the world";
        }

        
        [TestMethod]
        public void TestBasicGet()
        {
            PeopleController pc = new PeopleController();
            pc.Delete();
            pc.Post(tp1);
            Person returnedPerson = pc.Get("test")[0];

            Assert.AreEqual(tp1.Name, returnedPerson.Name, "Name of returned person did not match expectation");
        }

        [TestMethod]
        public void TestMisMatchGet()
        {
            PeopleController pc = new PeopleController();
            pc.Delete();

            pc.Post(tp1);
            List<Person> returnedPersonList = pc.Get("doesn't match");

            Assert.AreEqual(0, returnedPersonList.Count, "Got return results with a mismatched search query. Expecting no responses.");
        }
    }
}
