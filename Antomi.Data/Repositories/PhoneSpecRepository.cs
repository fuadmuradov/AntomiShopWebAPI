using Antomi.Core.Entities;
using Antomi.Core.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antomi.Data.Repositories
{
    public class PhoneSpecRepository:Repository<PhoneSpecification>, IPhoneSpecRepository
    {
        public PhoneSpecRepository(AntomiDbContext context):base(context)
        {
        }
    }
}
