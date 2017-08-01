using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TodoList {
    public class Todo {
       [Key]
        public int Id {get; set;}
        [Required]
        public string Description {get; set;}
        // public List<Item> Items {get; set;}
    }

    public class Item {
        [Key]
        public int ItemId {get; set;}
        public string Description {get; set;}
    }

}