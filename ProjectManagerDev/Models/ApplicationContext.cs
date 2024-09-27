using Microsoft.EntityFrameworkCore;
using Task = ProjectManagerDev.Models.Task;
namespace ProjectManagerDev.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Company> Company { get; set; } = null!;
        public DbSet<Project> Project { get; set; } = null!;
        public DbSet<Board> Board { get; set; } = null!;
        public DbSet<Column> Column { get; set; } = null!;
        public DbSet<Task> Task { get; set; } = null!;
        public DbSet<Tag> Tag { get; set; } = null!;
        public DbSet<TasksTags> TasksTags { get; set; } = null!;
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
