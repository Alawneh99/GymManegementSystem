using GymManegementSystem.DTO_s.Admin;
using GymManegementSystem.DTO_s.Coach;
using GymManegementSystem.DTO_s.Department;
using GymManegementSystem.DTO_s.Employee;
using GymManegementSystem.DTO_s.Subscription;


namespace GymManegementSystem.Interface
{
    public interface IAdminInterface
    {
        //Coach Operations
        Task<List<CoachDTO>> GetAllCoaches();    
        Task CreateCoach(CoachDTO coachDTO);
        Task UpdateCoach(UpdateCoachDTO UpdateCoachDTO);
        Task DeleteCoach(int coachId);

        //Employee Operations
        Task<List<EmployeeDTO>> GetAllEmployees();
        Task AddEmployee(EmployeeDTO employeeDTO);
        Task UpdateEmployee(UpdateEmployeeDTO updateEmployeeDTO);
        Task DeleteEmployee(int employeeId);

        // Department Operations
        Task<List<DepartmentDTO>> GetAllDepartment();

        Task CreateDepartment(DepartmentDTO departmentDTO);
        Task UpdateDepartment(UpdateDepartmentDTO updateDepartmentDTO);
        Task DeleteDepartment(int departmentId);


        // Subscription Operations
        Task<List<SubscriptionDTO>> GetAllSubscriptions();
        Task CreateSubscription(SubscriptionDTO subscriptionDTO);
        Task UpdateSubscription(UpdateSubscriptionDTO updateSubscriptionDTO);
        Task DeleteSubscription(int subscriptionId);
        Task DeactivateSubscription(int subscriptionId);
        Task ReactivateSubscription(int subscriptionId);

        // Admin Operations
        Task<List<AdminDTO>> GetAllAdmins();
        Task AddAdmin(AdminDTO adminDTO);
        Task UpdateAdmin(UpdateAdminDTO updateAdminDTO);
        Task DeleteAdmin(int adminId);

    }
}
