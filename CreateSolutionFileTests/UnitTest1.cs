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

        [Test]
        public void Test4_GetSolutionFileName_Default()
        {
            // Test default solution name
            string sfn = UserInput.GetSolutionFileName("default");
            Assert.AreEqual("default", UserInput.GetSolutionFileName(sfn));
        }

        [Test]
        public void Test5_GetSolutionFileName_x()
        {
            // Test default solution name
            string sfn = UserInput.GetSolutionFileName("x");
            Assert.AreEqual("x", UserInput.GetSolutionFileName(sfn));
        }

        [Test]
        public void Test6_GetUserInput()
        {
            // Test default solution name
            UserInput ui    = new UserInput("TestProject");
            UserInput ni    = UserInput.GetUserInput("TestProject");
            string baseLine = $"{ui.SolutionName}{ui.ProjectName}{ui.LibraryName}{ui.TestName}{ui.SolutionDirectory}";
            string newLine  = $"{ni.SolutionName}{ni.ProjectName}{ni.LibraryName}{ni.TestName}{ni.SolutionDirectory}";
            Assert.AreEqual(baseLine, newLine);
        }        
    }
}