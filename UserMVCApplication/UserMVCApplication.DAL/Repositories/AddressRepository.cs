using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserMVCApplication.DAL.Context;
using UserMVCApplication.DAL.Entities;
using UserMVCApplication.DAL.IRepositories;

namespace UserMVCApplication.DAL.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        private readonly UserMVCApplicationContext _context;
        private readonly ILogger _logger;
        public AddressRepository(UserMVCApplicationContext context,
            ILogger<AddressRepository> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<int> AddAsync(Address address)
        {
            try
            {
                var result = await _context.Addresses.AddAsync(address);
                await _context.SaveChangesAsync();
                return result.Entity.Id;
            }
            catch (Exception)
            {
                return 0;
            }
        }
        public async Task<bool> UpdateAsync(Address addressData)
        {
            try
            {
                var address = await _context.Addresses.FirstOrDefaultAsync(u => u.Id == addressData.Id);
                if (address != null)
                {
                    address.FullAddress = addressData.FullAddress;
                    address.StateId = addressData.StateId;
                    address.UpdatedAt = DateTime.Now;
                    _context.Addresses.Update(address);
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
    }
}
