using FootballManager.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace FootballManager.Domain.Entities
{
    public class Player : AuditableBaseEntity
    {
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public Int64 IdNo { get; set; }
        public DateTime DateOfBirth { get; set; }
        public decimal Height { get; set; }
        public decimal Weight { get; set; }
        public TeamPlayerAssignment TeamAssignment { get; set; }

    }
}
