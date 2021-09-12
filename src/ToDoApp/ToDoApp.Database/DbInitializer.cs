using System.Collections.Generic;
using System.Linq;
using ToDoApp.Database.Entities;
using ToDoApp.Database.Enums;

namespace ToDoApp.Database
{
    public class DbInitializer
    {
        public static void Initialize(TodoAppContext context)
        {
            context.Database.EnsureCreated();

            if (context.ToDoListEntities.Any() || context.ToDoItemEntities.Any() || context.UserEntities.Any())
            {
                return;
            }

            var users = new List<UserEntity>()
            {
                new UserEntity
                {
                    Email = "svedgintas@gmail.com",
                    Password = "123456789012345",
                    Role = Role.Admin
                },
                new UserEntity
                {
                    Email = "svedgintas123@gmail.com",
                    Password = "123456789012345",
                    Role = Role.User
                },
                new UserEntity
                {
                    Email = "aaaa@email.com",
                    Password = "123456789012345",
                    Role = Role.User
                },
            };

            var toDoLists = new List<ToDoListEntity>
            {
                new ToDoListEntity
                {
                    Name = "School List",
                    UserEntity = users[0]
                },
                new ToDoListEntity
                {
                    Name = "Home List",
                    UserEntity = users[1]
                }
            };

            var toDoItems = new List<ToDoItemEntity>
            {
                new ToDoItemEntity
                {
                    Name = "Write an essay.",
                    ToDoListEntity = toDoLists[0]
                },
                new ToDoItemEntity
                {
                    Name = "Finish math exercise.",
                    ToDoListEntity = toDoLists[0]
                },
                new ToDoItemEntity
                {
                    Name = "Attend classes.",
                    ToDoListEntity = toDoLists[0]
                },
                new ToDoItemEntity
                {
                    Name = "Clean bathroom.",
                    ToDoListEntity = toDoLists[1]
                },
                new ToDoItemEntity
                {
                    Name = "Scrub floors.",
                    ToDoListEntity = toDoLists[1]
                }
            };

            foreach (var todoList in toDoLists)
            {
                context.ToDoListEntities.Add(todoList);
            }

            foreach (var todoItem in toDoItems)
            {
                context.ToDoItemEntities.Add(todoItem);
            }

            foreach (var user in users)
            {
                context.UserEntities.Add(user);
            }

            context.SaveChanges();
        }
    }
}
