using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserMVCApplication.DAL.Entities;

namespace UserMVCApplication.DAL.IRepositories
{
    public interface IAddressRepository
    {
        Task<int> AddAsync(Address address);
        Task<bool> UpdateAsync(Address addressData);
    }
}
