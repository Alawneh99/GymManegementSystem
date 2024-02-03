using Gym_Manegement_API.Models.Entity;
using GymManegementSystem.Models.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gym_Manegement_API.Models.EntityConfigration
{
    public class ClientEntityConfigration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.ToTable("Client");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.IsActive).HasDefaultValue(true);
        

        }
    }
}
