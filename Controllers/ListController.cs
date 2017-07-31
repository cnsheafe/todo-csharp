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
                return db.TodoLists.ToList();            }
        }

        [HttpPost]
        public void MakeList([FromBody]JObject list) {
            Todo posted = list.ToObject<Todo>();
            Console.WriteLine(list);
            using (TodoListDb db = new TodoListDb()) {
                db.TodoLists.Add(posted);
                db.SaveChanges();
            }
        }
    }
}
