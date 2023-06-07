using System;
using FinderProject.Common.Results;
using FinderProject.Domian.Entities;
using FinderProject.Domian.IContext;

namespace FinderProject.Application.Services.CategoryServices.Commands
{
   public interface IAddNewCategory
    {
        ResultMethodsWithOutData AddCategory(string name, long? Parentid);
    }
    public class AddNewCategory : IAddNewCategory
    {
        private readonly IApplicationDbContext context;

        public AddNewCategory(IApplicationDbContext context)
        {
            this.context = context;
        }

        public ResultMethodsWithOutData AddCategory(string name,long?Parentid)
        {
            try
            {
                if (name == null)
                {
                    return new ResultMethodsWithOutData
                    {
                        Message = "اطلاعات ناقص است لطفا آن را تکمیل کنید",
                        Res = resMethod.Warning
                    };
                }
                else
                {
                    Category category = new Category() {Name=name,ParentCategoryId=Parentid, };
                    context.Categories.Add(category);
                    context.SaveChanges();
                    return new ResultMethodsWithOutData
                    {
                        Message = "دسته بندی با موفقیت ثبت شد",
                        Res = resMethod.Success
                    };
                }
            }
            catch (Exception ex)
            {
                //logger.LogError($"اضافه کردن دسته بندی با ارور{ex.Message}مواجه شده است");
                return new ResultMethodsWithOutData
                {
                    Message=$"Error is:{ex.Message}",
                    Res=resMethod.Error
                };
              
            }
            
        }
    }
}
