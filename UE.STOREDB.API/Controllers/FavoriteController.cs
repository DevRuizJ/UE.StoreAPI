using Microsoft.AspNetCore.Mvc;
using UE.STOREDB.DOMAIN.Core.Entities;
using UE.STOREDB.DOMAIN.Core.Interfaces;

namespace UE.STOREDB.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class FavoriteController : Controller
    {
        private readonly IFavoriteRepository _repo;

        public FavoriteController(IFavoriteRepository repo)
            => _repo = repo;

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var favorite = await _repo.GetAll();

            return Ok(favorite);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var favorite = await _repo.GetById(id);

            if (favorite == null)
                return NotFound();

            return Ok(favorite);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Favorite favorite)
        {
            var result = await _repo.Insert(favorite);

            if (!result)
                return BadRequest();

            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Favorite favorite)
        {
            if (id != favorite.Id)
                return BadRequest();

            var result = await _repo.Update(favorite);

            if (!result)
                return BadRequest();

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _repo.Delete(id);

            if (!result)
                return BadRequest();

            return Ok(result);
        }
    }
}
