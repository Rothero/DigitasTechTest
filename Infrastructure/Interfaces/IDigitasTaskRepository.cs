using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DigitasTechTest.Domain;

namespace DigitasTechTest.Infrastructure.Interfaces
{
    public interface IDigitasTaskRepository
    {
        Task<int> InsertDigitasTasks(DigitasTask task);
        Task<List<DigitasTask>> GetAllDigitasTasks();
        public Task<DigitasTask> GetDigitasTask(int id);
        Task<bool> UpdateDigitasTasks(DigitasTask task);
        Task<bool> DeleteDigitasTasks(int id);
        Task<bool> DuplicatedDigitasTasks(string taskName);
    }
}