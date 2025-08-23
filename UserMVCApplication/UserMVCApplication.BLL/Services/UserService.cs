using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserMVCApplication.BLL.IServices;
using UserMVCApplication.BLL.Models;
using UserMVCApplication.DAL.Context;
using UserMVCApplication.DAL.Entities;
using UserMVCApplication.DAL.IRepositories;
using UserMVCApplication.DAL.Repositories;

namespace UserMVCApplication.BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IAddressRepository _addressRepository;
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        public UserService(IUserRepository userRepository,
            IAddressRepository addressRepository,
           IMapper mapper,
            ILogger<UserService> logger)
        {
            _userRepository = userRepository;
            _addressRepository = addressRepository;
            _logger = logger;
            _mapper = mapper;
        }
        public async Task<List<User>> GetAllUsers()
        {
            try
            {
                return await _userRepository.GetAllUsers();
            }
            catch (Exception)
            {
                return new List<User>();
            }
        }
        public async Task<int> AddUser(UserModel model)
        {
            try
            {
                var address = new Address
                {
                    FullAddress = model.FullAddress,
                    StateId = model.StateId,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                };
                var addressId = await _addressRepository.AddAsync(address);

                if (addressId != 0)
                {
                    var user = new User
                    {
                        Name = model.Name,
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now,
                        AddressId = addressId
                    };
                    await _userRepository.AddAsync(user);

                    return user.Id;
                }
                return 0;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        public async Task<bool> UpdateUser(UserModel model)
        {
            try
            {
                var address = new Address
                {
                    Id = (int)model.AddressId,
                    FullAddress = model.FullAddress,
                    StateId = model.StateId,
                    UpdatedAt = DateTime.Now
                };
                bool isAddressUpdated = await _addressRepository.UpdateAsync(address);

                if (isAddressUpdated)
                {
                    var user = new User
                    {
                        Id = model.Id,
                        Name = model.Name,
                        UpdatedAt = DateTime.Now,
                    };
                    await _userRepository.UpdateAsync(user);

                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public async Task<bool> DeleteUser(int userId)
        {
            try
            {
                return await _userRepository.DeleteAsync(userId);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public async Task<UserModel?> GetUserDetailsById(int userId)
        {
            try
            {
                var userData = await _userRepository.GetByIdAsync(userId);
                return _mapper.Map<UserModel?>(userData);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }
}
