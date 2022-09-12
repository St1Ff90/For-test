using BL.DTO;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public interface IGoodsService
    {
        Task<IEnumerable<GoodDto>> GetAll();
        Task<GoodDto> GetById(Guid id);
        Task<GoodDto> DeleteById(Guid id);
        Task<GoodDto> UpdateById(Guid id, GoodDto good);
        Task<GoodDto> Create(CreateGoodDto good);
    }
}
