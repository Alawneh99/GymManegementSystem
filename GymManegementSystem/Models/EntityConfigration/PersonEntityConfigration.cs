using Gym_Manegement_API.Models.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gym_Manegement_API.Models.EntityConfigration
{
    public class PersonEntityConfigration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.ToTable("Person");
            builder.HasKey(p => p.PersonId);
            builder.Property(p => p.IsActive).HasDefaultValue(true);
        }
    }
}
