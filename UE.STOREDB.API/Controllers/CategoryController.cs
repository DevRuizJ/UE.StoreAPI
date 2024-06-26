﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UE.STOREDB.DOMAIN.Core.Entities;
using UE.STOREDB.DOMAIN.Core.Interfaces;
using UE.STOREDB.DOMAIN.Infrastructure.Repositories;

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

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]Category category)
        {
            var result = await _repo.Insert(category);

            if(!result)
                return BadRequest();

            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody]Category category)
        {
            if (id != category.Id) 
                return BadRequest();

            var result = await _repo.Update(category);

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
