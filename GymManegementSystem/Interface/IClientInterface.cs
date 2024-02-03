using GymManegementSystem.DTO_s.Client;
using GymManegementSystem.DTO_s.Coach;
using GymManegementSystem.DTO_s.Subscription;
using TicketCoder.DTOs.Authantication;

namespace GymManegementSystem.Interface
{
    public interface IClientInterface
    {
        // Subscription Operations
        Task<List<SubscriptionDTO>> GetAllSubscriptions();
        Task<List<SubscriptionDTO>> SearchSubscriptions(float? maxPrice, int? durationInDays, string title);
        // Coach Operations
        Task<List<CoachDTO>> GetAllCoaches();
        // Account Operations
        Task CreateAccount(ClientAccountDTO clientAccountDTO);  
        Task Login(LoginDTO dto); 
        Task ResetPassword(ResetPasswordDTO dto);
        Task<bool> RegisterInSubscription(int clientId, int subscriptionId);
    }
}
