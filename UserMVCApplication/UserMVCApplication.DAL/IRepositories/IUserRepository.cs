using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserMVCApplication.DAL.Entities;

namespace UserMVCApplication.DAL.IRepositories
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllUsers();
        Task<int> AddAsync(User user);
        Task<bool> UpdateAsync(User userData);
        Task<bool> DeleteAsync(int id);
        Task<User> GetByIdAsync(int id);
    }
}
