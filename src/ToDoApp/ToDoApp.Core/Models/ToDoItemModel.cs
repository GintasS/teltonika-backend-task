using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoApp.Core.Models
{
    public class ToDoItemModel : ToDoItem
    {
        public int ListId { get; set; }
        public int ItemId { get; set; }
    }
}
