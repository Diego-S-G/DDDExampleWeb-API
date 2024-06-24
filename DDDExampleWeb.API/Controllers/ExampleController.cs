using DDDExampleWeb.Application.Interfaces;
using DDDExampleWeb.Domain.Dtos;
using DDDExampleWeb.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace DDDExampleWeb.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExampleController : ControllerBase
    {
        private readonly IExampleService _exampleService;
        public ExampleController(IExampleService service)
        {
            _exampleService = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetListAsync()
        {
            var entities = await _exampleService.GetListAsync();

            if (entities == null)
            {
                return BadRequest();
            }

            return Ok(entities.Select(x => new { x.Id, x.PropertyName1, x.PropertyName2, x.PropertyName3 }));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Example>> GetCompleteAsync(int id)
        {
            var entity = await _exampleService.GetCompleteAsync(id);

            if (entity == null)
            {
                return BadRequest();
            }

            return Ok(new Example { Id = entity.Id, PropertyName1 = entity.PropertyName1, PropertyName2 = entity.PropertyName2, PropertyName3 = entity.PropertyName3 });
        }

        [HttpPost]
        public async Task<ActionResult<Example>> PostAsync(ExampleInsertDto exampleDto)
        {
            var example = new Example
            {
                PropertyName1 = exampleDto.PropertyName1,
                PropertyName2 = exampleDto.PropertyName2,
                PropertyName3 = exampleDto.PropertyName3
            };

            var entity = await _exampleService.CreateAsync(example);

            if (entity == null)
            {
                return BadRequest();
            }

            return Ok(new Example { Id = entity.Id, PropertyName1 = entity.PropertyName1, PropertyName2 = entity.PropertyName2, PropertyName3 = entity.PropertyName3 });
        }

        [HttpPut]
        public async Task<IActionResult> PutAsync(Example example)
        {
            var entity = await _exampleService.UpdateAsync(example.Id, example);

            if (entity == null)
            {
                return BadRequest();
            }

            return Ok(new Example { Id = entity.Id, PropertyName1 = entity.PropertyName1, PropertyName2 = entity.PropertyName2, PropertyName3 = entity.PropertyName3 });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var success = _exampleService.Delete(id);

            if (!success)
            {
                return BadRequest();
            }

            return Ok();
        }

    }
}
