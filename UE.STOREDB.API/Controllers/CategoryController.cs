using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UE.STOREDB.DOMAIN.Core.Interfaces;

namespace UE.STOREDB.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _repo;

        public CategoryController(ICategoryRepository repo)
            => _repo = repo;

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var category = await _repo.GetAll();

            return Ok(category);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById (int id)
        {
            var category = await _repo.GetById(id);

            if (category == null)
                return NotFound();

            return Ok(category);
        }
    }
}
