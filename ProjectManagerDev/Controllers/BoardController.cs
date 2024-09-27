using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ProjectManagerDev.Models;
using ProjectManagerDev.Services;

namespace ProjectManagerDev.Controllers
{
    [Route("api/projects/boards")]
    [ApiController]
    public class BoardController : ControllerBase
    {

        private readonly IKafkaProducer _kafkaProducer;
        private DbManager<Board> dbManager;
        private ApplicationContext db;


        public BoardController(IKafkaProducer producer, ApplicationContext context, DbManagerFactory factory)
        {
            dbManager = factory.GetDbManager<Board>();
            _kafkaProducer = producer;
            db = context;
        }

        [Route("{projectId}")]
        [HttpGet]
        public async Task<IActionResult> GetBoards(string projectId)
        {
            var project = await db.Project.FirstOrDefaultAsync(e => e.Id == Guid.Parse(projectId));
            return project == null ? NotFound() : Ok(project.Boards);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBoard([FromBody] Board board)
        {
            var project = await db.Project.FirstOrDefaultAsync(project => project.Id == board.Id);
            if (project == null) return BadRequest();
            board.Project = project;
            await dbManager.SaveAsync(board,"NewBoards");
            return Ok(board);
        }

        [Route("{boardId}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteBoard(string boardId)
        {
            var board = await db.Board.FirstOrDefaultAsync(board => board.Id == Guid.Parse(boardId));
            if (board == null) return BadRequest();
            db.Board.Remove(board);
            await db.SaveChangesAsync();
            return Ok(board);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBoard([FromBody] Board board)
        {
            var project = await db.Project.FirstOrDefaultAsync(project => project.Id == board.ProjectId);
            if (project == null) return BadRequest();
            board.Project = project;
            await dbManager.UpdateAsync(board);
            return Ok(board);
        }

    }
}
