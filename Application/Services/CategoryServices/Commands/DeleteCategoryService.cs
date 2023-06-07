
using FinderProject.Common.Results;
using FinderProject.Domian.IContext;

namespace FinderProject.Application.Services.CategoryServices.Commands
{
    public interface IDeleteCategoryService
    {
        ResultMethodsWithOutData DeleteCategory(long id);
    }
    public class DeleteCategoryService : IDeleteCategoryService
    {
        private readonly IApplicationDbContext context;

        public DeleteCategoryService(IApplicationDbContext context)
        {
            this.context = context;
        }
        public ResultMethodsWithOutData DeleteCategory(long id)
        {
            var q = context.Categories.Find(id);
            context.Categories.Remove(q);
            context.SaveChanges();
            return new ResultMethodsWithOutData {Message="حذف با موفقیت انجام شد" ,Res=resMethod.Success};
        }
    }
}
