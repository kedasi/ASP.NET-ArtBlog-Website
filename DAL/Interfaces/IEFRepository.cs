﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IEFRepository<T> : IDisposable
        where T : class
    {
        // gett all records in table
        //IQueryable<T> All { get; }
        List<T> All { get; }

        // get all records with filter
        //IQueryable<T> GetAllIncluding(params Expression<Func<T, object>>[] includeProperties);
        List<T> AllIncluding(params Expression<Func<T, object>>[] includeProperties);

        T GetById(params object[] id);
        T Add(T entity);
        void Update(T entity);
        //void UpdateOrInsert(T entity);
        void Delete(T entity);
        void Delete(params object[] id);
    }
}
