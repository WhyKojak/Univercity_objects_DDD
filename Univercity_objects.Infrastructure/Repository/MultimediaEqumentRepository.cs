using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Univercity_objects.Domain;

namespace Univercity_objects.Infrastructure.Repository
{
    public class MultimediaEqumentRepository : AuditoryComponentRepository<MultimediaEqumentEntity>
    {
        public MultimediaEqumentRepository(BaseContext context) : base(context) { }

    }
}
