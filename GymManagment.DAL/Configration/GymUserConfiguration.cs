using GymManagment.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace GymManagment.DAL.Configration
{
    internal class GymUserConfiguration<T> : IEntityTypeConfiguration<T> where T : GymUser
    {
       

        public void Configure(EntityTypeBuilder<T> builder)
        {
           builder.Property(x => x.Name)
                .HasMaxLength(50)
                .HasColumnType("varchar");


            builder.Property(x => x.Email)
               .HasMaxLength(100)
               .HasColumnType("varchar");


            builder.HasIndex(x => x.Email).IsUnique();
            builder.HasIndex(x => x.Phone).IsUnique();

            builder.ToTable(
                tb =>{
                    tb.HasCheckConstraint("EmailCheck", "Email LIKE '_%@_%._%'");
                    tb.HasCheckConstraint("PhoneCheck", "Phone LIKE '01%' AND LEN(Phone) = 11");    
                }
                );

            builder.OwnsOne(x=>x.Adress, a =>
            {
                a.Property(p => p.Street)
                .HasMaxLength(30)
                .HasColumnName("street")

                .HasColumnType("varchar");
                a.Property(p => p.City)
                .HasMaxLength(30)
                .HasColumnName("city")
                .HasColumnType("varchar");
               
            });
        }
    }
}
