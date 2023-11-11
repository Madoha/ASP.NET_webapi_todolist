using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ToDoList_web_api.Dto;
using ToDoList_web_api.Interfaces;
using ToDoList_web_api.Models.OnCreate;
using ToDoList_web_api.Models;
using ToDoList_web_api.Repository;

namespace ToDoList_web_api.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewerController : ControllerBase
    {
        private readonly IReviewerRepository _reviewerRepository;
        private readonly IMapper _mapper;
        public ReviewerController(IReviewerRepository reviewerRepository, IMapper mapper)
        {
            _reviewerRepository = reviewerRepository;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetReviewers()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var reviewers = _mapper.Map<List<ReviewerDto>>(_reviewerRepository.GeTReviewers());
            return Ok(reviewers);
        }
        [HttpGet("{reviewerId}")]
        public IActionResult GetReview(int reviewerId)
        {
            var reviewer = _mapper.Map<ReviewerDto>(_reviewerRepository.GetReviewer(reviewerId));
            return Ok(reviewer);
        }
        [HttpPost]
        public IActionResult CreateReviewer([FromBody] ReviewerCreateModel reviewer)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (reviewer == null)
                return BadRequest();

            var reviewerMap = _mapper.Map<Reviewer>(reviewer);

            if (!_reviewerRepository.CreateReviewer(reviewerMap))
                return BadRequest(ModelState);

            return Ok("Successfully created");
        }
        [HttpPut("{reviewerId}")]
        public IActionResult UpdateReview(int reviewerId, [FromBody] ReviewerCreateModel reviewer)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var reviewerMap = _mapper.Map<Reviewer>(reviewer);
            reviewerMap.Id = reviewerId;

            if (!_reviewerRepository.UpdateReviewer(reviewerMap))
                return BadRequest(ModelState);

            return Ok("Successfully updated");

        }
        [HttpDelete("{reviewerId}")]
        public IActionResult DeleteReview(int reviewerId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var reviewer = _reviewerRepository.GetReviewer(reviewerId);

            if (!_reviewerRepository.DeleteReviewer(reviewer))
                return BadRequest();

            return Ok("Succesfully deleted");
        }
    }
}
