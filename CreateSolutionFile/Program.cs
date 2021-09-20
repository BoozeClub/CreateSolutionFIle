using System;
using System.Linq;
using CreateSolutionFileLibrary;

namespace CreateSolutionFile
{
    class Program
    {
        static void Main(string[] args)
        {
            bool confirm = false;
            string confirmReply;
            UserInput ui = new UserInput("");

            do
            {
                ui = GetUserInput("TestApplication");                       // Provide default value to override - **VSCode BUG**
                if ( ui.SolutionName == "x" )
                {
                    Console.WriteLine("Execution terminated by user request.");
                    return;
                }
                confirmReply = ConfirmValues(ui, "c");                      // Provide default value to override - **VSCode BUG**
                if ( confirmReply == "c")
                {
                    confirm = true;
                }
            } while ( confirm == false );

            OsCommand[] cmdArray = new OsCommand[8];


// Apparently changing to  a directory doesn't stick like it does while running a batch file.
// I had to prefix each dotnet command with a "cd" command to get me back into the correct directory.
// I kept the original commands for doc.
            cmdArray[0] = new OsCommand("mkdir", $" {ui.SolutionDirectory}");
            cmdArray[1] = new OsCommand("cmd.exe", $" /C cd /d {ui.SolutionDirectory}");
/*            cmdArray[2] = new OsCommand("dotnet", $" new sln -n {ui.SolutionName}"); */
/*            cmdArray[3] = new OsCommand("dotnet", $" new console -n {ui.ProjectName}"); */
/*            cmdArray[4] = new OsCommand("dotnet", $" new classlib -n {ui.LibraryName}"); */
/*            cmdArray[5] = new OsCommand("dotnet", $" sln {ui.SolutionName}.sln add ./{ui.ProjectName}/{ui.ProjectName}.csproj"); */
/*            cmdArray[6] = new OsCommand("dotnet", $" sln {ui.SolutionName}.sln add ./{ui.LibraryName}/{ui.LibraryName}.csproj"); */
/*            cmdArray[7] = new OsCommand("dotnet", $" add {ui.ProjectName}/{ui.ProjectName}.csproj reference {ui.LibraryName}/{ui.LibraryName}.csproj"); */
            cmdArray[2] = new OsCommand("cmd.exe", $" /C cd /d {ui.SolutionDirectory} & dotnet new sln -n {ui.SolutionName}");
            cmdArray[3] = new OsCommand("cmd.exe", $" /C cd /d {ui.SolutionDirectory} & dotnet new console -n {ui.ProjectName}");
            cmdArray[4] = new OsCommand("cmd.exe", $" /C cd /d {ui.SolutionDirectory} & dotnet new classlib -n {ui.LibraryName}");
            cmdArray[5] = new OsCommand("cmd.exe", $" /C cd /d {ui.SolutionDirectory} & dotnet sln {ui.SolutionName}.sln add ./{ui.ProjectName}/{ui.ProjectName}.csproj");
            cmdArray[6] = new OsCommand("cmd.exe", $" /C cd /d {ui.SolutionDirectory} & dotnet sln {ui.SolutionName}.sln add ./{ui.LibraryName}/{ui.LibraryName}.csproj");
            cmdArray[7] = new OsCommand("cmd.exe", $" /C cd /d {ui.SolutionDirectory} & dotnet add {ui.ProjectName}/{ui.ProjectName}.csproj reference {ui.LibraryName}/{ui.LibraryName}.csproj");

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

            Console.WriteLine("");
            Console.WriteLine("EXECUTION STATUS:");
            Console.WriteLine("");

            foreach (OsCommand command in cmdArray)
            {
                Console.WriteLine($"EXECUTE: {command.Cmd}{command.Parm}");
                Console.WriteLine($" STATUS: {command.Output}");
            }

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

        public static UserInput GetUserInput(string defaultValue)
        {
            Console.WriteLine("Enter [x] to Exit, or Enter Solution File Name: ");
            string reply = GetUserReply(defaultValue);
            UserInput ui = new UserInput($"{reply}");
            if ( defaultValue != "")
            {
                Console.WriteLine("GetUserInput");
                Console.WriteLine($"Default value \"{defaultValue}\" specified.");
                Console.WriteLine("Breakpoint established to highlight input default value override.");
            }
            return ui;
        }

        public static string GetUserReply(string defaultValue)
        {
            string reply;
            if ( defaultValue == "" )
            {
                reply = Console.ReadLine();          // Doesn't work in VSCode - **BUG**
            } else
            {
                /*
                    Provide default value override.
                    Skip user input prompt.
                    Fake it since Console.ReadLine doesn't work in VSCode.
                */
                Console.WriteLine("GetUserReply");
                Console.WriteLine($"Default value \"{defaultValue}\" specified.");
                Console.WriteLine("Breakpoint established to highlight input default value override.");
                reply = defaultValue;
            }
            return reply;
        }

        public static string ConfirmValues(UserInput ui, string defaultValue)
        {
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("Please verify stated values:");
            Console.WriteLine("");
            Console.WriteLine($"Solution File Name: {ui.SolutionName}");
            Console.WriteLine($"Project File Name:  {ui.ProjectName}");
            Console.WriteLine($"Library File Name:  {ui.LibraryName}");
            Console.WriteLine($"Solution Directory: {ui.SolutionDirectory}");
            Console.WriteLine("[c] to Confirm, [r] to Re-enter: ");
            
            string confirmReply = GetUserReply(defaultValue);

            if ( defaultValue != "")
            {
                Console.WriteLine("Confirm Values");
                Console.WriteLine($"Default value \"{defaultValue}\" specified.");
                Console.WriteLine("Breakpoint established to highlight input default value override.");
            }
            return confirmReply;
        }
    }
}
