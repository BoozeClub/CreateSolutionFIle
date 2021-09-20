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
    }

}