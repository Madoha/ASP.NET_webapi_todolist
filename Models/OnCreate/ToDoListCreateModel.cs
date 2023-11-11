namespace ToDoList_web_api.Models.OnCreate
{
    public class ToDoListCreateModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime WasCreated { get; set; } = DateTime.Now;
    }
}
