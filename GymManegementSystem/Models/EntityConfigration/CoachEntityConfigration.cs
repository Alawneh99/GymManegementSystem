using GymManegementSystem.Models.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GymManegementSystem.Models.EntityConfigration
{
    public class CoachEntityConfigration : IEntityTypeConfiguration<Coach>
    {
        public void Configure(EntityTypeBuilder<Coach> builder)
        {

            builder.ToTable("Coach");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.IsActive).HasDefaultValue(true);
            builder.Property(x => x.IsAvaible).HasDefaultValue(true);
        }
    }
}
