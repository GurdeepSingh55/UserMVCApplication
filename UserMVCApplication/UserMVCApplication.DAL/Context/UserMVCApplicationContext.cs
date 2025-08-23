using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserMVCApplication.DAL.Entities;

namespace UserMVCApplication.DAL.Context
{
    public class UserMVCApplicationContext : DbContext
    {
        public UserMVCApplicationContext(DbContextOptions<UserMVCApplicationContext> options)
            : base(options)
        { }
        public DbSet<User> Users { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<Address> Addresses { get; set; }
    }
}
