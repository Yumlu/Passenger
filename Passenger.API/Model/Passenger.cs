using System;

namespace Passenger.API.Model
{
    public class Passenger
    {
        public Guid  Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Gender { get; set; }
        public string DocumentNo { get; set; }
        public string DocumentType { get; set; }
        public DateTime IssueDate { get; set; }

    }
}