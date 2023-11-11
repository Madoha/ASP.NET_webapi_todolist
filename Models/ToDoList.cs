namespace ToDoList_web_api.Models
{
    public class ToDoList
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime WasCreated { get; set; }
        public ICollection<Review> Reviews { get; set; }
    }
}
