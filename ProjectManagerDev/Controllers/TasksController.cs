using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectManagerDev.Models;
using ProjectManagerDev.Services;
using System;
using System.Threading.Tasks;

namespace ProjectManagerDev.Controllers
{
    [Route("api/projects/boards/columns/tasks")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly IDbManager<Models.Task> _dbManager;
        private ApplicationContext db;
        public TasksController(ApplicationContext context, IDbManagerFactory managerFactory)
        {
            db = context;
            _dbManager = managerFactory.GetDbManager<Models.Task>();
        }
        [HttpPost]
        public async Task<IActionResult> CreateTask([FromBody] Models.Task task)
        {
            var col = await db.Column.FirstOrDefaultAsync(e => e.Id == task.ColumnId);
            if (col == null) return BadRequest();
            await _dbManager.SaveAsync(task);
            return Ok();
        }
        [HttpGet]
        public async Task<IActionResult> GetTasks(string columnId)
        {
            var col = await db.Column.FirstOrDefaultAsync(e => e.Id == Guid.Parse(columnId));
            if (col == null) return BadRequest();
            return Ok(col.Tasks);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateTask([FromBody] Models.Task task)
        {
            var col = await db.Column.FirstOrDefaultAsync(e => e.Id == task.ColumnId);
            if (col == null) return BadRequest();
            await _dbManager.UpdateAsync(task);
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteTask(string taskId)
        {
            var task = await db.Task.FirstOrDefaultAsync(e => e.Id == Guid.Parse(taskId));
            if (task == null) return BadRequest();
            db.Task.Remove(task);
            return Ok();
        }
    }
}
