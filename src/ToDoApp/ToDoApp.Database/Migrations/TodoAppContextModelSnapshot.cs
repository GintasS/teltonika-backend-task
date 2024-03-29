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

            modelBuilder.Entity("ToDoApp.Database.Entities.PasswordRecoveryEntity", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("PasswordRecoveryStatus")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<int?>("UserEntityId")
                        .HasColumnType("int");

                    b.HasKey("UserId");

                    b.HasIndex("UserEntityId");

                    b.ToTable("PasswordRecoveryEntities");
                });

            modelBuilder.Entity("ToDoApp.Database.Entities.ToDoItemEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("IsDone")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("ToDoListEntityId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ToDoListEntityId");

                    b.ToTable("ToDoItemEntities");
                });

            modelBuilder.Entity("ToDoApp.Database.Entities.ToDoListEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("UserEntityId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserEntityId");

                    b.ToTable("ToDoListEntities");
                });

            modelBuilder.Entity("ToDoApp.Database.Entities.UserEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(767)");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("UserEntities");
                });

            modelBuilder.Entity("ToDoApp.Database.Entities.PasswordRecoveryEntity", b =>
                {
                    b.HasOne("ToDoApp.Database.Entities.UserEntity", "UserEntity")
                        .WithMany()
                        .HasForeignKey("UserEntityId");

                    b.Navigation("UserEntity");
                });

            modelBuilder.Entity("ToDoApp.Database.Entities.ToDoItemEntity", b =>
                {
                    b.HasOne("ToDoApp.Database.Entities.ToDoListEntity", "ToDoListEntity")
                        .WithMany("ToDoItemEntities")
                        .HasForeignKey("ToDoListEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ToDoListEntity");
                });

            modelBuilder.Entity("ToDoApp.Database.Entities.ToDoListEntity", b =>
                {
                    b.HasOne("ToDoApp.Database.Entities.UserEntity", "UserEntity")
                        .WithMany()
                        .HasForeignKey("UserEntityId");

                    b.Navigation("UserEntity");
                });

            modelBuilder.Entity("ToDoApp.Database.Entities.ToDoListEntity", b =>
                {
                    b.Navigation("ToDoItemEntities");
                });
#pragma warning restore 612, 618
        }
    }
}
