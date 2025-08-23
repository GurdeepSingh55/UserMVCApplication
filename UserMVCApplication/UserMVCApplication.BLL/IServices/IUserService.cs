using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserMVCApplication.BLL.Models;
using UserMVCApplication.DAL.Entities;

namespace UserMVCApplication.BLL.IServices
{
    public interface IUserService
    {
        Task<List<User>> GetAllUsers();
        Task<int> AddUser(UserModel model);
        Task<bool> UpdateUser(UserModel model);
        Task<bool> DeleteUser(int userId);
        Task<UserModel?> GetUserDetailsById(int userId);
    }
}
