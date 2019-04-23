using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;

namespace chtr.server.data.Entities
{
    public class ChtrDbContext : DbContext
    {
        public ChtrDbContext(DbContextOptions<ChtrDbContext> options) : base(options)
        {
        }

        public DbSet<Room> Rooms { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Message> Messages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserRoomRelation>().HasKey(r => new { r.RoomId, r.UserId });
            modelBuilder.Entity<UserRoomRelation>()
                .HasOne(r => r.User)
                .WithMany(r => r.UserRoom)
                .HasForeignKey(r => r.UserId);
            modelBuilder.Entity<UserRoomRelation>()
                .HasOne(r => r.Room)
                .WithMany(r => r.UserRoom)
                .HasForeignKey(r => r.RoomId);
                                   
            base.OnModelCreating(modelBuilder);
        }
    }
}
