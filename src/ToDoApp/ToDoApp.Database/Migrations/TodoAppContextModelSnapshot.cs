﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ToDoApp.Database;

namespace ToDoApp.Database.Migrations
{
    [DbContext(typeof(TodoAppContext))]
    partial class TodoAppContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.5");

            modelBuilder.Entity("ToDoApp.Domain.Entities.ToDoItemEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("IsDone")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("ToDoListEntityId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ToDoListEntityId");

                    b.ToTable("ToDoItemEntities");
                });

            modelBuilder.Entity("ToDoApp.Domain.Entities.ToDoListEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("ToDoListEntities");
                });

            modelBuilder.Entity("ToDoApp.Domain.Entities.ToDoItemEntity", b =>
                {
                    b.HasOne("ToDoApp.Domain.Entities.ToDoListEntity", "ToDoListEntity")
                        .WithMany("ToDoItemEntities")
                        .HasForeignKey("ToDoListEntityId");

                    b.Navigation("ToDoListEntity");
                });

            modelBuilder.Entity("ToDoApp.Domain.Entities.ToDoListEntity", b =>
                {
                    b.Navigation("ToDoItemEntities");
                });
#pragma warning restore 612, 618
        }
    }
}