using ToDoList_web_api.Models;

namespace ToDoList_web_api.Interfaces
{
    public interface IReviewerRepository
    {
        ICollection<Reviewer> GeTReviewers();
        Reviewer GetReviewer(int id);
        bool CreateReviewer(Reviewer reviewer);
        bool UpdateReviewer(Reviewer reviewer);
        bool DeleteReviewer(Reviewer reviewer);
        bool Save();
    }
}
