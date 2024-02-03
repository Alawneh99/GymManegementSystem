using Gym_Manegement_API.Models.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gym_Manegement_API.Models.EntityConfigration
{
    public class DepartmentEntityConfigration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.ToTable("Department");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.IsActive).HasDefaultValue(true);
            builder.Property(d => d.ArabicName).IsRequired().HasMaxLength(50).IsUnicode();
        }
    }
}
