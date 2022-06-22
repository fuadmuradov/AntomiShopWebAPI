using Antomi.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antomi.Core.IRepositories
{
    public interface ISettingRepository:IRepository<Setting>
    {
        public Task<string> GetValue(string key);
    }
}
