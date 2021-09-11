using Microsoft.EntityFrameworkCore;
using ToDoApp.Database.Entities;

namespace ToDoApp.Database
{
    public class TodoAppContext : DbContext
    {
        public DbSet<ToDoItemEntity> ToDoItemEntities { get; set; }
        public DbSet<ToDoListEntity> ToDoListEntities { get; set; }
        public DbSet<UserEntity> UserEntities { get; set; }

        public TodoAppContext(DbContextOptions<TodoAppContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ToDoItemEntity>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired();
                entity.HasOne(d => d.ToDoListEntity)
                    .WithMany(p => p.ToDoItemEntities);

            });

            modelBuilder.Entity<ToDoListEntity>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired();
            });
        }
    }
}
