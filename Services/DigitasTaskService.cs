using DigitasTechTest.Application.Interfaces;
using DigitasTechTest.Domain;
using DigitasTechTest.Infrastructure.Interfaces;
using Domain.ExceptionHandler;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace DigitasTechTest.Application.Services
{
    public class DigitasTaskService : IDigitasTaskService
    {
        private readonly IDigitasTaskRepository _taskRepository;
        public DigitasTaskService(IDigitasTaskRepository taskRepository) 
        { 
        
            _taskRepository = taskRepository;
        }
        public async Task<int> InsertDigitasTasks(DigitasTask task) 
        {
            try
            {
                if (await DuplicatedDigitasTasks(task.Name) != true)
                {
                    var result = await _taskRepository.InsertDigitasTasks(task);
                    return result;
                }
                throw new Exception("Duplicated Task Name");
            }
            catch (BadHttpRequestException)
            {
                throw;
            }
            
        }
        public async Task<List<DigitasTask>> GetAllDigitasTasks() 
        {
            try
            {
                var result = await _taskRepository.GetAllDigitasTasks();
                if (result.Count() != 0) 
                {
                    return result;
                }

                throw new Exception("No Tasks Found!");
            }
            catch (BadHttpRequestException)
            {
                throw;
            }
            
        }

        public async Task<DigitasTask> GetDigitasTask(int id)
        {
            try
            {
                var result = await _taskRepository.GetDigitasTask(id);

                if (result != null) 
                {
                    return result;
                }
                throw new Exception("No Tasks Found!");

            }
            catch (BadHttpRequestException)
            {
                throw;
            }
            
        }
        public async Task<bool> UpdateDigitasTasks(DigitasTask task) 
        {
            try
            {
                var result = await _taskRepository.UpdateDigitasTasks(task);
                return result;
            }
            catch (BadHttpRequestException)
            {
                throw;
            }
            
        }

        public async Task<bool> DeleteDigitasTasks(int id) 
        {
            try
            {
                var result = await _taskRepository.DeleteDigitasTasks(id);
                return result;
            }
            catch (BadHttpRequestException)
            {
                throw;
            }          
        }
        public async Task<bool> DuplicatedDigitasTasks(string taskName) 
        {
            try
            {
                var result = await _taskRepository.DuplicatedDigitasTasks(taskName);
                return result;
            }
            catch (BadHttpRequestException)
            {
                throw;
            }

        }

    }
}
