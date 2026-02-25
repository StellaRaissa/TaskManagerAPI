using TaskManagerAPI.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskManagerAPI.Data;
using TaskManagerAPI.Models;
using TaskManagerAPI.Services;


namespace TaskManagerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TasksController : ControllerBase
    {
        private readonly ITaskService _taskService;

        public TasksController(ITaskService taskService)
            {
                _taskService = taskService;
            }


        /// GET: api/Tasks
[HttpGet]
public async Task<ActionResult<IEnumerable<TaskReadDto>>> GetAll()
{
    var tasks = await _taskService.GetAllAsync();
    return Ok(tasks);
}



        // GET: api/Tasks/5
[HttpGet("{id}")]
public async Task<ActionResult<TaskReadDto>> GetById(int id)
{
    var task = await _taskService.GetByIdAsync(id);

    if (task == null)
        return NotFound();

    return Ok(task);
}



        // POST: api/Tasks
[HttpPost]
public async Task<ActionResult<TaskReadDto>> Create(TaskCreateDto dto)
{
    var createdTask = await _taskService.CreateAsync(dto);
    return CreatedAtAction(nameof(GetById), new { id = createdTask.Id }, createdTask);
}


        // PUT: api/Tasks/5
[HttpPut("{id}")]
public async Task<IActionResult> Update(int id, TaskUpdateDto dto)
{
    var updated = await _taskService.UpdateAsync(id, dto);

    if (!updated)
        return NotFound();

    return NoContent();
}



        // DELETE: api/Tasks/3
        [HttpDelete("{id}")]
public async Task<IActionResult> Delete(int id)
{
    var deleted = await _taskService.DeleteAsync(id);

    if (!deleted)
        return NotFound();

    return NoContent();
}

    }
}
