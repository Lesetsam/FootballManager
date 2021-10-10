using FootballManager.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace FootballManager.Domain.Entities
{
    public class TeamStadiumAssignment : AuditableBaseEntity
    {
        public int? TeamId { get; set; }
        public Team Team { get; set; }
        public int? StadiumId { get; set; }
        public Stadium Stadium { get; set; }

    }
}
