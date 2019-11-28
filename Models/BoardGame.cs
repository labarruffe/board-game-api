using System;
using System.Collections.Generic;

namespace board_game_api.Models
{
    public class BoardGame
    {
        public int BoardGameId { get; set; }
        public List<Square> Squares { get; } = new List<Square>();
        public List<Log> Logs { get; } = new List<Log>();
        public List<Round> Rounds { get; } = new List<Round>();
        public Dice Dice { get; set; }
        public List<Player> Participants { get; } = new List<Player>();

        // public BoardGame(int diceSize) 
        // {
            // this.Squares.Add(new Square());
            // this.Logs = new List<Log>();
            // this.Rounds = new List<Round>();
            // this.Dice = new Dice(diceSize);
            // this.Participants = new List<Player>();
        // }

        // public int RollTheDice()
        // {
        //     return new Random().Next(1, this.Dice.NumberOfSides);
        // }

        // public void RegisterTurn(Player participant, Square square, int diceNumber)
        // {
        //     this.Logs.Add(new Log(square, participant, diceNumber));
        // }
    }
}