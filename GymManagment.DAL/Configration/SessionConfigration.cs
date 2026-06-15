using GymManagment.DAL.Models;
using GymManagment.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GymManagment.DAL.Configuration
{
    internal class SessionConfiguration : IEntityTypeConfiguration<Session>
    {
        public void Configure(EntityTypeBuilder<Session> builder)
        {
            builder.ToTable(tb =>
            {
                tb.HasCheckConstraint(
                    "SessionCapacityCheck",
                    "Capacity BETWEEN 1 AND 25"
                );

                tb.HasCheckConstraint(
                    "SessionEndDateCheck",
                    "EndDate > StartDate"
                );
            });
        }
    }
}