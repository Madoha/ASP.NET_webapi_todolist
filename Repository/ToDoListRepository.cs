using ToDoList_web_api.Data;
using ToDoList_web_api.Interfaces;
using ToDoList_web_api.Models;

namespace ToDoList_web_api.Repository
{
    public class ToDoListRepository : IToDoListRepository
    {
        private readonly AppDbContext _context;
        public ToDoListRepository(AppDbContext context)
        {
            _context = context;
        }
        public bool CreateToDoList(ToDoList toDoList)
        {
            _context.ToDoLists.Add(toDoList);
            return Save();
        }

        public bool DeleteToDoList(ToDoList toDoList)
        {
            _context.Remove(toDoList);
            return Save();
        }

        public ToDoList GetToDoList(int id)
        {
            return _context.ToDoLists.Where(t => t.Id == id).FirstOrDefault();
        }

        public ICollection<ToDoList> GetToDoLists()
        {
            return _context.ToDoLists.OrderBy(t => t.Id).ToList();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateToDoList(ToDoList toDoList)
        {
            _context.Update(toDoList);
            return Save();
        }
    }
}
