using System;
using System.Linq;
using System.IO;
using System.Threading.Tasks;
using CreateSolutionFileLibrary;
//using CreateSolutionFileLibrary.UserInput;

namespace CreateSolutionFile
{
    class Program
    {
        static void Main(string[] args)
        {
            // Purpose:
            //          Automate .NET Console Solution File Creation.
            //
            // Features:
            //          1. Program will not overwrite an existing solution file. Instead, program will abort w/ message.
            //          2. Command line syntax:
            //                  dotnet run <parm>
            //                                      Where <parm> = Any project name (1 Continous word), or
            //                                                     "input"
            //                                                     If "input", the program will prompt the user for input.
            //                                                     If <parm> isn't specified, it will default to:
            //                                                           "TestApplication".
            //          3. Enforces the following standards:
            //                  Class Library name will always have "Library" appended to it.
            //                  Test Project name will always have "Tests" appended to it.
            //                  Default program class is named Program.cs.
            //                  Default library class is named Class1.cs.
            //                  Default NUnit test class is named Unit_Test1.cs.
            //          4. Creates the following directory structure and files:
            //                  KEY:
            //                      SolutionName = User input.
            //                      ProjectName  = Defaults to Solution name.
            //                      LibraryName  = Defaults to Solution name + "Library".
            //                                     Library name will ALWAYS have "Library" appended to it.
            //                      TestName     = Defaults to Solution name + "Tests".
            //                                     Test name will ALWAYS have "Tests" appended to it.
            //                  c:\Data\Source\C#\<SolutionName>\
            //                                                	 SolutionName.sln
            //                                                  \ProjectName\
	        //                                                              \obj\
            //                                                          	     project.assets.json
	        //                                                                   project.nuget.cache
            //                                                              	 ProjectName.csproj.nuget.dgspec.json
	        //                                                                   ProjectName.csproj.nuget.g.props
	        //                                                                   ProjectName.csproj.nuget.g.targets
	        //                                                               Program.cs
	        //                                                               ProjectName.csproj
            //                                                  \LibraryName\
            //                                                          	\obj\
            //                                                          	     project.assets.json
	        //                                                                   project.nuget.cache
            //                                                              	 LibraryName.csproj.nuget.dgspec.json
	        //                                                                   LibraryName.csproj.nuget.g.props
	        //                                                                   LibraryName.csproj.nuget.g.targets
            //                                                          	 Class1.cs
            //                                                          	 LibraryName.csproj
            //                                                  \TestName\
            //                                                      	 \obj\
            //                                                      	     \TestName.csproj
            //                                                          	  UnitTest1.cs
            //                                                          	     project.assets.json
	        //                                                                   project.nuget.cache
            //                                                              	 TestName.csproj.nuget.dgspec.json
	        //                                                                   TestName.csproj.nuget.g.props
	        //                                                                   TestName.csproj.nuget.g.targets
            //          5. All dotnet "add reference" statements are executed as required.
            //                                               
            // Notes:
            //          VS Code has a bug in it where it won't accept user input while running in its terminal.
            //          I provided a default value of "TestApplication" so that it simulates user input.
            //          If run via command prompt, simply specify "input" as a parameter. It will force the
            //          application to prompt for User Input from the terminal.
            //
            //          To execute at the command prompt and allow user input, enter:
            //                  cd\<ProjectDir>
            //                  dotnet run input
            //
            //          To execute with default "TestApplication" as a solution name, enter:
            //                  cd\<ProjectDir>
            //                  dotnet run
            //
            //          Program will display derived run-time values and ask for confirmation before executing the set of commands.
            //
            //          Program will display build status as it builds the objects and it wil display a recap at the end.
            //
            // Limitations:
            //          You can't create a solution file called "x.sln" or "X.sln".

            string defaultValue = HousekeepingClass.Housekeeping(args);

            UserInput ui = UserInput.GetUserInput(defaultValue);
            if ( ui.SolutionName == "x" )
            {
                Console.WriteLine("Execution terminated by user request.");
                return;
            }

            OsCommand[] cmdArray = OsCommand.LoadArray(ui);
            string filename = $"{ui.SolutionDirectory}/{ui.SolutionName}.sln";

            if ( File.Exists(filename) )
            {
                Console.WriteLine("");
                Console.WriteLine("ERROR:");
                Console.WriteLine($"Solution file '{filename}' exists, program aborted.");
                return;    
            }
            BuildSolutionFileClass.BuildSolutionFile(cmdArray, ui);
            DisplayExecutionStatusClass.DisplayExecutionStatus(cmdArray, ui);
         
            return;
        }

    }
}
