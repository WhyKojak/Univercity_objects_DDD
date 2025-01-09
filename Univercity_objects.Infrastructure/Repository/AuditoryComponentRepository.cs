using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Univercity_objects.Domain;

namespace Univercity_objects.Infrastructure.Repository
{
    public abstract class AuditoryComponentRepository<TEntity> : GenericRepository<TEntity>
        where TEntity : AuditoryComponentEntity
    {
        public AuditoryComponentRepository (BaseContext context) : base(context) { }

        public IEnumerable<TEntity> GetByAuditory(Guid auditory)
        {
            return dbSet.Where(a => a.Auditory.guid == auditory).ToList();
        }

        public IEnumerable<TEntity> GetByCafedra(Guid cafedra)
        {
            return dbSet.Where(a => a.Auditory.cafedra.guid == cafedra).ToList();
        }
    }
}
