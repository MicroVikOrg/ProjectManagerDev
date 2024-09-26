using Microsoft.EntityFrameworkCore;
using Task = ProjectManagerDev.Models.Task;
namespace ProjectManagerDev.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Company> Companies { get; set; } = null!;
        public DbSet<Project> Projects { get; set; } = null!;
        public DbSet<Board> Boards { get; set; } = null!;
        public DbSet<Column> Columns { get; set; } = null!;
        public DbSet<Task> Tasks { get; set; } = null!;
        public DbSet<Tag> Tags { get; set; } = null!;
        public DbSet<TasksTags> TasksTags { get; set; } = null!;
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
