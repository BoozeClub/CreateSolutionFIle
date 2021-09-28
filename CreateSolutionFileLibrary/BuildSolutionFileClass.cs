using System.Linq;

namespace CreateSolutionFileLibrary
{
    public class BuildSolutionFileClass
    {
        public static bool BuildSolutionFile(OsCommand[] cmdArray, UserInput ui)
        {
            // Execute command required to build .NET C# Solution File
            int maxRc = 0;
            bool testClassCreated = false;

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
            if ( maxRc < 99 )
            {
                testClassCreated = CreateTestClass.CreateTestClassFile(ui);
            }
            return testClassCreated;
        }
    }
}