using Microsoft.EntityFrameworkCore;
using static lab4_1.Todo;
namespace lab4_1
{
    public class TodoDb: DbContext
    {
        public TodoDb(DbContextOptions<TodoDb> options)
       : base(options) { }

        public DbSet<Todo> Todos => Set<Todo>();
    }
}
