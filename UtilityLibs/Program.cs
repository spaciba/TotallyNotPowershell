using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Management.Automation;
using System.Management.Automation.Runspaces;

namespace UtilityLibs
{
    public class TotallyNotPowershell
    {
        public static void exec_ps(string command)
        {
            Collection<PSObject> output = null;

            PowerShell ps = PowerShell.Create();


            string[] separated_command = command.Split('|');
            foreach(string cmd in separated_command)
            {
                ps.AddCommand(cmd.Trim(' '));
            }

            output = ps.Invoke();

            if(output != null)
            {
                foreach(PSObject rtn in output)
                {
                    Console.WriteLine(rtn.ToString());
                }
            }
        }

        public static void Main()
        {
            string ins = null;

            while (true)
            {
                ins = Console.ReadLine();
                exec_ps(ins);
            }
        }
    }
}
