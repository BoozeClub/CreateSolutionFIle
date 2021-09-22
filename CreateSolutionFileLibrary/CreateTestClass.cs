using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading.Tasks;
using CreateSolutionFileLibrary;

namespace CreateSolutionFileLibrary
{
    public class CreateTestClass
    {
        public static bool CreateTestClassFile(UserInput ui)
        {
            string[] lines =
            {
                "using NUnit.Framework;",
                $"using {ui.LibraryName};",
                " ",
                $"namespace {ui.TestName}.UnitTests",
                "{",
                "   [TestFixture]",
                $"    public class {ui.ProjectName}_Tests",
                "    {",
                $"        private <type> _test1;",
                " ",
                "        [SetUp]",
                "        public void SetUp()",
                "        {",
                "            _test1 = new <type>();",
                "        }",
                " ",
                "        [Test]",
                "        public void IsPrime_InputIs1_ReturnFalse()",
                "        {",
                "            var result = _test1.IsPrime(1);",
                " ",
                "            Assert.IsFalse(result, \"result you want to check for\");",
                "        }",
                "    }",
                "}"
            };
            try
            {
            Console.WriteLine("");
            string filename = $"{ui.SolutionDirectory}/{ui.TestName}/{ui.ProjectName}_Tests.cs";
            Console.WriteLine($" Creating Test Class: {filename}");
                File.WriteAllLines(filename, lines);
            }
            catch (InvalidOperationException)   // The file exists and is read-only.
            {
                Console.WriteLine("File already exists, skipping.");
                return false;
            }
            catch (PathTooLongException)        // The path name may be too long.
            {
                Console.WriteLine("Filename path too long. File creation aborted.");
                return false;
            }
            catch (IOException)                 // The disk may be full.
            {
                Console.WriteLine("File write error. Disk may be full, file creation aborted.");
                return false;
            }
            catch (System.Exception)            // Catch all.
            {
                Console.WriteLine("System.Exception occurred, file creation aborted.");
                return false;
            }
            return true;
        }        
    }
}