using System.Collections.Generic;

namespace board_game_api.Models
{
    public class BoardGame
    {
        public List<Square> Squares { get; } = new List<Square>();
        public List<Log> Logs { get; } = new List<Log>();
        public List<Round> Rounds { get; } = new List<Round>();
    }
}