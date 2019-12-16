using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace board_game_api.Models
{
    public class Square
    {
        public int Id { get; set; }
        public int BoardGameId { get; set; }
        public Rule Rule { get; set; }
        public List<Player> Players { get; set; }
        public BoardGame BoardGame { get; set; }
    }
}