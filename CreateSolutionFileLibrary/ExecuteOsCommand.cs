using System;
using System.IO;
using System.Diagnostics;
namespace CreateSolutionFileLibrary
{
    public static class ExecuteOsCommand
    {
        public static OsCommand ExecuteCommand(OsCommand OsCmd)
        {
            try
            {
                Console.WriteLine($"Executing Command: {OsCmd.Cmd}{OsCmd.Parm}");
                System.Diagnostics.ProcessStartInfo info = new System.Diagnostics.ProcessStartInfo($"{OsCmd.Cmd}", $"{OsCmd.Parm}");
                System.Diagnostics.Process p = new System.Diagnostics.Process();
                p.StartInfo = info;
                p.Start();
                p.WaitForExit();
                OsCmd.Rc     = 0;
                OsCmd.Output = "Success";
                Console.WriteLine($"{OsCmd.Output}");
                return OsCmd;
            }
            catch (DirectoryNotFoundException)
            {
                OsCmd.Rc     = 99;
                OsCmd.Output = "Failed - DirectoryNotFoundException";
                Console.WriteLine($"{OsCmd.Output}");
                return OsCmd;
            }
            catch (DriveNotFoundException)
            {
                OsCmd.Rc     = 99;
                OsCmd.Output = "Failed - DriveNotFoundException";
                Console.WriteLine($"{OsCmd.Output}");
                return OsCmd;
            }
            catch (FileNotFoundException)
            {
                OsCmd.Rc     = 99;
                OsCmd.Output = "Failed - FileNotFoundException";
                Console.WriteLine($"{OsCmd.Output}");
                return OsCmd;
            }
            catch (PathTooLongException)
            {
                OsCmd.Rc     = 99;
                OsCmd.Output = "Failed - PathTooLongException";
                Console.WriteLine($"{OsCmd.Output}");
                return OsCmd;
            }
            catch (UnauthorizedAccessException)
            {
                OsCmd.Rc     = 99;
                OsCmd.Output = "Failed - UnauthorizedAccessException";
                Console.WriteLine($"{OsCmd.Output}");
                return OsCmd;
            }
             catch (IOException)
            {
                OsCmd.Rc     = 99;
                OsCmd.Output = "Failed - System.IO Exception";
                Console.WriteLine($"{OsCmd.Output}");
                return OsCmd;
            }
            catch (SystemException)
            {
                OsCmd.Rc     = 99;
                OsCmd.Output = "Failed - SystemException";
                Console.WriteLine($"{OsCmd.Output}");
               return OsCmd;
            }
       }      
    }
}