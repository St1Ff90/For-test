﻿using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class GoodsRepository : IGoodsRepository
    {
        private readonly MyContext _dbContext;

        public GoodsRepository(MyContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Good> Create(Good good)
        {
            good.Id = Guid.NewGuid();
            _dbContext.Add(good);
            await _dbContext.SaveChangesAsync();

            return good;
        }

        public Task<Good> DeleteById(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Good>> GetAll()
        {
            return await _dbContext.Goods.ToListAsync();

        }

        public Task<Good?> GetById(Guid id)
        {
            return _dbContext.Goods.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Good> UpdateById(Guid id, Good good)
        {
            good.Id = id;
            _dbContext.Entry(good).State = EntityState.Modified;

            await _dbContext.SaveChangesAsync();

            return good;
        }
    }
}
