﻿using Microsoft.AspNetCore.DataProtection.Repositories;
using Microsoft.AspNetCore.Mvc;
using Univercity_objects.Domain;
using Univercity_objects.Infrastructure;

namespace Univercity_objects.API.Controllers;

[ApiController]
[Route("[controller]")]
public class CafedraController : ControllerBase
{
    private CafedraRepository repository;
    private AuditoryRepository auditoryRepository;
    public CafedraController (CafedraRepository repository, AuditoryRepository auditoryRepository)
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

    [HttpGet("{guid}/auditories")]
    public ActionResult GetAuditories(Guid guid)
    {
        var entities = auditoryRepository.GetByCafedra(guid);
        if (entities == null)
        {
            return NotFound();
        }
        return Ok(entities);
    }

    [HttpPost]
    public ActionResult<CafedraEntity> Create(CafedraEntity entity)
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
            return CreatedAtAction(nameof(GetById), new { guid = entity.guid }, entity);
        }
        catch (Exception ex)
        {
            // В случае ошибки возвращаем статус 500 с сообщением об ошибке
            return StatusCode(500, $"Internal server error: {ex.Message}");
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
    public ActionResult<CafedraEntity> Update(CafedraEntity entity)
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