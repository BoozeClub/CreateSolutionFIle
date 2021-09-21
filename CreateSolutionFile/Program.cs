using System;
using System.Linq;
using CreateSolutionFileLibrary;
//using CreateSolutionFileLibrary.UserInput;
using CreateSolutionFileLibrary.UserInteractions;
using CreateSolutionFileLibrary.ExecuteOsCommand;

namespace CreateSolutionFile
{
    class Program
    {
        static void Main(string[] args)
        {
            // Notes:
            //          VS Code has a bug in it where it won't accept user input while running in its terminal.
            //          I provided a default value of "TestApplication" so that it simulates user input.
            //          If run via command prompt, simply specify "input" as a parameter it will force the
            //          application to use User Input from the terminal.

            string defaultValue = "TestApplication";                               // Skip user input
            try
            {
                 defaultValue = args[0];
            }
            catch (System.Exception)
            {
                defaultValue = "TestApplication";
            }
            if ( defaultValue == "input" )
            {
                defaultValue = "";                                                 // Force user input
            }

            UserInput ui = UserInteractions.GetUserInput(defaultValue);
            if ( ui.SolutionName == "x" )
            {
                Console.WriteLine("Execution terminated by user request.");
                return;
            }

            OsCommand[] cmdArray = LoadArray(ui);
            BuildSolutionFile(cmdArray);
            DisplayExecutionStatus(cmdArray, ui);
         
            return;
        }
        public static OsCommand[] LoadArray(UserInput ui)
        {
            // Commands required to build a C# .NET Solution File
            OsCommand[] cmdArray = new OsCommand[8];
            cmdArray[0] = new OsCommand("mkdir", $" {ui.SolutionDirectory}");
            cmdArray[1] = new OsCommand("cmd.exe", $" /C cd /d {ui.SolutionDirectory}");
            cmdArray[2] = new OsCommand("cmd.exe", $" /C cd /d {ui.SolutionDirectory} & dotnet new sln -n {ui.SolutionName}");
            cmdArray[3] = new OsCommand("cmd.exe", $" /C cd /d {ui.SolutionDirectory} & dotnet new console -n {ui.ProjectName}");
            cmdArray[4] = new OsCommand("cmd.exe", $" /C cd /d {ui.SolutionDirectory} & dotnet new classlib -n {ui.LibraryName}");
            cmdArray[5] = new OsCommand("cmd.exe", $" /C cd /d {ui.SolutionDirectory} & dotnet sln {ui.SolutionName}.sln add ./{ui.ProjectName}/{ui.ProjectName}.csproj");
            cmdArray[6] = new OsCommand("cmd.exe", $" /C cd /d {ui.SolutionDirectory} & dotnet sln {ui.SolutionName}.sln add ./{ui.LibraryName}/{ui.LibraryName}.csproj");
            cmdArray[7] = new OsCommand("cmd.exe", $" /C cd /d {ui.SolutionDirectory} & dotnet add {ui.ProjectName}/{ui.ProjectName}.csproj reference {ui.LibraryName}/{ui.LibraryName}.csproj");
            return cmdArray;
        }
        public static void BuildSolutionFile(OsCommand[] cmdArray)
        {
            // Execute command required to build .NET C# Solution File
            int maxRc = 0;

            for (int i = 0; i < cmdArray.Count(); i++)
            {
                OsCommand tmp = cmdArray[i];
                cmdArray[i] = ExecuteOsCommand.ExecuteCommand(tmp);
                tmp = cmdArray[i];
                if ( tmp.Rc == 99 )
                {
                    i     = tmp.Rc;
                    maxRc = i;
                }
            }            
            return;
        }
        public static void DisplayExecutionStatus(OsCommand[] cmdArray, UserInput ui)
        {
            // Display command execution results. rc=99 = Failed execution, abort.
            Console.WriteLine("");
            Console.WriteLine("EXECUTION STATUS:");
            Console.WriteLine("");

            int maxRc = 0;
            bool executed = true;

            for (int i = 0; i < cmdArray.Count(); i++)
            {
                if ( executed == true)
                {
                    OsCommand tmp = cmdArray[i];
                    Console.WriteLine($"EXECUTE: {tmp.Cmd}{tmp.Parm}");
                    Console.WriteLine($" STATUS: {tmp.Output}");
                    if ( tmp.Rc > maxRc )
                    {
                        maxRc = tmp.Rc;
                    }
                    if ( tmp.Rc == 99 )
                    {
                        executed = false;       // Future commands didn't execute, aborted.
                    }
                }

            }
            // Wrap it up.
            Console.WriteLine("");
            if ( maxRc < 99 )
            {
                Console.WriteLine($"Solution File {ui.SolutionName} Created Successfully.");
            } else
            {
                Console.WriteLine($"Create Solution File {ui.SolutionName} Failed.");                
            }
            return;
        }
    }
}
