using Microsoft.EntityFrameworkCore;
using web_api.Models.Home;
using web_api.Models.Info;
using web_api.Models.Project;

namespace web_api.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {}
        
        // Home
        public DbSet<Shortcut> Shortcuts { get; set; }
        public DbSet<Category> Categorys { get; set; }
        public DbSet<ShortcutCategory> ShortcutCategorys { get; set; }
        
        
        // Infoscreen
        public DbSet<Deadline> Deadlines { get; set; }
        public DbSet<Event> Events { get; set; }
        
        // Tasks
        public DbSet<ProjectTask> ProjectTasks { get; set; }
        
        // Auth
        public DbSet<User> Users { get; set; }

    }
}