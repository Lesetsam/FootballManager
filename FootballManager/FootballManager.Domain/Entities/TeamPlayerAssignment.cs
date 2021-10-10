using FootballManager.Domain.Common;

namespace FootballManager.Domain.Entities
{
    public class TeamPlayerAssignment : BaseEntity
    {
        public int? PlayerId { get; set; }
        public Player Player { get; set; }

        public int? TeamId { get; set; }
        public Team Team { get; set; }

        public byte Number { get; set; }
    }
}
