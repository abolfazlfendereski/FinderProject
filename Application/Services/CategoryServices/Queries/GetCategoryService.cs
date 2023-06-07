using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using FinderProject.Common.Results;
using FinderProject.Domian.AutoMapperProfile;
using FinderProject.Domian.Dto;
using FinderProject.Domian.IContext;

namespace FinderProject.Application.Services.CategoryServices.Queries
{
    public interface IGetcategoryService
    {
        ResultMethods<List<GetCategoryDto>> GetCategory(long? parentid);
        public List<subCategoryDto> GetSubCate(long ParentId);
    }
    public class GetCategoryService : IGetcategoryService
    {
        private readonly IApplicationDbContext context;

        public GetCategoryService(IApplicationDbContext context)
        {
            this.context = context;
        }
        public ResultMethods<List<GetCategoryDto>> GetCategory(long? parentid)
        {
            try
            {
                
                var category = context.Categories.AsQueryable().Include(p => p.ParentCategory)
               .Include(p => p.SubCategories)
               .Where(a => a.ParentCategoryId == parentid).ToList();
                var data = ObjectMapper.Mapper.Map<List<GetCategoryDto>>(category);
                return new ResultMethods<List<GetCategoryDto>>()
                {
                    Data = data,
                    Message = "لیست با موفقیت برگشت داده شد",
                    Res = resMethod.Success
                };

            }
            catch (Exception ex)
            {
                //_logger.LogError($"گرفتن دسته بندی با ارور{ex.Message}مواجه شد");
                return new ResultMethods<List<GetCategoryDto>>()
                {
                    Data = null,
                    Message = $"با مشکل :{ex.Message} رو به رو شد",
                    Res = resMethod.Error
                };
            }
        }
        public List<subCategoryDto> GetSubCate(long ParentId)
        {
            
            var Sub = context.Categories.Include(p => p.ParentCategory).Where(a => a.ParentCategoryId == ParentId).ToList();
            var Data = ObjectMapper.Mapper.Map<List<subCategoryDto>>(Sub);
            return Data;
        }
    }
}
