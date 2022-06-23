using Antomi.Core.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antomi.Core
{
    // UnitOfWork Pattern bütün repositorileri Özünde saxlayir və repositorilərə UnitOfÜork üzərindən
    // Servicelərdə istifadə olunur
    public interface IUnitOfWork
    {
        ICategoryRepository CategoryRepository { get; }
        ISettingRepository SettingRepository { get; }
        IAboutRepository AboutRepository { get; }
        ITestimonialRepository TestimonialRepository { get; }
        IQuestionRepository QuestionRepository { get; }
        int Commit();
        Task<int> CommitAsync();
    }
}
