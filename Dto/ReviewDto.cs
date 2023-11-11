namespace ToDoList_web_api.Dto
{
    public class ReviewDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime WasCreated { get; set; }
        public int Rating { get; set; }
        public int ReviewerId { get; set; }
        public int ToDoListId { get; set; }
    }
}
