using DigitasTechTest.Domain;
using DigitasTechTest.Domain.Enum;
using System.Runtime.CompilerServices;

namespace DigitasWebApi.Response
{
    public class DigitasTaskResponse
    {
        public DigitasTaskResponse(DigitasTask task)
        {
            
            Id = task.Id;
            Name = task.Name;
            Description = task.Description;
            TaskOwner = task.TaskOwner;
            DateCreation = task.DateCreation;
            DateLimit = task.DateLimit;
            DateConcluded = task.DateConcluded;
            StatusTask = task.IdStatus.ToString();
            IsTaskOverdue = task.IsTaskOverdue;

        }

        public DigitasTaskResponse(List<DigitasTask> tasks)
        {
            foreach (DigitasTask task in tasks)
            {
                Id = task.Id;
                Name = task.Name;
                Description = task.Description;
                TaskOwner = task.TaskOwner;
                DateCreation = task.DateCreation;
                DateLimit = task.DateLimit;
                DateConcluded = task.DateConcluded;
                StatusTask = task.IdStatus.ToString();
                IsTaskOverdue = task.IsTaskOverdue;
            }
        }
        


        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string TaskOwner { get; set; }
        public DateTime DateCreation { get; set; }
        public DateTime DateLimit { get; set; }
        public DateTime? DateConcluded { get; set; }
        public string StatusTask { get; set; }
        public bool IsTaskOverdue { get; set; }

        

    }
}
