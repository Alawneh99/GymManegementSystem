using Gym_Manegement_API.Models.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gym_Manegement_API.Models.EntityConfigration
{
    public class SubscriptionsEntityConfigration : IEntityTypeConfiguration<Subscriptions>
    {
        public void Configure(EntityTypeBuilder<Subscriptions> builder)
        {
            builder.ToTable("Subscriptions");
            builder.HasKey(x => x.SubscriptionId);
            builder.Property(x => x.IsActive).HasDefaultValue(true);
        }
    }
}
