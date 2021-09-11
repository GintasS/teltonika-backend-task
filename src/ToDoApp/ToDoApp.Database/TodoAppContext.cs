using Microsoft.EntityFrameworkCore;
using ToDoApp.Domain.Entities;

namespace ToDoApp.Database
{
    public class TodoAppContext : DbContext
    {
        public DbSet<ToDoSingleItemEntity> ToDoSingleItemEntities { get; set; }
        public DbSet<TodoListEntity> TodoListEntities { get; set; }

        public TodoAppContext(DbContextOptions<TodoAppContext> options)
            : base(options)
        {
            DataSeeder.InsertTodoData(this);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ToDoSingleItemEntity>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Text).IsRequired();
                entity.HasOne(d => d.TodoListEntity)
                    .WithMany(p => p.ToDoSingleItemEntities);

            });

            modelBuilder.Entity<TodoListEntity>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired();
            });
        }
    }
}
