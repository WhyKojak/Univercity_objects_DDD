using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Univercity_objects.Domain;
using Univercity_objects.Infrastructure;

namespace Univercity_objects.Infrastructure.Repository
{
    public class AuditoryRepository : GenericRepository<Auditory>
    {

        public AuditoryRepository(BaseContext context) : base(context) { }

        public override IEnumerable<Auditory> GetAll()
        {
            return dbSet.Include("cafedra").ToList();
        }

        public override Auditory Get(Guid guid)
        {
            return dbSet.Where(a => a.guid == guid).Include("cafedra").First();
        }

        public IEnumerable<Auditory> GetByCafedra(Guid cafedra)
        {
            return dbSet.Where(a => a.cafedra.guid == cafedra).ToList();
        }
    }
}