using Microsoft.EntityFrameworkCore;

namespace board_game_api.Models
{
    public class BoardGameContext: DbContext
    {
        public DbSet<BoardGame> BoardGame { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=boardgame.db");
    }
}