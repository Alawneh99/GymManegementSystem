using Gym_Manegement_API.Models.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gym_Manegement_API.Models.EntityConfigration
{
    public class GymClassesEntityConfigration : IEntityTypeConfiguration<GymClasses>
    {
        public void Configure(EntityTypeBuilder<GymClasses> builder)
        {
            builder.ToTable("GymClasses");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.IsActive).HasDefaultValue(true);
        }
    }
}
