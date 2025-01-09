using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Univercity_objects.Domain;
using Univercity_objects.Infrastructure;

public class AuditoryRepository : IRepository<Auditory>
{
    private BaseContext db;

    public AuditoryRepository(BaseContext db)
    {
        this.db = db ?? throw new ArgumentNullException(nameof(db));
    }

    public IEnumerable<Auditory> GetAll()
    {
        return db.Auditories.Include("cafedra").ToList();
    }

    public Auditory Get(Guid guid)
    {
        return db.Auditories.Where(a => a.guid == guid).Include("cafedra").First();
    }

    public void Create(Auditory entity)
    {
        db.Auditories.Add(entity);
        db.SaveChanges();
    }

    public void Update(Auditory entity)
    {
        db.Auditories.Update(entity);
        db.SaveChanges();
    }

    public void Delete(Guid guid)
    {
        Auditory entity = db.Auditories.Find(guid);
        if (entity != null)
        {
            db.Auditories.Remove(entity);
            db.SaveChanges();
        }
    }

    public void Save()
    {
        db.SaveChanges();
    }

    public IEnumerable<Auditory> GetByCafedra(Guid cafedra)
    {
        return db.Auditories.Where(a => a.cafedra.guid == cafedra).ToList();
    }
}
