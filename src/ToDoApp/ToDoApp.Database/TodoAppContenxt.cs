using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using ToDoApp.Domain.Entities;

namespace ToDoApp.Database
{
    public class TodoAppContenxt : DbContext
    {
        public DbSet<ToDoSingleItemEntity> ToDoSingleItemEntities { get; set; }
        public DbSet<TodoListEntity> TodoListEntities { get; set; }

        public TodoAppContenxt(DbContextOptions<TodoAppContenxt> options)
            : base(options)
        {
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
