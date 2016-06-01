using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using Domain.Models;

namespace DAL.Repositories
{
   public class UserRepository : EFRepository<User>, IUserRepository
    {
       public UserRepository(IDbContext dbContext) : base(dbContext)
       {
       }
    }
}
