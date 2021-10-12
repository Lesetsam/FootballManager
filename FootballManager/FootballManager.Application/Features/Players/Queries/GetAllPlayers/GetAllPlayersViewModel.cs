using System;
using System.Collections.Generic;
using System.Text;

namespace FootballManager.Application.Features.Players.Queries.GetAllPlayers
{
    public class GetAllPlayersViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public Int64 IdNo { get; set; }
        public DateTime DateOfBirth { get; set; }
        public decimal Height { get; set; }
        public decimal Weight { get; set; }
    }
}
