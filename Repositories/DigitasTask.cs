using DigitasTechTest.Domain.Enum;

namespace DigitasTechTest.Domain
{
    public class DigitasTask
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public  required string TaskOwner {  get; set; }
        public DateTime DateCreation { get; set; }
        public DateTime DateLimit { get; set; }
        public DateTime? DateConcluded{ get; set; }
        public Status IdStatus { get; set; }
        public bool IsTaskOverdue { get; set; }
    }
}
