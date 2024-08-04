using ConstructionTransaction.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _context;
    private readonly ILogger<UserRepository> _logger;

    public UserRepository(ApplicationDbContext context, ILogger<UserRepository> logger)
    {
        _context = context;
    _logger = logger;
    }

    public async Task<User> GetUserByUsernameAsync(string username)
    {
        return await _context.Users.SingleOrDefaultAsync(u => u.Username == username);
    }

    public async Task AddUserAsync(User user)
    {
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
    }

    public async Task AddLoginHistoryAsync(Guid userId)
    {
        var loginUserActivity = new loginuseractivity
        {
            loginid = Guid.NewGuid(),
            userid = userId,
            logintimestamp = DateTime.UtcNow
        };
// Menampilkan isi dari loginUserActivity
Console.WriteLine($"LoginID: {loginUserActivity.loginid}, UserID: {loginUserActivity.userid}, LoginTimestamp: {loginUserActivity.logintimestamp}");


        await _context.loginuseractivity.AddAsync(loginUserActivity);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<loginuseractivity>> GetLoginHistoryByUserIdAsync(Guid userId)
    {
        _logger.LogInformation("Fetching login history for user ID: {UserId}", userId);
        return await _context.loginuseractivity
            .Where(lh => lh.userid == userId)
            .OrderByDescending(lh => lh.logintimestamp)
            .ToListAsync();
    }
}