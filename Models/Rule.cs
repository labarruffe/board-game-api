namespace board_game_api.Models
{
    public class Rule
    {
        public int Id { get; set; }
        public int SquareId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int NumberOfSquares { get; set; }
        public MovementTypeEnum MovementType { get; set; }
        public Square Square { get; set; }
    }
}