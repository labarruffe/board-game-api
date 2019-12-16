using System.Collections.Generic;

namespace board_game_api.Models
{
    public class Ranking
    {
        public int Id { get; set; }
        public List<Player> Order { get; set; } = new List<Player>();
        public Player Winner { get; set; }
    }
}