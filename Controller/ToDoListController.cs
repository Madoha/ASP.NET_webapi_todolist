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
    public class ToDoListController : ControllerBase
    {
        private readonly IToDoListRepository _todolistRepository;
        private readonly IMapper _mapper;
        public ToDoListController(IToDoListRepository todolistRepository, IMapper mapper)
        {
            _todolistRepository = todolistRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetToDoLists()
        {
            var tasks = _mapper.Map<List<ToDoListDto>>(_todolistRepository.GetToDoLists());
            
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(tasks);
        }
        [HttpGet("{taskId}")]
        public IActionResult GetToDoList(int taskId)
        {
            var task = _mapper.Map<ToDoListDto>(_todolistRepository.GetToDoList(taskId));
            if (!ModelState.IsValid) 
                return BadRequest(ModelState);

            return Ok(task);
        }
        [HttpPost]
        public IActionResult CreateToDoList(ToDoListCreateModel toDoList)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var toDoListMap = _mapper.Map<ToDoList>(toDoList);
            if (!_todolistRepository.CreateToDoList(toDoListMap))
            {
                ModelState.AddModelError("", "something went wrong while creating");
                return BadRequest(ModelState);
            }
            return Ok("Successfully created");
        }
        [HttpPut("{taskId}")]
        public IActionResult UpdateToDoList(int taskId, [FromBody] ToDoListCreateModel toDoList)
        {
            var task = _todolistRepository.GetToDoList(taskId);
            task.Id = task.Id;
            if (!_todolistRepository.UpdateToDoList(task))
                return BadRequest(ModelState);

            return Ok("Successfully updated");
        }
        [HttpDelete("{taskId}")]
        public IActionResult DeleteToDoList(int taskId) 
        {
            var task = _todolistRepository.GetToDoList(taskId);
            if (!_todolistRepository.DeleteToDoList(task))
                return BadRequest(ModelState);

            return Ok("Successfully deleted");
        }
    }
}
