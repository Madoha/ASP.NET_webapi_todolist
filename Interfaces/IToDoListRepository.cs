using ToDoList_web_api.Models;

namespace ToDoList_web_api.Interfaces
{
    public interface IToDoListRepository
    {
        ICollection<ToDoList> GetToDoLists();
        ToDoList GetToDoList(int id);
        bool CreateToDoList(ToDoList toDoList);
        bool UpdateToDoList(ToDoList toDoList);
        bool DeleteToDoList(ToDoList toDoList);
        bool Save();
    }
}
