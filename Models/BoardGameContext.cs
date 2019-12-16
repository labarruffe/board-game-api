using Microsoft.EntityFrameworkCore;

namespace board_game_api.Models
{
    public class BoardGameContext: DbContext
    {
        public BoardGameContext(DbContextOptions<BoardGameContext> options): base(options) {}
        public DbSet<BoardGame> BoardGame { get; set; }
        public DbSet<Square> Squares { get; set; }
        public DbSet<Rule> Rules { get; set; }
        public DbSet<Player> Players { get; set; }
       

        // protected override void OnModelCreating(ModelBuilder builder)
        // {
        //     builder.Entity<Square>()
        //         .HasOne<Rule>(r => r.Rule)
        //         .WithOne(s => s.Square)
        //         .HasForeignKey<Rule>(b => b.SquareId);
        // }

        // protected override void OnModelCreating(ModelBuilder builder)
        // {
        //     base.OnModelCreating(builder);

        //     builder.Entity<Square>().ToTable("Squares");
        //     builder.Entity<Square>().HasKey(p => p.Id);
        //     builder.Entity<Square>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();


        // }
    }
}
