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
        ISubCategoryRepository SubCategoryRepository { get; }
        IMarkaRepository MarkaRepository { get; }
        ISpecificationRepository SpecificationRepository { get; }
        IProductRepository ProductRepository { get; }
        IProductColorRepository ProductColorRepository { get; }
        IProductColorImageRepository ProductColorImageRepository { get; }
        IDiscountRepository DiscountRepository { get; }
        ICommentRepository CommentRepository { get; }
        IPhoneSpecRepository PhoneSpecRepository { get; }
        INotebookSpecRepository NotebookSpecRepository { get; }
        int Commit();
        Task<int> CommitAsync();
    }
}
