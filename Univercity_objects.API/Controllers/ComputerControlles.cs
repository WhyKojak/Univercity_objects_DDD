using Microsoft.AspNetCore.DataProtection.Repositories;
using Microsoft.AspNetCore.Mvc;
using Univercity_objects.API.Controllers.DTO;
using Univercity_objects.Domain;
using Univercity_objects.Infrastructure;
using Univercity_objects.Infrastructure.Repository;

namespace Univercity_objects.API.Controllers;

[ApiController]
[Route("[controller]")]
public class ComputerController : ControllerBase
{
    private ComputerRepository repository;
    private AuditoryRepository auditoryRepository;
    public ComputerController(ComputerRepository repository, AuditoryRepository auditoryRepository)
    {
        this.repository = repository;
        this.auditoryRepository = auditoryRepository;
    }

    [HttpGet]
    public ActionResult GetAll()
    {
        var entities = repository.GetAll();
        return Ok(entities); // Данные будут автоматически сериализованы в JSON
    }

    [HttpGet("{guid}")]
    public ActionResult GetById(Guid guid)
    {
        var entity = repository.Get(guid);
        if (entity == null)
        {
            return NotFound();
        }
        return Ok(entity);
    }

    [HttpPost]
    public ActionResult<ComputerEntity> Create(CreateComputerDTO dto)
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
            var entity = new ComputerEntity();
            entity.Name = dto.Name;
            entity.Description = dto.Description;
            entity.inv_number = dto.inv_number;
            entity.specification = dto.specification;
            entity.Auditory = auditoryRepository.Get(dto.AuditoryGuid);
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
    public ActionResult<ComputerEntity> Update(UpdateComputerDTO dto)
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
            entity.specification= dto.specification;
            entity.Auditory = auditoryRepository.Get(dto.AuditoryGuid);
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