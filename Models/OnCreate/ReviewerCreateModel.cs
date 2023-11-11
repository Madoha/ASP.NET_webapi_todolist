namespace ToDoList_web_api.Models.OnCreate
{
    public class ReviewerCreateModel
    {
        public string Login { get; set; }
        public DateTime WasCreated { get; set; } = DateTime.Now;
    }
}
