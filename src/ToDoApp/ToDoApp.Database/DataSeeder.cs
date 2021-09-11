using ToDoApp.Domain.Entities;

namespace ToDoApp.Database
{
    public class DataSeeder
    {
        public static void InsertTodoData(TodoAppContext context)
        {
            context.Database.EnsureCreated();

            // Add a single To do list.
            var toDoList1 = new TodoListEntity()
            {
                Name = "My First To Do List"
            };

            var toDoList2 = new TodoListEntity()
            {
                Name = "My Second To Do List"
            };

            context.TodoListEntities.Add(toDoList1);
            context.TodoListEntities.Add(toDoList2);

            // Add books to toDoList1.
            var entry1 = new ToDoSingleItemEntity
            {
                IsDone = false,
                Text = "My entry 1",
                TodoListEntity = toDoList1
            };

            var entry2 = new ToDoSingleItemEntity
            {
                IsDone = false,
                Text = "My entry 2",
                TodoListEntity = toDoList1
            };

            var entry3 = new ToDoSingleItemEntity
            {
                IsDone = false,
                Text = "My entry 3",
                TodoListEntity = toDoList1
            };

            var entry4 = new ToDoSingleItemEntity
            {
                IsDone = false,
                Text = "My entry 4",
                TodoListEntity = toDoList2
            };

            var entry5 = new ToDoSingleItemEntity
            {
                IsDone = false,
                Text = "My entry 5",
                TodoListEntity = toDoList2
            };

            context.ToDoSingleItemEntities.Add(entry1);
            context.ToDoSingleItemEntities.Add(entry2);
            context.ToDoSingleItemEntities.Add(entry3);
            context.ToDoSingleItemEntities.Add(entry4);
            context.ToDoSingleItemEntities.Add(entry5);

            context.SaveChanges();
            
        }
    }
}
