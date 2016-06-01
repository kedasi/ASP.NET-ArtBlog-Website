using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using Domain.Models;

namespace DAL.Repositories
{
    public class RatingRepository : EFRepository<Rating>, IRatingRepository
    {
        public RatingRepository(IDbContext dbContext) : base(dbContext)
        {
        }
    }
}
