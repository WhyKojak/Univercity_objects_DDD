using Microsoft.AspNetCore.DataProtection.Repositories;
using Microsoft.AspNetCore.Mvc;
using Univercity_objects.Domain;
using Univercity_objects.Infrastructure;

namespace Univercity_objects.API.Controllers;

[Route("[controller]")]
public class BaseEntityController : Controller
{
    private SQLRepository repository;
    public BaseEntityController (SQLRepository repository)
    {
        this.repository = repository;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var entities = repository.GetAll();
        return Ok(entities); // Данные будут автоматически сериализованы в JSON
    }

    [HttpGet("{guid}")]
    public IActionResult GetById(Guid guid)
    {
        var entity = repository.Get(guid);
        if (entity == null)
        {
            return NotFound();
        }
        return Ok(entity);
    }

    [HttpPost]
    public IActionResult Create(BaseEntity entity)
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
            return CreatedAtAction(nameof(GetById), new { id = entity.guid }, entity);
        }
        catch (Exception ex)
        {
            // В случае ошибки возвращаем статус 500 с сообщением об ошибке
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
}