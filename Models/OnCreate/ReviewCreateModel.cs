namespace ToDoList_web_api.Models.OnCreate
{
    public class ReviewCreateModel
    { 
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime WasCreated { get; set; } = DateTime.Now;
        public int Rating { get; set; }
    }
}
