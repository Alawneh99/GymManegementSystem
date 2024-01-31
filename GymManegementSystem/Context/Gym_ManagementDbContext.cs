using Gym_Manegement_API.Models.Entity;
using Gym_Manegement_API.Models.EntityConfigration;
using Microsoft.EntityFrameworkCore;

namespace Gym_Manegement_API.Context
{
    public class Gym_ManagementDbContext:DbContext
    {
        public Gym_ManagementDbContext(DbContextOptions<Gym_ManagementDbContext> dbOptions):base(dbOptions)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new DepartmentEntityConfigration());
            modelBuilder.ApplyConfiguration(new GymClassesEntityConfigration());
            modelBuilder.ApplyConfiguration(new PersonEntityConfigration());
            modelBuilder.ApplyConfiguration(new PersonTypeEntityConfigration());
            modelBuilder.ApplyConfiguration(new SubscriptionsEntityConfigration());
        }
        public virtual DbSet<GymClasses> GymClasses { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Person> Persons { get; set; }
        public virtual DbSet<PersonType> PersonTypes { get; set; }
        public virtual DbSet<Subscriptions> Subscriptions { get; set; }
    }
}
