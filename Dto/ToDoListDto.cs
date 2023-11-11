namespace ToDoList_web_api.Dto
{
    public class ToDoListDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime WasCreated { get; set; }
    }
}
