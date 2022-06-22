using Antomi.Core.Entities;
using Antomi.Core.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antomi.Data.Repositories
{
    public class SettingRepository : Repository<Setting>, ISettingRepository
    {
        private readonly AntomiDbContext context;

        public SettingRepository(AntomiDbContext context) : base(context)
        {
            this.context = context;
        }
        public async Task<string> GetValue(string key)
        {
            Setting setting = await context.Settings.FirstOrDefaultAsync(x => x.Key == key);
            return setting.Value;
        }
    }
}
