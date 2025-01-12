using Microsoft.AspNetCore.DataProtection.Repositories;
using Microsoft.AspNetCore.Mvc;
using Univercity_objects.API.Controllers.DTO;
using Univercity_objects.Domain;
using Univercity_objects.Infrastructure;
using Univercity_objects.Infrastructure.Repository;

namespace Univercity_objects.API.Controllers.api;

[ApiController]
[Area("api")]
[Route("[area]/[controller]")]
public class AuditoryController(AuditoryRepository repository,
                           CafedraRepository cafedraRepository,
                           ComputerRepository computerRepository,
                           FurnitureRepository furnitureRepository,
                           MultimediaEqumentRepository multimediaEqumentRepository) : ControllerBase
{
    private AuditoryRepository repository = repository;
    private CafedraRepository cafedraRepository = cafedraRepository;
    private ComputerRepository computerRepository = computerRepository;
    private FurnitureRepository furnitureRepository = furnitureRepository;
    private MultimediaEqumentRepository multimediaEqumentRepository = multimediaEqumentRepository;

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

    [HttpGet("{guid}/computers")]
    public ActionResult GetComputers(Guid guid)
    {
        var entities = computerRepository.GetByAuditory(guid);
        if (entities == null)
        {
            return NotFound();
        }
        return Ok(entities);
    }

    [HttpGet("{guid}/furnitures")]
    public ActionResult GetFurnitures(Guid guid)
    {
        var entities = furnitureRepository.GetByAuditory(guid);
        if (entities == null)
        {
            return NotFound();
        }
        return Ok(entities);
    }

    [HttpGet("{guid}/multimedia")]
    public ActionResult GetMultimedia(Guid guid)
    {
        var entities = multimediaEqumentRepository.GetByAuditory(guid);
        if (entities == null)
        {
            return NotFound();
        }
        return Ok(entities);
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
            return CreatedAtAction(nameof(GetById), new { entity.guid }, entity);
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