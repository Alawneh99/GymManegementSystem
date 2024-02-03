using Gym_Manegement_API.Models.Entity;
using GymManegementSystem.DTO_s.Coach;

namespace GymManegementSystem.Models.Entity
{
    public class Coach
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int Age { get; set; }
        public string Specialization { get; set; }
        public string Gender { get; set; }
        public string CoachDescription { get; set; }
        public bool? IsActive { get; set; }

        public bool? IsAvaible { get; set; }
        public int DepartmentId { get; set; }

    }

}
