using System.Collections.Generic;

namespace board_game_api.Models
{
    public class Square
    {
        public int SquareId { get; set; }
        public Rule Rule { get; set; }
        public List<Player> Players { get; set; }

    }
}