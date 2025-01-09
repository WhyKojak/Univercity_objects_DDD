using Microsoft.AspNetCore.DataProtection.Repositories;
using Microsoft.AspNetCore.Mvc;
using Univercity_objects.Domain;
using Univercity_objects.Infrastructure;
using Univercity_objects.Infrastructure.Repository;

namespace Univercity_objects.API.Controllers;

[Controller]
public abstract class GenericController<TRepository, TEntity> : ControllerBase
    where TRepository : GenericRepository<TEntity>
    where TEntity : class
    {
        protected TRepository repository;
        
        public GenericController (TRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public virtual ActionResult GetAll()
        {
            var entities = repository.GetAll();
            return Ok(entities); // Данные будут автоматически сериализованы в JSON
        }

        [HttpGet("{guid}")]
        public virtual ActionResult GetById(Guid guid)
        {
            var entity = repository.Get(guid);
            if (entity == null)
            {
                return NotFound();
            }
            return Ok(entity);
        }

        [HttpPost]
        public virtual ActionResult<TEntity> Create(TEntity entity)
        {
            if (entity == null)
            {
                return BadRequest("Сущность не может быть null.");
            }

            // Валидация данных (при необходимости)
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                // Добавление в базу через репозиторий
                repository.Create(entity);

                // Возврат успешного ответа с статусом 201 (Created) и местом для нового ресурса
                return Ok(entity);
            }
            catch (Exception ex)
            {
                // В случае ошибки возвращаем статус 500 с сообщением об ошибке
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{guid}")]
        public virtual ActionResult Delete(Guid guid)
        {
            if (repository.Get(guid) != null)
            {
                repository.Delete(guid);
                return NoContent();
            }
            else
            {
                return NotFound("dededfe");
            }
        }
        [HttpPut]
        public virtual ActionResult<TEntity> Update(TEntity entity)
        {
            if (entity == null)
            {
                return BadRequest("Сущность не может быть null.");
            }
            try
            {
                // Добавление в базу через репозиторий
                repository.Update(entity);

                // Возврат успешного ответа с статусом 201 (Created) и местом для нового ресурса
                return Ok(entity);
            }
            catch (Exception ex)
            {
                // В случае ошибки возвращаем статус 500 с сообщением об ошибке
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
}
