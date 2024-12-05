using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Univercity_objects.Domain;
using Univercity_objects.Infrastructure;

class SQLRepository : IRepository<BaseEntity>
{
    private BaseContext db;

    public SQLRepository ()
    {
        this.db = new BaseContext();
    }

    public IEnumerable<BaseEntity> GetAll()
    {
        return db.BaseEntities;
    }

    public BaseEntity Getobj(int id)
    {
        return db.BaseEntities.Find(id);
    }

    public void Create(BaseEntity entity)
    {
        db.BaseEntities.Add(entity);
    }

    public void Update(BaseEntity entity)
    {
        
    }

    public void Delete(int id)
    {
        BaseEntity entity = db.BaseEntities.Find(id);
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
