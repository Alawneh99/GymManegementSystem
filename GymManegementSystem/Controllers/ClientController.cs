using Gym_Manegement_API.Context;
using GymManegementSystem.DTO_s.Client;
using GymManegementSystem.DTO_s.Coach;
using GymManegementSystem.DTO_s.Subscription;
using GymManegementSystem.Interface;
using GymManegementSystem.Models.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TicketCoder.DTOs.Authantication;

namespace GymManegementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase,IClientInterface
    {
        private readonly Gym_ManagementDbContext _ManagementDbContext;
        public ClientController(Gym_ManagementDbContext context)
        {
            _ManagementDbContext = context;
        }
        #region Subscription(Action)
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

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> SearchSubscriptionsAction(float? maxPrice, int? durationInDays, string title)
        {
            try
            {
                var subscriptions = await SearchSubscriptions(maxPrice, durationInDays, title);
                return Ok(subscriptions);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> RegisterInSubscriptionAction(int clientId, int subscriptionId)
        {
            try
            {
                var isSuccess = await RegisterInSubscription(clientId, subscriptionId);
                if (isSuccess)
                {
                    return Ok("Registration successful");
                }
                else
                {
                    return BadRequest("Registration failed");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }

        #endregion
        #region Coach(Action)
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAllCoachesAction()
        {
            try
            {
                var coaches = await GetAllCoaches();
                return Ok(coaches);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error");
            }
        }
        #endregion
        #region Account(Action)
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> CreateAccountAction(ClientAccountDTO clientAccountDTO)
        {
            try
            {
                await CreateAccount(clientAccountDTO);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error {ex.Message}");
            }
        }
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> LoginAction(LoginDTO dto)
        {
            try
            {
                await Login(dto);
                return new ObjectResult(null) { StatusCode = 201, Value = "Login Success" };
            }
            catch (Exception ex)
            {
                return new ObjectResult(null) { StatusCode = 500, Value = $"Login Failed {ex.Message}" };
            }
        }
        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> ResetPasswordAction(ResetPasswordDTO dto)
        {
            try
            {
                await ResetPassword(dto);
                return new ObjectResult(null) { StatusCode = 201, Value = "ResetPassword Success" };
            }
            catch (Exception ex)
            {
                return new ObjectResult(null) { StatusCode = 500, Value = $"ResetPassword Failed {ex.Message}" };
            }
        }
        #endregion
        #region Subsription(NoneAction)
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
        public async Task<List<SubscriptionDTO>> SearchSubscriptions(float? maxPrice, int? durationInDays, string title)
        {
            var query = _ManagementDbContext.Subscriptions
                .Where(x => x.IsActive == true);

            if (maxPrice.HasValue)
                query = query.Where(subscription => subscription.Price <= maxPrice.Value);

            if (durationInDays.HasValue)
                query = query.Where(subscription => subscription.DurationInDays == durationInDays.Value);

            if (!string.IsNullOrEmpty(title))
                query = query.Where(subscription => subscription.Name.Contains(title));

            var subscriptions = await query
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
        public async Task<bool> RegisterInSubscription(int clientId, int subscriptionId)
        {
            var client = await _ManagementDbContext.Clients.FindAsync(clientId);
            var subscription = await _ManagementDbContext.Subscriptions.FindAsync(subscriptionId);

            if (client != null && subscription != null)
            {
                client.Subscriptions = subscription;
                await _ManagementDbContext.SaveChangesAsync();
                return true;
            }

            return false;
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
        #endregion
        #region Account(NoneAction)
        [NonAction]
        public async Task CreateAccount(ClientAccountDTO clientAccountDTO)
        {
            var client = new Client
            {
                Email = clientAccountDTO.Email,
                Phone = clientAccountDTO.Phone,
                Password = clientAccountDTO.Password,
                FullName = clientAccountDTO.FullName,
                BirthDate = clientAccountDTO.BirthDate,
                EmergencyContactName = clientAccountDTO.EmergencyContactName,
                EmergencyContactPhone = clientAccountDTO.EmergencyContactPhone,
                IsActive = true
            };

            await _ManagementDbContext.Clients.AddAsync(client);
            await _ManagementDbContext.SaveChangesAsync();
        }
        [NonAction]
        public async Task Login(LoginDTO dto)
        {
            if (string.IsNullOrEmpty(dto.Email) || string.IsNullOrEmpty(dto.Password))
                throw new Exception("Email and Password are required");
            var login = await _ManagementDbContext.Clients
                 .Where(x => x.Email.Equals(dto.Email) && x.Password.Equals(dto.Password))
                 .SingleOrDefaultAsync();
            if (login == null)
            {
                throw new Exception("Email Or Password Is Not Correct");
            }
        }
        [NonAction]
        public async Task ResetPassword(ResetPasswordDTO dto)
        {
            if (string.IsNullOrEmpty(dto.Email) || string.IsNullOrEmpty(dto.Phone))
                throw new Exception("Email and Phone are required");
            var user = await _ManagementDbContext.Clients.Where(x => x.Email.Equals(dto.Email)
            && x.Phone.Equals(dto.Phone)).SingleOrDefaultAsync();
            if (user == null)
            {
                throw new Exception("User Not Found");
            }
            else
            {
                if (string.IsNullOrEmpty(dto.Password) || string.IsNullOrEmpty(dto.ConfirmPassword))
                    throw new Exception("Password and ConfirmPassword are required");
                else
                {
                    if (dto.Password.Equals(dto.ConfirmPassword))
                    {
                        user.Password = dto.ConfirmPassword;
                        _ManagementDbContext.Update(user);
                        await _ManagementDbContext.SaveChangesAsync();
                    }
                }

            }
        }
        #endregion

    }
}
