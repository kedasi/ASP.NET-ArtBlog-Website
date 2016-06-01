﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using Domain.Models;

namespace DAL.Repositories
{
    public class PictureRatingRepository : EFRepository<PictureRating>, IPictureRatingRepository
    {
        public PictureRatingRepository(IDbContext dbContext) : base(dbContext)
        {
        }
    }
}
