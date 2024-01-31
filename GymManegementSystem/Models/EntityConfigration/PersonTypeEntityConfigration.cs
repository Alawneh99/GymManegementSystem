using Gym_Manegement_API.Models.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gym_Manegement_API.Models.EntityConfigration
{
    public class PersonTypeEntityConfigration : IEntityTypeConfiguration<PersonType>
    {
        public void Configure(EntityTypeBuilder<PersonType> builder)
        {
            builder.ToTable("PersonType");
            builder.HasKey(x => x.PersonTypeId);
            builder.Property(x => x.IsActive).HasDefaultValue(true);
        }
    }
}
