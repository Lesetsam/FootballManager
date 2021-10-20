using FootballManager.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace FootballManager.Domain.Entities
{
    public class Team : AuditableBaseEntity
    {
        public string Name { get; set; }
        public string City { get; set; }
        public ICollection<TeamPlayerAssignment> Players { get; set; }

    }
}
