using DigitasTechTest.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitasTechTest.Application.Interfaces
{
    public  interface IDigitasTaskService
    {
        Task<int> InsertDigitasTasks(DigitasTask task);
        Task<List<DigitasTask>> GetAllDigitasTasks();
        Task<DigitasTask> GetDigitasTask(int id);
        Task<bool> UpdateDigitasTasks(DigitasTask task);
        Task<bool> DeleteDigitasTasks(int id);
    }
}
