using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TodoList
{
    public class ListController : Controller
    {
        // GET GetList
        [HttpGet]
        public IEnumerable<TodoList.Todo> GetList()
        {
            using (TodoListDb db = new TodoListDb()) {
                return db.TodoLists.ToList();            
            }
        }

        [HttpPost]
        public void MakeList() {
            string connString = "Host=localhost;Username=myUsername;Password=myPassword;Database=TodoList";
            var db = new HandleDbConn(connString);
            db.Create("t1");
        }

        public void AddListItems([FromBody]JObject items) {
            JToken todoItems = items.GetValue("items");
            List<Todo> myTodos = todoItems.ToObject<List<Todo>>();
            string connString = 
                "Host=localhost;"+
                "Username=myUsername;"+
                "Password=myPassword;"+
                "Database=TodoList";
            var db = new HandleDbConn(connString);
            db.Add(myTodos, "t1");
        }
    }
}
