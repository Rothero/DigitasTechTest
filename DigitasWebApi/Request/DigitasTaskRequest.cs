using DigitasTechTest.Domain;
using DigitasTechTest.Domain.Enum;

namespace DigitasWebApi.Request
{
    public class DigitasTaskRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string TaskOwner { get; set; }
        public DateTime DateLimit { get; set; }
        public DateTime? DateConcluded { get; set; }
        public Status IdStatus { get; set; }

        public DigitasTask ToDigitasTask(int id = 0) 
        {
            var task = new DigitasTask()
            {
                Id = id,
                Name = Name,
                Description = Description,
                TaskOwner = TaskOwner,
                DateLimit = DateLimit,
                DateConcluded = DateConcluded,
                IdStatus = IdStatus
            };           
            return task;     
        }


    } 
}

   
