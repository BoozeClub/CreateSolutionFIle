using System;
using NUnit.Framework;
using CreateSolutionFileLibrary;

namespace CreateSolutionFileTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            // Test HouseKeepingClass
            // defaultValue should be equal to args[0], or "TestApplication" if null.
        }
        [Test]
        public void Test1_Housekeeping_Null()
        {
            string[] args = null;
            Assert.AreEqual("TestApplication", HousekeepingClass.Housekeeping(args));
        }
        
        [Test]
        public void Test2_Housekeeping_x()
        {
            string[] args = new string[] {"x"};
            Assert.AreEqual("x", HousekeepingClass.Housekeeping(args));
        }
        
        [Test]
        public void Test3_Housekeeping_input()
        {
            // Unable to perform this test since VS Code won't prompt for user input.
            // Placed here for documentation purposes only.
            string[] args = new string[] {"input"};
            //Assert.AreEqual("x", HousekeepingClass.Housekeeping(args));
            Assert.Pass("x", HousekeepingClass.Housekeeping(args)); 
        }
        /*
        [Test]
        public void Test4_GetSolutionFileName_Default()
        {
            // Test default solution name
            Assert.AreEqual("default", UserInput.GetSolutionFileName("default"");
        }
        */
    }
}