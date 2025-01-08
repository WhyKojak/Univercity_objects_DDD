using Microsoft.AspNetCore.DataProtection.Repositories;
using Microsoft.AspNetCore.Mvc;
using Univercity_objects.API.Controllers.DTO;
using Univercity_objects.Domain;
using Univercity_objects.Infrastructure;

namespace Univercity_objects.API.Controllers;

[ApiController]
[Route("[controller]")]
public class AuditoryController : ControllerBase
{
    private AuditoryRepository repository;
    private CafedraRepository cafedraRepository;

    public AuditoryController (AuditoryRepository repository, CafedraRepository cafedraRepository)
    {
        this.repository = repository;
        this.cafedraRepository = cafedraRepository;
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
    public ActionResult<Auditory> Create(CreateAuditoryDTO dto)
    {
        if (dto == null)
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
            var entity = new Auditory();
            entity.Name = dto.Name;
            entity.Description = dto.Description;
            entity.inv_number = dto.inv_number;
            entity.cafedra = cafedraRepository.Get(dto.CafedraGuid);
            // Добавление в базу через репозиторий
            repository.Create(entity);

            // Возврат успешного ответа с статусом 201 (Created) и местом для нового ресурса
            return CreatedAtAction(nameof(GetById), new { guid = entity.guid }, entity);
        }
        catch (Exception ex)
        {
            // В случае ошибки возвращаем статус 500 с сообщением об ошибке
            return StatusCode(500, $"Internal server error: {ex}");
        }
    }

    [HttpDelete("{guid}")]
    public ActionResult Delete(Guid guid)
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
    public ActionResult<Auditory> Update(UpdateAuditoryDTO dto)
    {
        if (dto == null)
        {
            return BadRequest("Сущность не может быть null.");
        }
        try
        {
            var entity = repository.Get(dto.Guid);
            entity.Name = dto.Name;
            entity.Description = dto.Description;
            entity.inv_number = dto.inv_number;
            entity.cafedra = cafedraRepository.Get(dto.CafedraGuid);
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