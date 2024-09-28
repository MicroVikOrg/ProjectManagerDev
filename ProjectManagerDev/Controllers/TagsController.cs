using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectManagerDev.Models;
using ProjectManagerDev.Services;
using System;
using System.Threading.Tasks;

namespace ProjectManagerDev.Controllers
{
    [Route("api/api/projects/boards/columns/tasks/tags")]
    [ApiController]
    public class TagsController : ControllerBase
    {
        private readonly IDbManager<Tag> _dbManager;
        private ApplicationContext db;

        public TagsController(ApplicationContext context, IDbManagerFactory managerFactory)
        {
            db = context;
            _dbManager = managerFactory.GetDbManager<Tag>();
        }
        [Route("tasktags")]
        [HttpGet]
        public async Task<IActionResult> GetTagsId(string taskId)
        {
            var tags = db.TasksTags.Where(e => e.TaskId == Guid.Parse(taskId));
            if (tags == null) return BadRequest();
            return Ok(tags);
        }
        [HttpGet]
        public async Task<IActionResult> GetTask(string taskId)
        {
            var task = await db.Task.FirstOrDefaultAsync(e => e.Id == Guid.Parse(taskId));
            if (task == null) return BadRequest();
            return Ok(task);
        }
        [HttpPost]
        public async Task<IActionResult> CreateTag([FromBody] Tag tag)
        {
            await _dbManager.SaveAsync(tag);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> UpdateTag([FromBody] Tag tag)
        {
            await _dbManager.UpdateAsync(tag);
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteTag(string tagId)
        {
            var tag = await db.Tag.FirstOrDefaultAsync(e => e.Id == Guid.Parse(tagId));
            if (tag == null) return BadRequest();
            db.Tag.Remove(tag);
            return Ok();
        }
        [Route("tasktags")]
        [HttpPost]
        public async Task<IActionResult> AddTaskTag(string taskId, string tagId)
        {
            var task = await db.Task.FirstOrDefaultAsync(e => e.Id == Guid.Parse(taskId));
            if (task == null) return BadRequest();
            var tag = await db.Tag.FirstOrDefaultAsync(e => e.Id == Guid.Parse(tagId));
            if (tag == null) return BadRequest();
            await db.TasksTags.AddAsync(new TasksTags()
            {
                Tag = tag,
                Task = task,
                TagId = Guid.Parse(tagId),
                TaskId = Guid.Parse(taskId)
            });
            await db.SaveChangesAsync();
            return Ok();
        }
        [Route("tasktags")]
        [HttpDelete]
        public async Task<IActionResult> DeleteTaskTag(string taskId, string tagId)
        {
            var task = await db.Task.FirstOrDefaultAsync(e => e.Id == Guid.Parse(taskId));
            if (task == null) return BadRequest();
            var tag = await db.Tag.FirstOrDefaultAsync(e => e.Id == Guid.Parse(tagId));
            if (tag == null) return BadRequest();
            db.TasksTags.Remove(new TasksTags()
            {
                Tag = tag,
                Task = task,
                TagId = Guid.Parse(tagId),
                TaskId = Guid.Parse(taskId)
            });
            await db.SaveChangesAsync();
            return Ok();
        }
    }
}
