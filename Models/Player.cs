namespace board_game_api.Models
{
    public class Player
    {
        public int Id { get; set; }
        public int SquareId { get; set; }
        public int BoardGameId { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public Square Square { get; set; }
        public BoardGame BoardGame { get; set; }
    }
}