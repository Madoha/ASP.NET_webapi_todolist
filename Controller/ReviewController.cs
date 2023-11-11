using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoList_web_api.Dto;
using ToDoList_web_api.Interfaces;
using ToDoList_web_api.Models;
using ToDoList_web_api.Models.OnCreate;

namespace ToDoList_web_api.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewRepository _reviewRepository;
        private readonly IMapper _mapper;
        public ReviewController(IReviewRepository reviewRepository, IMapper mapper)
        {
            _reviewRepository = reviewRepository;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetReviews() 
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var reviews = _mapper.Map<List<ReviewDto>>(_reviewRepository.GetReviews());
            return Ok(reviews);
        }
        [HttpGet("{reviewId}")]
        public IActionResult GetReview(int reviewId)
        {
            var review = _mapper.Map<ReviewDto>(_reviewRepository.GetReview(reviewId));
            return Ok(review);
        }
        [HttpPost]
        public IActionResult CreateReview([FromQuery] int taskId, [FromQuery] int reviewerId, [FromBody] ReviewCreateModel review)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (review == null)
                return BadRequest();

            var reviewMap = _mapper.Map<Review>(review);
            reviewMap.ReviewerId = reviewerId;
            reviewMap.ToDoListId = taskId;

            if (!_reviewRepository.CreateReview(reviewMap))
                return BadRequest(ModelState);

            return Ok("Successfully created");
        }
        [HttpPut("{reviewId}")]
        public IActionResult UpdateReview(int reviewId, [FromQuery] int taskId, [FromQuery] int reviewerId, [FromBody] ReviewCreateModel review)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var reviewMap = _mapper.Map<Review>(review);
            reviewMap.Id = reviewId;
            reviewMap.ToDoListId = taskId;
            reviewMap.ReviewerId = reviewerId;

            if (!_reviewRepository.UpdateReview(reviewMap))
                return BadRequest(ModelState);

            return Ok("Successfully updated");

        }
        [HttpDelete("{reviewId}")]
        public IActionResult DeleteReview(int reviewId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var review = _reviewRepository.GetReview(reviewId);

            if (!_reviewRepository.DeleteReview(review))
                return BadRequest();

            return Ok("Succesfully deleted");
        }
    }
}
