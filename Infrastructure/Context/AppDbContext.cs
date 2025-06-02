using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace Infrastructure.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<TaskList> TaskLists { get; set; }
        public DbSet<TaskItem> TaskItems { get; set; }
        public DbSet<SharedTaskList> SharedTaskLists { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SharedTaskList>()
                .HasKey(sa => new { sa.TaskListId, sa.SharedWithUserId });

            modelBuilder.Entity<TaskList>()
                .HasMany(tl => tl.Tasks)
                .WithOne(t => t.TaskList)
                .HasForeignKey(t => t.TaskListId);

            modelBuilder.Entity<TaskList>()
                .HasMany(tl => tl.SharedWithUsers)
                .WithOne(sa => sa.TaskList)
                .HasForeignKey(sa => sa.TaskListId);
        }
    }
}
