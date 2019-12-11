using Microsoft.EntityFrameworkCore;

namespace board_game_api.Models
{
    public class BoardGameContext: DbContext
    {

        public BoardGameContext(DbContextOptions<BoardGameContext> options): base(options) {}
        public DbSet<BoardGame> BoardGame { get; set; }
        public DbSet<Player> Player { get; set; }
    }
}