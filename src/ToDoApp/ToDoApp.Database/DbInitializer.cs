using System.Collections.Generic;
using System.Linq;
using ToDoApp.Database.Entities;

namespace ToDoApp.Database
{
    public class DbInitializer
    {
        public static void Initialize(TodoAppContext context)
        {
            context.Database.EnsureCreated();

            if (context.ToDoListEntities.Any() || context.ToDoItemEntities.Any())
            {
                return;
            }

            var toDoLists = new List<ToDoListEntity>
            {
                new ToDoListEntity
                {
                    Name = "School List"
                },
                new ToDoListEntity
                {
                    Name = "Home List"
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
