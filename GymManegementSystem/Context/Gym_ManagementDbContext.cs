using Gym_Manegement_API.Models.Entity;
using Gym_Manegement_API.Models.EntityConfigration;
using GymManegementSystem.Models.Entity;
using GymManegementSystem.Models.EntityConfigration;
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
            modelBuilder.ApplyConfiguration(new AdminEntityConfigration());
            modelBuilder.ApplyConfiguration(new EmployeeEntityConfigration());
            modelBuilder.ApplyConfiguration(new CoachEntityConfigration());
            modelBuilder.ApplyConfiguration(new ClientEntityConfigration());
            modelBuilder.ApplyConfiguration(new SubscriptionsEntityConfigration());
        }
        public virtual DbSet<GymClasses> GymClasses { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Coach> Coaches { get; set; }
        public virtual DbSet<Employe> Employes { get; set; }
        public virtual DbSet<Subscriptions> Subscriptions { get; set; }
    }
}
