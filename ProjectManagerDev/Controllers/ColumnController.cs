using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectManagerDev.Models;
using ProjectManagerDev.Services;

namespace ProjectManagerDev.Controllers
{
    [Route("api/projects/boards/columns")]
    [ApiController]
    public class ColumnController : ControllerBase
    {
        private readonly IKafkaProducer _producer;
        private DbManager<Column> dbManager;
        private ApplicationContext db;


        public ColumnController(IKafkaProducer producer, IDbManagerFactory factory, ApplicationContext context)
        {
            _producer = producer;
            dbManager = factory.GetDbManager<Column>();
            db = context;
        }


        
        [HttpGet]
        public async Task<IActionResult> GetColumns(string boardId)
        {
            var board = await db.Board.FirstOrDefaultAsync(board => board.Id == Guid.Parse(boardId));
            return board == null ? BadRequest() : Ok(board.Columns);
            
        }

        [HttpPost]
        public async Task<IActionResult> CreateColumn([FromBody] Column column)
        {
            var board = await db.Board.FirstOrDefaultAsync(e => e.Id == column.BoardId);
            if (board == null) return BadRequest();
            await dbManager.SaveAsync(column);
            return Ok(board);
        }

        [HttpPut]
        public async Task<IActionResult> ColumnUpdate([FromBody] Column column)
        {
            var board = await db.Board.FirstOrDefaultAsync(e => e.Id == column.BoardId);
            if (board == null) return BadRequest();
            await dbManager.UpdateAsync(column);
            return Ok(column);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteColumn(string columnId)
        {
            var col = db.Column.FirstOrDefault(e => e.Id == Guid.Parse(columnId));
            if (col == null) return BadRequest();
            db.Column.Remove(col);
            await db.SaveChangesAsync();
            return Ok(col);
        }


    }
}
