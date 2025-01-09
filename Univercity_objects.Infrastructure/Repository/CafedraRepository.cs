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
    public class CafedraRepository : GenericRepository<CafedraEntity>
    {
        public CafedraRepository(BaseContext context): base (context) { }
    }
}