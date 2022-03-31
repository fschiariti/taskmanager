using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Management;

namespace WinFormsApp1
{
    public class ProcessesInformation
    {
        public string pid;
        public string name;
        public string exeName;
        public string owner;

        public List<ProcessesInformation> GetProcesses()
        {

            List<ProcessesInformation> listProcess = new List<ProcessesInformation>();
            Process[] processlist = Process.GetProcesses();

            //int i = 0;

            foreach (Process p in processlist)
            {

                try
                {
                    ProcessesInformation myObj = new ProcessesInformation();
                    myObj.exeName = p.MainModule.FileName;
                    myObj.pid = p.Id.ToString();
                    myObj.name = p.ProcessName;
                    myObj.owner = GetProcessOwner(p.Id);

                    listProcess.Add(myObj);

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                /*
                if (i > 100) {
                    break;
                }

                i++;
                */
            }

            return listProcess;
        }

        private string GetProcessOwner(int processId)
        {
            string query = "Select * From Win32_Process Where ProcessID = " + processId;
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(query);
            ManagementObjectCollection processList = searcher.Get();

            foreach (ManagementObject obj in processList)
            {
                string[] argList = new string[] { string.Empty, string.Empty };
                int returnVal = Convert.ToInt32(obj.InvokeMethod("GetOwner", argList));
                if (returnVal == 0)
                {
                    // return DOMAIN\user
                    return argList[1] + "\\" + argList[0];
                }
            }

            return "NO OWNER";
        }

    }
}
