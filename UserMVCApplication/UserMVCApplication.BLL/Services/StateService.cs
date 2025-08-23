using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserMVCApplication.BLL.IServices;
using UserMVCApplication.DAL.Entities;
using UserMVCApplication.DAL.IRepositories;

namespace UserMVCApplication.BLL.Services
{
    public class StateService : IStateService
    {
        private readonly IStateRepository _stateRepository;
        private readonly ILogger _logger;
        public StateService(IStateRepository stateRepository,
            ILogger<UserService> logger)
        {
            _stateRepository = stateRepository;
            _logger = logger;
        }
        public async Task<List<State>> GetAllStates()
        {
            try
            {
                return await _stateRepository.GetAllStates();
            }
            catch (Exception)
            {
                return new List<State>();
            }
        }
    }
}
