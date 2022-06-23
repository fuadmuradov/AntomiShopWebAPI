using Antomi.Core.Entities;
using Antomi.Core.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antomi.Data.Repositories
{
    public class QuestionRepository:Repository<Question>, IQuestionRepository
    {
        public QuestionRepository(AntomiDbContext context):base(context)
        {

        }
    }
}
