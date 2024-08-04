using System.Threading.Tasks;
using System.Collections.Generic;
using ConstructionTransaction.Models;

public interface IUserRepository
{
    Task<User> GetUserByUsernameAsync(string username);
    Task AddUserAsync(User user);
    Task AddLoginHistoryAsync(Guid userId);
    Task<IEnumerable<loginuseractivity>> GetLoginHistoryByUserIdAsync(Guid userId);
}