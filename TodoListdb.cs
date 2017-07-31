using Microsoft.EntityFrameworkCore;

namespace TodoList {
    public class TodoListDb : DbContext {
        public DbSet<Todo> TodoLists {get; set;}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseNpgsql("Server=127.0.0.1; Port=5432; Database=TodoList; User Id=myUsername; Password=myPassword");
        }
    }
}