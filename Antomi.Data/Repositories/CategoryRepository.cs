using Antomi.Core.Entities;
using Antomi.Core.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antomi.Data.Repositories
{
    public class CategoryRepository:Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(AntomiDbContext context) : base(context) { }
       
    }
}
