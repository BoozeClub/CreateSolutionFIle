namespace CreateSolutionFileLibrary
{
    public class UserInput
    {
        public string SolutionName      { get; set; }
        public string ProjectName       { get; set; }
        public string LibraryName       { get; set; }
        public string SolutionDirectory { get; set; }

        public UserInput(string solutionName)
        {
            // Set default values
            SolutionName        = solutionName;
            ProjectName         = solutionName;
            LibraryName         = $"{solutionName}Library";
            SolutionDirectory   = $"C:\\Data\\Source\\C#\\{solutionName}";
        }
        public UserInput(string solutionName, string projectName, string libraryName, string solutionDirectory )
        {
            SolutionName        = solutionName;
            ProjectName         = projectName;
            LibraryName         = $"{libraryName}Library";
            SolutionDirectory   = solutionDirectory;
        }
    }
}
