using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreateSolutionFileLibrary.UserInteractions
{
    public class UserInteractions
    {
        public static UserInput GetUserInput(string defaultValue)
        {
            string confirm = "";
            string sln = "";
            UserInput ui = new UserInput("");
            do
            {
                sln = GetSolutionFileName($"{defaultValue}");
                ui = new UserInput(sln);
                if ( sln == "x" )
                {
                    return ui;
                }
                confirm = ConfirmValues(ui, defaultValue);
            } while ( confirm != "c" && confirm != "C" );
            return ui;
        }

        public static string GetSolutionFileName(string defaultValue)
        {
            Console.WriteLine("Enter [x] to Exit, or Enter Solution File Name: ");
            if ( defaultValue != "" )
                {
                    return defaultValue;
                }
            return Console.ReadLine();
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
            Console.WriteLine("");
            Console.WriteLine("[c] to Confirm, [<anykey>] to Re-enter: ");
            if ( defaultValue != "" )
            {
                return "c";  // Bypass user input, default to Confirmed.
            }
            return Console.ReadLine();
        }    
    }
}