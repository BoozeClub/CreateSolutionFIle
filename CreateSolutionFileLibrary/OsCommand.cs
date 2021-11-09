namespace CreateSolutionFileLibrary
{
    public class OsCommand
    {
        public string Cmd    { get; set; }
        public string Parm   { get; set; }
        public int    Rc     { get; set; }
        public string Output { get; set; }

        public OsCommand(string cmd)
        {
            Cmd     = cmd;
            Parm    = "";
        }
        public OsCommand(string cmd, string parm)
        {
            Cmd     = cmd;
            Parm    = parm;
        }
        public OsCommand(string cmd, string parm, int rc, string output)
        {
            Cmd     = cmd;
            Rc      = rc;
            Output  = output;
        }

        public static OsCommand[] LoadArray(UserInput ui)
        {
            // Commands required to build a C# .NET Solution File
            OsCommand[] cmdArray = new OsCommand[12];
            cmdArray[0] = new OsCommand("mkdir", $" {ui.SolutionDirectory}");
            cmdArray[1] = new OsCommand("cmd.exe", $" /C cd /d {ui.SolutionDirectory}");
            cmdArray[2] = new OsCommand("cmd.exe", $" /C cd /d {ui.SolutionDirectory} & dotnet new sln -n {ui.SolutionName}");
            cmdArray[3] = new OsCommand("cmd.exe", $" /C cd /d {ui.SolutionDirectory} & dotnet new console -n {ui.ProjectName}");
            cmdArray[4] = new OsCommand("cmd.exe", $" /C cd /d {ui.SolutionDirectory} & dotnet new classlib -n {ui.LibraryName}");
            cmdArray[5] = new OsCommand("cmd.exe", $" /C cd /d {ui.SolutionDirectory} & dotnet sln {ui.SolutionName}.sln add ./{ui.ProjectName}/{ui.ProjectName}.csproj");
            cmdArray[6] = new OsCommand("cmd.exe", $" /C cd /d {ui.SolutionDirectory} & dotnet sln {ui.SolutionName}.sln add ./{ui.LibraryName}/{ui.LibraryName}.csproj");
            cmdArray[7] = new OsCommand("cmd.exe", $" /C cd /d {ui.SolutionDirectory} & dotnet add {ui.ProjectName}/{ui.ProjectName}.csproj reference {ui.LibraryName}/{ui.LibraryName}.csproj");
            cmdArray[8] = new OsCommand("mkdir", $" {ui.SolutionDirectory}/{ui.TestName}");
            cmdArray[9] = new OsCommand("cmd.exe", $" /C cd /d {ui.SolutionDirectory}/{ui.TestName} & dotnet new nunit");
            cmdArray[10] = new OsCommand("cmd.exe", $" /C cd /d {ui.SolutionDirectory}/{ui.TestName} & dotnet add reference {ui.SolutionDirectory}/{ui.LibraryName}/{ui.LibraryName}.csproj");
            cmdArray[11] = new OsCommand("cmd.exe", $" /C cd /d {ui.SolutionDirectory} & dotnet sln add {ui.SolutionDirectory}/{ui.TestName}/{ui.TestName}.csproj");
            return cmdArray;
        }
    }
}