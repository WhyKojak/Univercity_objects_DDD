using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Univercity_objects.Domain;
using Univercity_objects.Infrastructure;

public class SQLRepository : IRepository<BaseEntity>
{
    private BaseContext db;

    public SQLRepository (BaseContext db)
    {
        this.db = db ?? throw new ArgumentNullException(nameof(db));
    }

    public IEnumerable<BaseEntity> GetAll()
    {
        return db.BaseEntities.ToArray();
    }

    public BaseEntity Get(Guid guid)
    {
        return db.BaseEntities.Find(guid);
    }

    public void Create(BaseEntity entity)
    {
        db.BaseEntities.Add(entity);
        db.SaveChanges();
    }

    public void Update(BaseEntity entity)
    {
        db.BaseEntities.Update(entity);
        db.SaveChanges();
    }

    public void Delete(Guid guid)
    {
        BaseEntity entity = db.BaseEntities.Find(guid);
        if (entity != null)
        {
            db.BaseEntities.Remove(entity);
        }
    }

    public void Save()
    {
        db.SaveChanges();
    }
}
