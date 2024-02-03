using Gym_Manegement_API.Context;
using Gym_Manegement_API.Models.Entity;
using GymManegementSystem.DTO_s.Admin;
using GymManegementSystem.DTO_s.Coach;
using GymManegementSystem.DTO_s.Department;
using GymManegementSystem.DTO_s.Employee;
using GymManegementSystem.DTO_s.Subscription;
using GymManegementSystem.Interface;
using GymManegementSystem.Models.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Crypto.Macs;

namespace GymManegementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase, IAdminInterface
    {
        private readonly Gym_ManagementDbContext _ManagementDbContext;
        public AdminController(Gym_ManagementDbContext context)
        {
            _ManagementDbContext = context;
        }
        #region Coach(Action)
        /// <summary>
        /// Retrieves all Coatches
        /// </summary>
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAllCoachesAction()
        {
            try
            {
                var coaches = await GetAllCoaches();
                return Ok(coaches);
            }
            catch(Exception ex)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }
        /// <summary>
        /// Create a Coach
        /// </summary>
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> CreateCoachAction(CoachDTO coachDTO)
        {
            try
            {
                await CreateCoach(coachDTO);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }
        /// <summary>
        ///  Update a Coach
        /// </summary>
        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> UpdateCoachAction(UpdateCoachDTO updateCoachDTO)
        {
            try
            {
                await UpdateCoach(updateCoachDTO);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }
        /// <summary>
        ///   Delete a Coach
        /// </summary>
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> DeleteCoachAction(int coachId)
        {
            try
            {
                await DeleteCoach(coachId);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }

        #endregion
        #region Coach(NoneAction)
        [NonAction]
        public async Task<List<CoachDTO>> GetAllCoaches()
        {
            var coaches = await _ManagementDbContext.Coaches
                .Where(x => x.IsActive == true)
                .Select(coach => new CoachDTO
                {
                    FirstName = coach.FirstName,
                    LastName = coach.LastName,
                    Email = coach.Email,
                    Phone = coach.Phone,
                    Age = coach.Age,
                    Specialization = coach.Specialization,
                    Gender = coach.Gender,
                    CoachDescription = coach.CoachDescription,
                    IsActive = coach.IsActive,
                    IsAvaible = coach.IsAvaible
                }).ToListAsync();

            return coaches;
        }




        [NonAction]
        public async Task CreateCoach(CoachDTO coachDTO)
        {
            var coach = new Coach();

            coach.FirstName = coachDTO.FirstName;
            coach.LastName = coachDTO.LastName;
            coach.Email = coachDTO.Email;
            coach.Phone = coachDTO.Phone;
            coach.Age = coachDTO.Age;
            coach.Specialization = coachDTO.Specialization;
            coach.Gender = coachDTO.Gender;
            coach.IsActive = coachDTO.IsActive;
            coach.CoachDescription = coachDTO.CoachDescription;
            coach.IsAvaible = coachDTO.IsAvaible;
            coach.DepartmentId = 1;
            await _ManagementDbContext.Coaches.AddAsync(coach);
            await _ManagementDbContext.SaveChangesAsync();

        }


        [NonAction]
        public async Task UpdateCoach(UpdateCoachDTO updateCoachDTO)
        {
            var coachToUpdate = await _ManagementDbContext.Coaches.SingleOrDefaultAsync(C => C.Id == updateCoachDTO.Id);
            coachToUpdate.FirstName = updateCoachDTO.FirstName;
            coachToUpdate.LastName = updateCoachDTO.LastName;
            coachToUpdate.Email = updateCoachDTO.Email;
            coachToUpdate.Phone = updateCoachDTO.Phone;
            coachToUpdate.Age = updateCoachDTO.Age;
            coachToUpdate.Specialization = updateCoachDTO.Specialization;
            coachToUpdate.Gender = updateCoachDTO.Gender;
            coachToUpdate.CoachDescription = updateCoachDTO.CoachDescription;
            coachToUpdate.IsActive = updateCoachDTO.IsActive;
            coachToUpdate.IsAvaible = updateCoachDTO.IsAvaible;

            await _ManagementDbContext.SaveChangesAsync();
        }


        [NonAction]
        public async Task DeleteCoach(int coachId)
        {
            var coachToDelete = await _ManagementDbContext.Coaches
                .FirstOrDefaultAsync(c => c.Id == coachId && c.IsActive != false);

            coachToDelete.IsActive = false;
            await _ManagementDbContext.SaveChangesAsync();
        }



        #endregion
        #region Admin(Action)
        /// <summary>
        ///  Get All Admins
        /// </summary>
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAllAdminsAction()
        {
            try
            {
                var admins = await GetAllAdmins();
                return Ok(admins);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }
        /// <summary>
        ///  Add an Admin
        /// </summary>
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> AddAdminAction(AdminDTO adminDTO)
        {
            try
            {
                await AddAdmin(adminDTO);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }
        /// <summary>
        ///  Update an Admin
        /// </summary>
        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> UpdateAdminAction(UpdateAdminDTO updateAdminDTO)
        {
            try
            {
                await UpdateAdmin(updateAdminDTO);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }
        /// <summary>
        ///  Delete an Admin
        /// </summary>
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> DeleteAdminAction(int adminId)
        {
            try
            {
                await DeleteAdmin(adminId);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }
        #endregion
        #region Admin(NoneAction)
        [NonAction]
        public async Task<List<AdminDTO>> GetAllAdmins()
        {
            var admins = await _ManagementDbContext.Admins
                            .Where(x => x.IsActive == true)
                            .Select(admin => new AdminDTO
                            {
                                FirstName = admin.FirstName,
                                LastName = admin.LastName,
                                Email = admin.Email,
                                Phone = admin.Phone,
                                Age = admin.Age,
                                IsActive = admin.IsActive,
                            }).ToListAsync();

            return admins;
        }

        [NonAction]
        public async Task AddAdmin(AdminDTO adminDTO)
        {
            var admin = new Admin
            {
                FirstName = adminDTO.FirstName,
                LastName = adminDTO.LastName,
                Email = adminDTO.Email,
                Phone = adminDTO.Phone,
                Age = adminDTO.Age,
                IsActive = adminDTO.IsActive,
            };

            await _ManagementDbContext.Admins.AddAsync(admin);
            await _ManagementDbContext.SaveChangesAsync();
        }

        [NonAction]
        public async Task UpdateAdmin(UpdateAdminDTO updateAdminDTO)
        {
            var adminToUpdate = await _ManagementDbContext.Admins.SingleOrDefaultAsync(c => c.Id == updateAdminDTO.Id);
            {
                adminToUpdate.FirstName = updateAdminDTO.FirstName;
                adminToUpdate.LastName = updateAdminDTO.LastName;
                adminToUpdate.Email = updateAdminDTO.Email;
                adminToUpdate.Phone = updateAdminDTO.Phone;
                adminToUpdate.Age = updateAdminDTO.Age;
                adminToUpdate.IsActive = updateAdminDTO.IsActive;

                await _ManagementDbContext.SaveChangesAsync();
            }
        }

        [NonAction]
        public async Task DeleteAdmin(int adminId)
        {
            var adminToDelete = await _ManagementDbContext.Admins
            .FirstOrDefaultAsync(c => c.Id == adminId && c.IsActive != false);
            await _ManagementDbContext.SaveChangesAsync();          
        }


        #endregion
        #region Department(Action)
        /// <summary>
        ///   Create a Department
        /// </summary>
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> CreateDepartmentAction(DepartmentDTO departmentDTO)
        {
            try
            {
                await CreateDepartment(departmentDTO);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }
        /// <summary>
        ///   Update a Department
        /// </summary>
        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> UpdateDepartmentAction(UpdateDepartmentDTO updateDepartmentDTO)
        {
            try
            {
                await UpdateDepartment(updateDepartmentDTO);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }
        /// <summary>
        ///   Delete a Department
        /// </summary>
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> DeleteDepartmentAction(int departmentId)
        {
            try
            {
                await DeleteDepartment(departmentId);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }
        /// <summary>
        ///   Get All Department
        /// </summary>
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAllDepartmentAction()
        {
            try
            {
                var departments = await GetAllDepartment();
                return Ok(departments);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }
        #endregion
        #region Department(NoneAction)

        [NonAction]
        
        public async Task CreateDepartment(DepartmentDTO departmentDTO)
        {
            var department = new Department
            {
                ArabicName = departmentDTO.ArabicName,
                EnglishName = departmentDTO.EnglishName,
                Description = departmentDTO.Description,
                IsActive = departmentDTO.IsActive
            };

            await _ManagementDbContext.Departments.AddAsync(department);
            await _ManagementDbContext.SaveChangesAsync();
        }

        [NonAction]
        public async Task UpdateDepartment(UpdateDepartmentDTO updateDepartmentDTO)
        {
            var departmentToUpdate = await _ManagementDbContext.Departments.SingleOrDefaultAsync(c => c.Id == updateDepartmentDTO.Id);
                departmentToUpdate.ArabicName = updateDepartmentDTO.ArabicName;
                departmentToUpdate.EnglishName = updateDepartmentDTO.EnglishName;
                departmentToUpdate.Description = updateDepartmentDTO.Description;
                departmentToUpdate.IsActive = updateDepartmentDTO.IsActive;
                await _ManagementDbContext.SaveChangesAsync();     
        }
        [NonAction]
        public async Task DeleteDepartment(int departmentId)
        {
            var departmentToDelete = await _ManagementDbContext.Departments
                .FirstOrDefaultAsync(c => c.Id == departmentId && c.IsActive != false);
                await _ManagementDbContext.SaveChangesAsync();
        }
        [NonAction]
        public async Task<List<DepartmentDTO>> GetAllDepartment()
        {
            var departments = await _ManagementDbContext.Departments
        .Where(x => x.IsActive == true)
        .Select(department => new DepartmentDTO
        {
            ArabicName = department.ArabicName,
            EnglishName = department.EnglishName,
            Description = department.Description,
            IsActive = department.IsActive
        }).ToListAsync();

            return departments;
        }
        #endregion
        #region Employee(Action)
        /// <summary>
        ///   Get All Employees
        /// </summary>
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAllEmployeesAction()
        {
            try
            {
                var employees = await GetAllEmployees();
                return Ok(employees);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }
        /// <summary>
        ///  Create an Employee
        /// </summary>
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> CreateEmployeeAction(EmployeeDTO employeeDTO)
        {
            try
            {
                await AddEmployee(employeeDTO);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }
        /// <summary>
        ///  Update an Employee
        /// </summary>
        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> UpdateEmployeeAction(UpdateEmployeeDTO updateEmployeeDTO)
        {
            try
            {
                await UpdateEmployee(updateEmployeeDTO);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }
        /// <summary>
        ///  Delete an Employee
        /// </summary>
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> DeleteEmployeeAction(int employeeId)
        {
            try
            {
                await DeleteEmployee(employeeId);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }
        #endregion
        #region Employee(NoneAction)
        [NonAction]
        public async Task<List<EmployeeDTO>> GetAllEmployees()
        {
            var employees = await _ManagementDbContext.Employes
                .Where(x => x.IsActive == true)
                .Select(employee => new EmployeeDTO
                {
                    FirstName = employee.FirstName,
                    LastName = employee.LastName,
                    Email = employee.Email,
                    Phone = employee.Phone,
                    Age = employee.Age,
                    IsActive = employee.IsActive,
                }).ToListAsync();

            return employees;
        }

        [NonAction]
        public async Task AddEmployee(EmployeeDTO employeeDTO)
        {
            var employee = new Employe
            {
                FirstName = employeeDTO.FirstName,
                LastName = employeeDTO.LastName,
                Email = employeeDTO.Email,
                Phone = employeeDTO.Phone,
                Age = employeeDTO.Age,
                IsActive = employeeDTO.IsActive,
            };

            await _ManagementDbContext.Employes.AddAsync(employee);
            await _ManagementDbContext.SaveChangesAsync();
        }

        [NonAction]
        public async Task UpdateEmployee(UpdateEmployeeDTO updateEmployeeDTO)
        {
            var employeeToUpdate = await _ManagementDbContext.Employes.SingleOrDefaultAsync(c => c.Id == updateEmployeeDTO.Id);

                employeeToUpdate.FirstName = updateEmployeeDTO.FirstName;
                employeeToUpdate.LastName = updateEmployeeDTO.LastName;
                employeeToUpdate.Email = updateEmployeeDTO.Email;
                employeeToUpdate.Phone = updateEmployeeDTO.Phone;
                employeeToUpdate.Age = updateEmployeeDTO.Age;
                employeeToUpdate.IsActive = updateEmployeeDTO.IsActive;

                await _ManagementDbContext.SaveChangesAsync();    
        }

        [NonAction]
        public async Task DeleteEmployee(int employeeId)
        {
            var employeeToDelete = await _ManagementDbContext.Employes
                .FirstOrDefaultAsync(c => c.Id == employeeId && c.IsActive != false);
                await _ManagementDbContext.SaveChangesAsync();       
        }
        #endregion
        #region Subscription(Action)
        /// <summary>
        /// Get All Subscriptions
        /// </summary>
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAllSubscriptionsAction()
        {
            try
            {
                var subscriptions = await GetAllSubscriptions();
                return Ok(subscriptions);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }
        /// <summary>
        ///  Create a Subscription
        /// </summary>
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> CreateSubscriptionAction(SubscriptionDTO subscriptionDTO)
        {
            try
            {
                await CreateSubscription(subscriptionDTO);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }
        /// <summary>
        ///  Update a Subscription
        /// </summary>
        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> UpdateSubscriptionAction(UpdateSubscriptionDTO updateSubscriptionDTO)
        {
            try
            {
                await UpdateSubscription(updateSubscriptionDTO);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }
        /// <summary>
        ///  Delete a Subscription
        /// </summary>
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> DeleteSubscriptionAction(int subscriptionId)
        {
            try
            {
                await DeleteSubscription(subscriptionId);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }
        /// <summary>
        ///   Deactivate a Subscription
        /// </summary>
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> DeactivateSubscriptionAction(int subscriptionId)
        {
            try
            {
                await DeactivateSubscription(subscriptionId);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }
        /// <summary>
        ///   Reactivate a Subscription
        /// </summary>
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> ReactivateSubscriptionAction(int subscriptionId)
        {
            try
            {
                await ReactivateSubscription(subscriptionId);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }
        #endregion
        #region Subscription(NoneAction)
        [NonAction]
        public async Task<List<SubscriptionDTO>> GetAllSubscriptions()
        {
            var subscriptions = await _ManagementDbContext.Subscriptions
                .Where(x => x.IsActive == true)
                .Select(subscription => new SubscriptionDTO
                {
                    Name = subscription.Name,
                    Description = subscription.Description,
                    Price = subscription.Price,
                    DurationInDays = subscription.DurationInDays,
                    TrainingHoursPerDay = subscription.TrainingHoursPerDay,
                    IsActive = subscription.IsActive,
                    IsAvaible = subscription.IsAvaible,
                    MembershipPlan = subscription.MembershipPlan,
                    ClassSubscriptionPlan = subscription.ClassSubscriptionPlan,
                    Duration = subscription.Duration
                }).ToListAsync();

            return subscriptions;
        }

        [NonAction]
        public async Task CreateSubscription(SubscriptionDTO subscriptionDTO)
        {
            var subscription = new Subscriptions
            {
                Name = subscriptionDTO.Name,
                Description = subscriptionDTO.Description,
                Price = subscriptionDTO.Price,
                DurationInDays = subscriptionDTO.DurationInDays,
                TrainingHoursPerDay = subscriptionDTO.TrainingHoursPerDay,
                IsActive = subscriptionDTO.IsActive,
                IsAvaible = subscriptionDTO.IsAvaible,
                MembershipPlan = subscriptionDTO.MembershipPlan,
                ClassSubscriptionPlan = subscriptionDTO.ClassSubscriptionPlan,
                Duration = subscriptionDTO.Duration
            };

            await _ManagementDbContext.Subscriptions.AddAsync(subscription);
            await _ManagementDbContext.SaveChangesAsync();
        }

        [NonAction]
        public async Task UpdateSubscription(UpdateSubscriptionDTO updateSubscriptionDTO)
        {
            var subscriptionToUpdate = await _ManagementDbContext.Subscriptions.SingleOrDefaultAsync(c => c.Id == updateSubscriptionDTO.Id);
                subscriptionToUpdate.Name = updateSubscriptionDTO.Name;
                subscriptionToUpdate.Description = updateSubscriptionDTO.Description;
                subscriptionToUpdate.Price = updateSubscriptionDTO.Price;
                subscriptionToUpdate.DurationInDays = updateSubscriptionDTO.DurationInDays;
                subscriptionToUpdate.TrainingHoursPerDay = updateSubscriptionDTO.TrainingHoursPerDay;
                subscriptionToUpdate.IsActive = updateSubscriptionDTO.IsActive;
                subscriptionToUpdate.IsAvaible = updateSubscriptionDTO.IsAvaible;
                subscriptionToUpdate.MembershipPlan = updateSubscriptionDTO.MembershipPlan;
                subscriptionToUpdate.ClassSubscriptionPlan = updateSubscriptionDTO.ClassSubscriptionPlan;
                subscriptionToUpdate.Duration = updateSubscriptionDTO.Duration;
                await _ManagementDbContext.SaveChangesAsync();
        }

        [NonAction]
        public async Task DeleteSubscription(int subscriptionId)
        {
            var subscriptionToDelete = await _ManagementDbContext.Subscriptions
                .FirstOrDefaultAsync(c => c.Id == subscriptionId && c.IsActive != false);
                subscriptionToDelete.IsActive = false;
                await _ManagementDbContext.SaveChangesAsync(); 
        }
        [NonAction]
        public async Task DeactivateSubscription(int subscriptionId)
        {
            var subscriptionToDeactivate = await _ManagementDbContext.Subscriptions
                .FirstOrDefaultAsync(c => c.Id == subscriptionId && c.IsActive != false);

            if (subscriptionToDeactivate != null)
            {
                subscriptionToDeactivate.IsActive = false;
                await _ManagementDbContext.SaveChangesAsync();
            }
        }

        [NonAction]
        public async Task ReactivateSubscription(int subscriptionId)
        {
            var subscriptionToReactivate = await _ManagementDbContext.Subscriptions
                .FirstOrDefaultAsync(c => c.Id == subscriptionId && c.IsActive != true);

            if (subscriptionToReactivate != null)
            {
                subscriptionToReactivate.IsActive = true;
                await _ManagementDbContext.SaveChangesAsync();
            }
        }
        #endregion
    }
}
