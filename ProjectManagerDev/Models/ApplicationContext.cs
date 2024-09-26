using Microsoft.EntityFrameworkCore;
using Task = ProjectManagerDev.Models.Task;
namespace ProjectManagerDev.Models
{
    public class ApplicationContext : DbContext
    {
        DbSet<Company> Companies { get; set; } = null!;
        DbSet<Project> Projects { get; set; } = null!;
        DbSet<Board> Boards { get; set; } = null!;
        DbSet<Column> Columns { get; set; } = null!;
        DbSet<Task> Tasks { get; set; } = null!;
        DbSet<Tag> Tags { get; set; } = null!;
        DbSet<TasksTags> TasksTags { get; set; } = null!;
        public ApplicationContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
