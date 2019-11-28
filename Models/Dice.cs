namespace board_game_api.Models
{
    public class Dice
    {
        public int DiceId { get; set; }
        public int NumberOfSides { get; set; }
    
        public Dice(int numberOfSides)
        {
            this.NumberOfSides = numberOfSides;
        }
    }
}