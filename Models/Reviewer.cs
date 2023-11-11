namespace ToDoList_web_api.Models
{
    public class Reviewer
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public DateTime WasCreated{ get; set; }
        public ICollection<Review> Reviews { get; set; }
    }
}
