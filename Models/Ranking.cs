using System.Collections.Generic;

namespace board_game_api.Models
{
    public class Ranking
    {
        public int RankingId { get; set; }
        public List<Player> Order { get; set; }
        public Player Winner { get; set; }
    }
}