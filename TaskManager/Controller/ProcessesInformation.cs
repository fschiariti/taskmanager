using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Management;
using System.Text;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using TaskManager.Controller.Interfaces;

namespace TaskManager.Controller
{
    public class ProcessesInformation : IProcessInformation
    {
        public string pid;
        public string name;
        public string exeName;
        public string owner;

        public async Task<List<ProcessesInformation>> GetProcessesAsync()
        {

            List<ProcessesInformation> list = await Task.Run(() => GetProcessesListAsync());

            return list;
        }

        static public List<ProcessesInformation> GetProcessesListAsync()
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
                    myObj.owner =  GetProcessOwner(p.Id);

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

        public List<ProcessesInformation> GetProcesses()
        {

            List<ProcessesInformation> listProcess = new List<ProcessesInformation>();
            Process[] processlist = Process.GetProcesses();

            int i = 0;

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

                if (i > 100) {
                    break;
                }

                i++;
            }

            return listProcess;
        }

        private static string GetProcessOwner(int processId)
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

        #region APIS
        [DllImport("psapi")]
        private static extern bool EnumProcesses([MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U4)][In][Out] IntPtr[] processIds, UInt32 arraySizeBytes, [MarshalAs(UnmanagedType.U4)] out UInt32 bytesCopied);

        [DllImport("kernel32.dll")]
        static extern IntPtr OpenProcess(ProcessAccessFlags dwDesiredAccess, [MarshalAs(UnmanagedType.Bool)] bool bInheritHandle, IntPtr dwProcessId);

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool CloseHandle(IntPtr hObject);

        [DllImport("psapi.dll")]
        static extern uint GetModuleFileNameEx(IntPtr hProcess, IntPtr hModule, [Out] StringBuilder lpBaseName, [In][MarshalAs(UnmanagedType.U4)] int nSize);

        [DllImport("psapi.dll", SetLastError = true)]
        public static extern bool EnumProcessModules(IntPtr hProcess,
        [Out] IntPtr lphModule,
        uint cb,
        [MarshalAs(UnmanagedType.U4)] out uint lpcbNeeded);

        [DllImport("psapi.dll")]
        static extern uint GetModuleBaseName(IntPtr hProcess, IntPtr hModule, [Out] StringBuilder lpBaseName, [In][MarshalAs(UnmanagedType.U4)] int nSize);
        #endregion
        #region ENUMS

        [Flags]
        enum ProcessAccessFlags : uint
        {
            All = 0x001F0FFF,
            Terminate = 0x00000001,
            CreateThread = 0x00000002,
            VMOperation = 0x00000008,
            VMRead = 0x00000010,
            VMWrite = 0x00000020,
            DupHandle = 0x00000040,
            SetInformation = 0x00000200,
            QueryInformation = 0x00000400,
            Synchronize = 0x00100000
        }
        #endregion

        static string PrintProcessName(IntPtr processID)
        {
            string sName = "";
            bool bFound = false;
            IntPtr hProcess = OpenProcess(ProcessAccessFlags.QueryInformation | ProcessAccessFlags.VMRead, false, processID);
            if (hProcess != IntPtr.Zero)
            {
                StringBuilder szProcessName = new StringBuilder(260);
                IntPtr hMod = IntPtr.Zero;
                uint cbNeeded = 0;
                EnumProcessModules(hProcess, hMod, (uint)Marshal.SizeOf(typeof(IntPtr)), out cbNeeded);
                if (GetModuleBaseName(hProcess, hMod, szProcessName, szProcessName.Capacity) > 0)
                {
                    sName = szProcessName.ToString();
                    bFound = true;
                }

                // Close the process handle
                CloseHandle(hProcess);
            }
            if (!bFound)
            {
                sName = "<unknown>";
            }
            return sName;
        }
        public List<ProcessesInformation> GetProcessesWin32()
        {
            List<ProcessesInformation> listProcess = new List<ProcessesInformation>();

            UInt32 arraySize = 9000;
            UInt32 arrayBytesSize = arraySize * sizeof(UInt32);
            IntPtr[] processIds = new IntPtr[arraySize];
            UInt32 bytesCopied;

            bool success = EnumProcesses(processIds, arrayBytesSize, out bytesCopied);

            Console.WriteLine("success={0}", success);
            Console.WriteLine("bytesCopied={0}", bytesCopied);

            if (!success)
            {
                Console.WriteLine("Boo!");
            }
            if (0 == bytesCopied)
            {
                Console.WriteLine("Nobody home!");
            }

            UInt32 numIdsCopied = bytesCopied >> 2; ;

            if (0 != (bytesCopied & 3))
            {
                UInt32 partialDwordBytes = bytesCopied & 3;

                Console.WriteLine("EnumProcesses copied {0} and {1}/4th DWORDS...  Please ask it for the other {2}/4th DWORD",
                    numIdsCopied, partialDwordBytes, 4 - partialDwordBytes);
            }

            for (UInt32 index = 0; index < numIdsCopied; index++)
            {
                string sName = PrintProcessName(processIds[index]);
                IntPtr PID = processIds[index];
                Console.WriteLine("Name '" + sName + "' PID '" + PID + "'");

                ProcessesInformation myObj = new ProcessesInformation();
                myObj.exeName = sName;
                myObj.pid = PID.ToString();
                myObj.name = sName;
                myObj.owner = "";

                listProcess.Add(myObj);

            }

            return listProcess;
        }

    }

}
