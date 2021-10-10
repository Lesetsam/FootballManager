using FootballManager.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace FootballManager.Domain.Entities
{
    public class Stadium : AuditableBaseEntity
    {
        public string Name { get; set; }
        public string City { get; set; }
        public int Capacity { get; set; }
        public List<TeamStadiumAssignment> Teams { get; set; }

    }
}
