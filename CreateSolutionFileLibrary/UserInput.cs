using System;
//namespace CreateSolutionFileLibrary.UserInput
//{
    public class UserInput
    {
        public string SolutionName      { get; set; }
        public string ProjectName       { get; set; }
        public string LibraryName       { get; set; }
        public string TestName          { get; set; }
        public string SolutionDirectory { get; set; }

        public UserInput(string solutionName)
        {
            // Set default values
            SolutionName        = solutionName;
            ProjectName         = solutionName;
            LibraryName         = $"{solutionName}Library";
            TestName            = $"{solutionName}Tests";
            SolutionDirectory   = $"C:\\Data\\Source\\C#\\{solutionName}";
        }
        public UserInput(string solutionName, string projectName, string libraryName, string testName, string solutionDirectory )
        {
            SolutionName        = solutionName;
            ProjectName         = projectName;
            LibraryName         = $"{libraryName}Library";
            TestName            = $"{testName}Tests";
            SolutionDirectory   = solutionDirectory;
        }
        
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
//}
