using bacit_dotnet.MVC.Entities;
using Microsoft.EntityFrameworkCore;

namespace bacit_dotnet.MVC.DataAccess
{
    public class DataContext : DbContext
    {
        public DataContext()
        {
        }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmployeeEntity>().HasKey(x => x.emp_id);
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<EmployeeEntity> Users { get; set; }
    }
}
