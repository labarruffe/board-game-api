namespace board_game_api.Models
{

    public enum MovementTypeEnum : int
        {
        FORWARD = 0,
        BACKWARD = 1,
        IDLE = 2
    }
    public class Rule
    {
        public int RuleId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int NumberOfSquares { get; set; }

        public MovementTypeEnum MovementType { get; set; }
    }
}