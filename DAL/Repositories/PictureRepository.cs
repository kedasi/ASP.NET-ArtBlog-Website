using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using Domain.Models;

namespace DAL.Repositories
{
    public class PictureRepository : EFRepository<Picture>, IPictureRepository
    {
        public PictureRepository(IDbContext dbContext) : base(dbContext)
        {
        }
    }
}
