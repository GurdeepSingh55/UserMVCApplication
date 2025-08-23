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
    public class StateRepository: IStateRepository
    {
        private readonly UserMVCApplicationContext _context;
        private readonly ILogger _logger;
        public StateRepository(UserMVCApplicationContext context,
            ILogger<StateRepository> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<List<State>> GetAllStates()
        {
            try
            {
                return await _context.States.OrderBy(x=>x.Name).ToListAsync();
            }
            catch (Exception)
            {
                return new List<State>();
            }
        }
    }
}
