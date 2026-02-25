using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskManagerAPI.Data;
using TaskManagerAPI.Models;

namespace TaskManagerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TasksController : ControllerBase
    {
        private readonly AppDbContext _db;

        public TasksController(AppDbContext db)
        {
            _db = db;
        }

        // GET: /api/Tasks
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var tasks = await _db.Tasks.AsNoTracking().ToListAsync();
            return Ok(tasks);
        }

        // GET: api/Tasks/5
[HttpGet("{id}")]
public async Task<ActionResult<TaskItem>> GetById(int id)
{
    var task = await _db.Tasks.FindAsync(id);

    if (task == null)
    {
        return NotFound(); // 404
    }

    return Ok(task);
}


// PUT: api/Tasks/5
[HttpPut("{id}")]
public async Task<IActionResult> Update(int id, TaskItem updatedTask)
{
    var task = await _db.Tasks.FindAsync(id);

    if (task == null)
        return NotFound();

    // Mise à jour des champs
    task.Title = updatedTask.Title;
    task.Description = updatedTask.Description;
    task.IsCompleted = updatedTask.IsCompleted;

    await _db.SaveChangesAsync();

    return Ok(task);
}

// DELETE: api/Tasks/5
[HttpDelete("{id}")]
public async Task<IActionResult> Delete(int id)
{
    var task = await _db.Tasks.FindAsync(id);

    if (task == null)
        return NotFound();

    _db.Tasks.Remove(task);
    await _db.SaveChangesAsync();

    return NoContent(); // 204 = suppression réussie
}


        // POST: /api/Tasks
        [HttpPost]
        public async Task<IActionResult> Create(TaskItem task)
        {
            task.Id = 0; // laisser la DB générer l'Id
            _db.Tasks.Add(task);
            await _db.SaveChangesAsync();

            return Ok(task);
        }
    }
}
