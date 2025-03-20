using StudentVoiceNU.Application.Interfaces.Repositories;
using StudentVoiceNU.Domain.DTOs;
using StudentVoiceNU.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace StudentVoiceNU.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public abstract class BaseController : ControllerBase
    {
        protected readonly IBaseRepository<BaseEntity> _baseRepository;

        public BaseController(IBaseRepository<BaseEntity> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        [HttpPost]
        public virtual IActionResult Create([FromBody] BaseEntity entity)
        {
            var createdEntity = _baseRepository.Create(entity);
            return Ok(createdEntity);
        }

        [HttpPut]
        public virtual IActionResult Update([FromBody] BaseEntity entity)
        {
            var updatedEntity = _baseRepository.Update(entity);
            return Ok(updatedEntity);
        }

        [HttpDelete("{id}")]
        public virtual IActionResult Delete(int id)
        {
            var deletedEntity = _baseRepository.Delete(id);
            return Ok(deletedEntity);
        }

        [HttpGet("{id}")]
        public virtual IActionResult GetById(int id)
        {
            var entity = _baseRepository.GetbyId(id);
            return Ok(entity);
        }
    }
}
