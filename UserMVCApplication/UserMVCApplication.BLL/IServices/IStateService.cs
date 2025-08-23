using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserMVCApplication.DAL.Entities;

namespace UserMVCApplication.BLL.IServices
{
    public interface IStateService
    {
        Task<List<State>> GetAllStates();
    }
}
