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
        IMarkaRepository markaRepository;
        ISubCategoryRepository subCategoryRepository;
        IAboutRepository aboutRepository;
        ITestimonialRepository testimonialRepository;
        IQuestionRepository questionRepository;
        IProductColorImageRepository productColorImageRepository;
        IProductColorRepository productColorRepository;
        IProductRepository productRepository;
        ISpecificationRepository specificationRepository;
        IDiscountRepository discountRepository;
        ICommentRepository commentRepository;
        IPhoneSpecRepository phoneSpecRepository;
        INotebookSpecRepository notebookSpecRepository;
        IBlogRepository blogRepository;
        IBlogCommentRepository blogCommentRepository;
        IReplyCommentRepository replyCommentRepository;
        ISubCategoryMarkaRepository subCategoryMarkaRepository;
        ISliderRepository sliderRepository;
        private readonly AntomiDbContext context;

        public UnitOfWork(AntomiDbContext context)
        {
            this.context = context;
        }
        // categoryRepository null deyilse özünü deyilse yeni obyektini yaradib gonderir
        public ICategoryRepository CategoryRepository => categoryRepository ?? new CategoryRepository(context);

        public ISettingRepository SettingRepository => settingRepository ?? new SettingRepository(context);

        public IAboutRepository AboutRepository => aboutRepository ?? new AboutRepository(context);

        public ITestimonialRepository TestimonialRepository => testimonialRepository ?? new TestimonialRepository(context);

        public IQuestionRepository QuestionRepository => questionRepository ?? new QuestionRepository(context);

        public ISubCategoryRepository SubCategoryRepository => subCategoryRepository ?? new SubCategoryRepository(context);

        public IMarkaRepository MarkaRepository => markaRepository ?? new MarkaRepository(context);

        public ISpecificationRepository SpecificationRepository => specificationRepository ?? new SpecificationRepository(context);

        public IProductRepository ProductRepository => productRepository ?? new ProductRepository(context);

        public IProductColorRepository ProductColorRepository => productColorRepository ?? new ProductColorRepository(context);

        public IProductColorImageRepository ProductColorImageRepository => productColorImageRepository ?? new ProductColorImageRepository(context);

        public IDiscountRepository DiscountRepository => discountRepository ?? new DiscountRepository(context);

        public ICommentRepository CommentRepository => commentRepository ?? new CommentRepository(context);

        public IPhoneSpecRepository PhoneSpecRepository => phoneSpecRepository ?? new PhoneSpecRepository(context);

        public INotebookSpecRepository NotebookSpecRepository => notebookSpecRepository ?? new NotebookSpecRepository(context);

        public IBlogRepository BlogRepository => blogRepository ?? new BlogRepository(context);

        public IBlogCommentRepository BlogCommentRepository => blogCommentRepository ?? new BLogCommentRepository(context);

        public IReplyCommentRepository ReplyCommentRepository => replyCommentRepository ?? new ReplyCommentRepository(context);

        public ISubCategoryMarkaRepository SubCategoryMarkaRepository => subCategoryMarkaRepository ?? new SubCategoryToMarkaRepository(context);

        public ISliderRepository SliderRepository => sliderRepository ?? new SliderRepository(context);

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
