using Microsoft.AspNetCore.Mvc;
using BL;
using BL.DTO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ASP.NET_Core_API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class GoodsController : ControllerBase
    {
        private readonly IGoodsService _goodsService;
        private readonly ILogger<GoodsController> _logger;

        public GoodsController(ILogger<GoodsController> logger, IGoodsService goodsService)
        {
            _logger = logger;
            _goodsService = goodsService;
        }

        // GET: api/<GoodsController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            _logger.LogInformation($"Called {nameof(GetAll)}");
            var goods = await _goodsService.GetAll();
            return Ok(goods);
        }

        // GET api/<GoodsController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _goodsService.GetById(id);
            return result != null ? Ok(result) : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> CreateGood(CreateGoodDto good)
        {
            var goodDto = await _goodsService.Create(good);

            return Ok(goodDto);
        }

        /*
        // POST api/<GoodsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<GoodsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<GoodsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        */
    }
}
