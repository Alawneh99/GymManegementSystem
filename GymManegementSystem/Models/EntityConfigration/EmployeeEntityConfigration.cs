using GymManegementSystem.Models.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GymManegementSystem.Models.EntityConfigration
{
    public class EmployeeEntityConfigration : IEntityTypeConfiguration<Employe>
    {
        public void Configure(EntityTypeBuilder<Employe> builder)
        {

            builder.ToTable("Employee");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.IsActive).HasDefaultValue(true);
        }
    }
}
