using Microsoft.EntityFrameworkCore;
using static week3rad.Todo;
namespace week3rad
{
    public class TodoDb: DbContext
    {
        public TodoDb(DbContextOptions<TodoDb> options)
       : base(options) { }

        public DbSet<Todo> Todos => Set<Todo>();
    }
}
