using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EntityService.Models;
using Microsoft.AspNetCore.Authorization;
using EntityService.Data;

namespace EntityService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class EntityController : ControllerBase
    {
        private readonly EntityRepository repository;

        public EntityController(EntityRepository repository)
        {
            this.repository = repository;
        }

        [HttpPost]
        public IActionResult Post([FromBody] Entity entity)
        {
            try
            {
                repository.Add(entity);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(entity);
        }

        [HttpGet]
        public IActionResult Get(Guid id)
        {

            try
            {
                Entity entity = repository.Get(id);
                return Ok(entity);
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }

        }
    }
}
