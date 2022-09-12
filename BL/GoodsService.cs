using AutoMapper;
using BL.DTO;
using DAL;
using DAL.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class GoodsService : IGoodsService
    {
        private readonly ILogger<GoodsService> _logger;
        private readonly IGoodsRepository _goodsRepository;
        private readonly IMapper _mapper;
        public GoodsService(
             ILogger<GoodsService> logger,
             IGoodsRepository goodsRepository,
             IMapper mapper)
        {
            _logger = logger;
            _goodsRepository = goodsRepository;
            _mapper = mapper;
        }

        public async Task<GoodDto> Create(CreateGoodDto goodDto)
        {
            if (goodDto.Price < 0)
            {
                throw new ArgumentException("Price should be greater than zero!");
            }

            var good = _mapper.Map<Good>(goodDto);

            var goodFromDb = await _goodsRepository.Create(good);

            return _mapper.Map<GoodDto>(goodFromDb);
        }

        public async Task<GoodDto> UpdateById(Guid id, GoodDto good)
        {
            var response = await _goodsRepository.UpdateById(id, _mapper.Map<Good>(good));

            return _mapper.Map<GoodDto>(response);
        }

        public Task<GoodDto> DeleteById(Guid id)
        {
            return Task.FromResult(new GoodDto());
        }

        public async Task<IEnumerable<GoodDto>> GetAll()
        {
            var goods = await _goodsRepository.GetAll();

            _logger.LogDebug("Test debug!");
            _logger.LogInformation($"Got {goods.Count()} items");
            var response = _mapper.Map<IEnumerable<GoodDto>>(goods);

            return response;
        }

        public async Task<GoodDto> GetById(Guid id)
        {
            return _mapper.Map<GoodDto>(await _goodsRepository.GetById(id));

        }
    }
}
