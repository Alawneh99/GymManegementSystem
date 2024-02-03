using Gym_Manegement_API.Models.Entity;

namespace GymManegementSystem.Models.Entity
{
    public class Employe
    {
        public int Id  {get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int Age { get; set; }
        public bool? IsActive { get; set; }


        public int DepartmentId { get; set; }

        public virtual Department Department { get; set; }
    }
}
