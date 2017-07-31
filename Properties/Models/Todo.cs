using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TodoList {
    public class Todo {
        // public class Item {
        //     int index;
        //     string description;
        // }
       [Key]
        public int Id {get; set;}
        [Required]
        public string Description {get; set;}
        // public virtual List<Item> Items {get; set;}
    }

    // public class Item {
    //     public int ItemId {get; set;}
    //     public string Description {get; set;}
    // }

}