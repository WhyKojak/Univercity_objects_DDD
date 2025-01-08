using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Univercity_objects.Domain;
using Univercity_objects.Infrastructure;

public class CafedraRepository
{
    private BaseContext db;

    public CafedraRepository(BaseContext db)
    {
        this.db = db ?? throw new ArgumentNullException(nameof(db));
    }

    public IEnumerable<CafedraEntity> GetAll()
    {
        return db.CafedraEntities.ToList();
    }

    public CafedraEntity Get(Guid guid)
    {
        return db.CafedraEntities.Find(guid);
    }

    public void Create(CafedraEntity entity)
    {
        db.CafedraEntities.Add(entity);
        db.SaveChanges();
    }

    public void Update(CafedraEntity entity)
    {
        db.CafedraEntities.Update(entity);
        db.SaveChanges();
    }

    public void Delete(Guid guid)
    {
        CafedraEntity entity = db.CafedraEntities.Find(guid);
        if (entity != null)
        {
            db.CafedraEntities.Remove(entity);
            db.SaveChanges();
        }
    }

    public void Save()
    {
        db.SaveChanges();
    }
}
