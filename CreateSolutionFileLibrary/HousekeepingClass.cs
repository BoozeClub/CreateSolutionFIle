namespace CreateSolutionFileLibrary
{
    public class HousekeepingClass
    {
        public static string Housekeeping(string[] args)
        {
            // VS Code has a bug, it won't prompt for user input.
            //
            // If run from command line:
            //     args[0] = Default project name, or the word "input" which will
            //               cause the program to prompt for user input.
            //               If args[0] is null, then default to "TestApplication".

            string defaultValue = "TestApplication";                               // Skip user input
            
            if ( args.Length > 0 )
            {
                defaultValue = args[0];                                            // Get project name from command line
            }

            if ( defaultValue == "input" )
            {
                defaultValue = "";                                                 // Force user input
            }
            return defaultValue;
        }
    }
}