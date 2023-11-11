namespace ToDoList_web_api.Models
{
    public class Review
    {
        public int Id { get; set; }
        public string Title {  get; set; }
        public string Description { get; set; }
        public DateTime WasCreated { get; set; }
        public int Rating { get; set; }
        public int ReviewerId { get; set; }
        public int ToDoListId { get; set; }
        public Reviewer Reviewer { get; set; }
        public ToDoList ToDoList { get; set; }
    }
}
