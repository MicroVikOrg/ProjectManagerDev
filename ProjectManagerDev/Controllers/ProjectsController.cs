using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ProjectManagerDev.Models;
using ProjectManagerDev.Services;

namespace ProjectManagerDev.Controllers
{
    [Route("api/projects")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly IKafkaProducer _kafkaProducer;
        private ApplicationContext db;

        public ProjectsController(ApplicationContext applicationContext, IKafkaProducer kafkaProducer)
        {
            _kafkaProducer = kafkaProducer;
            db = applicationContext;
        }

        [Route("{companyId}")]
        [HttpGet]
        public async Task<IActionResult> GetProjects(string companyId)
        {
            var company = await db.Company.FirstOrDefaultAsync(e => Guid.Parse(companyId) == e.Id);
            return company == null ? NotFound() : Ok(company.Projects);
        }
        [HttpPost]
        public async Task<IActionResult> CreateProject([FromBody] Project projectModel)
        {
            var company = await db.Company.FirstOrDefaultAsync(e => projectModel.CompanyId == e.Id);
            if (company == null) return BadRequest();
            var project = new Project(projectModel) { Company = company! };
            await _kafkaProducer.ProduceMessage("NewProjects", JsonConvert.SerializeObject(project));
            await db.Project.AddAsync(project);
            await db.SaveChangesAsync();
            return Ok(project);
        }

        [Route("{projectId}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteProject(string projectId)
        {
            var project = await db.Project.FirstOrDefaultAsync(e => e.Id == Guid.Parse(projectId));
            if (project == null) return BadRequest();
            db.Project.Remove(project);
            await db.SaveChangesAsync();
            return Ok(project);
        }


        [HttpPut]
        public async Task<IActionResult> UpdateProject([FromBody] Project projectModel)
        {
            var company = await db.Company.FirstOrDefaultAsync(e => projectModel.CompanyId == e.Id);
            if (company == null) return BadRequest();
            var project = new Project(projectModel) { Company = company! };
            await _kafkaProducer.ProduceMessage("ProjectUpdates", JsonConvert.SerializeObject(project));
            db.Project.Update(project);
            await db.SaveChangesAsync();
            return Ok(project);
        }
    }
}
