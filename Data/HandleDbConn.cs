using Npgsql;
using System.Collections.Generic;
namespace TodoList
{
    public class HandleDbConn {
        NpgsqlConnection conn = new NpgsqlConnection();
        public HandleDbConn(string connString) {
            conn.ConnectionString = connString;  
            conn.Open();
        }

        public void Create(string tableName) {
            var cmd = new NpgsqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = 
                $"CREATE TABLE {tableName}("+
                "id serial NOT NULL PRIMARY KEY,"+
                "description VARCHAR)";
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void Add(List<Todo> items, string tableName) {
            string query = 
                $"INSERT INTO {tableName} (description)"+
                "VALUES";
            foreach (Todo item in items) {
                query +=
                    $"('{item.Description}'),";
            }
            query = query.Substring(0, query.Length-1);
            var cmd = new NpgsqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = query;
            cmd.ExecuteNonQuery();
            conn.Close();
        } 
    }
}