﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ServicesBase
{
    public interface IService<T> where T : class
    {   
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<bool> UpdateAsync(int id, T updatedEntity);
        Task AddAsync(T entity);
        Task DeleteAsync(int id);
    }
}