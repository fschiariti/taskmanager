using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Controller;

namespace TaskManager.Controller.Interfaces
{
    interface IProcessInformation
    {
        public Task<List<ProcessesInformation>> GetProcessesAsync();

    }
}
