namespace board_game_api.Models
{
    public class Log
    {
        public int LogId { get; set; }
        public Square Square { get; set; }
        public Player Player { get; set; }
        public int DiceNumber { get; set; }

        // public Log(Square square, Player player, int diceNumber)
        // {
        //     this.Square = square;
        //     this.Player = player;
        //     this.DiceNumber = diceNumber;
        // }
    }
}