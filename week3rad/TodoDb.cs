using Microsoft.EntityFrameworkCore;
using static week3rad.ToDo;
namespace week3rad
{
    public class TodoDb: DbContext
    {
        public TodoDb(DbContextOptions<TodoDb> options)
       : base(options) { }

        public DbSet<ToDo> Todos => Set<ToDo>();
    }
}
