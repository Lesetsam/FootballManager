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
        public int IdNo { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }


    }
}
