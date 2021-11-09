using System;
using System.Linq;

namespace CreateSolutionFileLibrary
{
    public class DisplayExecutionStatusClass
    {
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