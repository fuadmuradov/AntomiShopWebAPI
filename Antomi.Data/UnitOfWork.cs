using Antomi.Core;
using Antomi.Core.IRepositories;
using Antomi.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antomi.Data
{
    // UnitOfWork Pattern bütün repositorileri Özünde saxlayir və repositorilərə UnitOfÜork üzərindən
    // Servicelərdə istifadə olunur

    public class UnitOfWork : IUnitOfWork
    {
        ICategoryRepository categoryRepository;
        ISettingRepository settingRepository;
        private readonly AntomiDbContext context;

        public UnitOfWork(AntomiDbContext context)
        {
            this.context = context;
        }
        // categoryRepository null deyilse özünü deyilse yeni obyektini yaradib gonderir
        public ICategoryRepository CategoryRepository => categoryRepository ?? new CategoryRepository(context);

        public ISettingRepository SettingRepository => settingRepository ?? new SettingRepository(context);

        public int Commit()
        {
            return context.SaveChanges();
        }

        public Task<int> CommitAsync()
        {
            return context.SaveChangesAsync();
        }
    }
}
