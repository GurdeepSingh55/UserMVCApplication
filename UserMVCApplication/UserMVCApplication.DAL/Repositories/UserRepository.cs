using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using UserMVCApplication.DAL.Context;
using UserMVCApplication.DAL.Entities;
using UserMVCApplication.DAL.IRepositories;

namespace UserMVCApplication.DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserMVCApplicationContext _context;
        private readonly ILogger _logger;
        public UserRepository(UserMVCApplicationContext context,
            ILogger<UserRepository> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<List<User>> GetAllUsers()
        {
            try
            {
                return await _context.Users.Include(x => x.Address)
                    .ThenInclude(x => x.State).Where(x => x.IsDeleted != true).ToListAsync();
            }
            catch (Exception)
            {
                return new List<User>();
            }
        }
        public async Task<int> AddAsync(User user)
        {
            try
            {
                var result = await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();
                return result.Entity.Id;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public async Task<bool> UpdateAsync(User userData)
        {
            try
            {
                var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == userData.Id);
                if (user != null)
                {
                    user.Name = userData.Name;
                    user.UpdatedAt = DateTime.Now;
                    _context.Users.Update(user);
                    await _context.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var user = await _context.Users.Include(u => u.Address).FirstOrDefaultAsync(u => u.Id == id);
                if (user != null)
                {
                    user.IsDeleted = true;
                    if (user.Address != null)
                    {
                        user.Address.IsDeleted = true;
                    }
                    _context.Users.Update(user);
                    await _context.SaveChangesAsync();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<User> GetByIdAsync(int id)
        {
            try
            {
                var user = await _context.Users.Include(u => u.Address)
                    .ThenInclude(x => x.State).FirstOrDefaultAsync(u => u.Id == id);
                return user;
            }
            catch (Exception ex)
            {
                return new User();
            }
        }

    }
}
