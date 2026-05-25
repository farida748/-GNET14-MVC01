
using GymManagment.Configration;
using GymManagment.Models;
using Microsoft.EntityFrameworkCore;

namespace GymManagment.DbContexts
{
    public class GymDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=GymManagment;Trusted_Connection=true;TrustServerCertificate=true");
        }

        override protected void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<Plan>(new PlanConfigration());
        }
    }
}