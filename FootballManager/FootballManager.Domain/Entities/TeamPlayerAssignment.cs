using FootballManager.Domain.Common;
using System;

namespace FootballManager.Domain.Entities
{
    public class TeamPlayerAssignment : AuditableBaseEntity
    {
        public int? PlayerId { get; set; }
        public Player Player { get; set; }

        public int? TeamId { get; set; }
        public Team Team { get; set; }

        public int Number { get; set; }
        
    }
}
