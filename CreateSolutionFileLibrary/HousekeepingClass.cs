using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreateSolutionFileLibrary
{
    public class HousekeepingClass
    {
        public static string Housekeeping(string[] args)
        {
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
            return defaultValue;
        }
    }
}