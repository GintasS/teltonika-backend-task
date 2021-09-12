using System;
using Microsoft.EntityFrameworkCore;
using ToDoApp.Database.Entities;
using ToDoApp.Database.Enums;

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
                entity.HasOne(d => d.ToDoListEntity)
                    .WithMany(p => p.ToDoItemEntities);

            });

            modelBuilder.Entity<UserEntity>(entity =>
                    entity.Property(e => e.Role)
                        .HasMaxLength(50)
                        .HasConversion(
                            v => v.ToString(),
                            v => (Role)Enum.Parse(typeof(Role), v))
                        .IsUnicode(false)
            );
        }
    }
}
