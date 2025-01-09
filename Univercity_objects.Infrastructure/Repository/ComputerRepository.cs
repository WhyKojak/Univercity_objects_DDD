using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Univercity_objects.Domain;

namespace Univercity_objects.Infrastructure.Repository
{
    public class ComputerRepository : GenericRepository<ComputerEntity>
    {

        public ComputerRepository(BaseContext context) : base(context) { }

        public IEnumerable<ComputerEntity> GetByAuditory(Guid auditory)
        {
            return dbSet.Where(a => a.Auditory.guid == auditory).ToList();
        }
    }
    
}
