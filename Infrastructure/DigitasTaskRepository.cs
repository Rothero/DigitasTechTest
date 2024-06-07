using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DigitasTechTest.Infrastructure.Data;
using DigitasTechTest.Domain;
using DigitasTechTest.Infrastructure.Interfaces;
using System.Xml.Linq;

namespace DigitasTechTest.Infrastructure
{
    public class DigitasTaskRepository:IDigitasTaskRepository
    {
        private readonly IAppDbService _dbService;

        public DigitasTaskRepository(IAppDbService dbService)
        {
            _dbService = dbService;
        }

        public async Task<int> InsertDigitasTasks(DigitasTask task)
        {
            var result =
                await _dbService.EditData<int>(
                    "SELECT InsertTask (@name, @description, @taskOwner, @dateLimit, @idStatus)",
                new {
                        name = task.Name,
                        description = task.Description,
                        taskOwner = task.TaskOwner,
                        dateLimit = task.DateLimit,
                        idStatus = task.IdStatus
                });
            return result;
        }

        public async Task<List<DigitasTask>> GetAllDigitasTasks()
        {
            var result = await _dbService.GetAsync<DigitasTask>("SELECT * FROM ReturnAllTasks()", null);
            return result;
        }

        public async Task<DigitasTask> GetDigitasTask(int id)
        {
            var result = (await _dbService.GetAsync<DigitasTask>("SELECT * FROM ReturnTask(@id)", new { id })).FirstOrDefault();
            return result;
        }

        public async Task<bool> UpdateDigitasTasks(DigitasTask task)
        {
            var updatedTasks =
               await _dbService.EditData<int>("SELECT UpdateTask (@idTask ,@nameTask, @description ,@taskOwner, @dateLimit, @dateConcluded, @idStatus )",
                    new
                    {
                        idTask = task.Id,
                        nameTask = task.Name,
                        description = task.Description,
                        taskOwner = task.TaskOwner,
                        dateLimit = task.DateLimit,
                        dateConcluded = task.DateConcluded,
                        idStatus = task.IdStatus
                    });
            var result = updatedTasks != 0 ? true : false;
            return result;
        }

        public async Task<bool> DeleteDigitasTasks(int id)
        {
            var deleteTask = await _dbService.EditData<int>("SELECT DeleteTask(@id)", new { id });
            var result = deleteTask !=0? true: false;
            return result;
        }
        public async Task<bool> DuplicatedDigitasTasks(string taskName)
        {
            var verifiedTask = await _dbService.EditData<int>("SELECT DuplicatedDigitasTasks(@taskName)", new { taskName });
            var result = verifiedTask != 0 ? true : false;
            return result;
        }
    }

}

