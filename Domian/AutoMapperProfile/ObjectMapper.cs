using AutoMapper;
using System;

using FinderProject.Domian.Dto;
using FinderProject.Domian.Entities;

namespace FinderProject.Domian.AutoMapperProfile
{
   public class ObjectMapper
    {
        // The best implementation of AutoMapper for class libraries - https://stackoverflow.com/questions/26458731/how-to-configure-auto-mapper-in-class-library-project
        private static readonly Lazy<IMapper> Lazy = new Lazy<IMapper>(() =>
        {
            var config = new MapperConfiguration(cfg =>
            {
                // This line ensures that internal properties are also mapped over.
                cfg.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsAssembly;
                cfg.AddProfile<AspnetRunDtoMapper>();
            });
            var mapper = config.CreateMapper();
            return mapper;
        });
        public static IMapper Mapper => Lazy.Value;

        public class AspnetRunDtoMapper : Profile
        {
            public AspnetRunDtoMapper()
            {
                CreateMap<Category, GetCategoryDto>()
                 .ForMember(dest => dest.HasChild, opt => opt.MapFrom(i => i.SubCategories == null ? false : true))
                 .AfterMap((src, dest) =>
                 {
                     dest.Parent = src.ParentCategory != null ? new
                    ParentCategoryDto
                     {
                         Id = src.ParentCategory.Id,
                         name = src.ParentCategory.Name,
                     }
                    : null;
                 });
                CreateMap<Category, subCategoryDto>();
                CreateMap<Product, ProductDto>().ReverseMap();
                CreateMap<AddressInfo, addressDto>().ReverseMap();
                CreateMap<Features, product_FeactureDto>().ReverseMap();
                CreateMap<Possibilities, product_PossibilitiesDto>().ReverseMap();
                CreateMap<TypeRoom, product_TypeRoomDto>().ReverseMap();
                CreateMap<HotelFeature, product_HotelFeactureDto>().ReverseMap();
                CreateMap<SocialMedia, Product_SocialMediaDto>().ReverseMap();
                CreateMap<CommentProduct, CommentProductDto>().ReverseMap();
                CreateMap<News, NewsDto>().ReverseMap();
                CreateMap<Order, BookBussinessDto>().ReverseMap();
                CreateMap<PersonalInformation, PersonalInformationDto>().ReverseMap();
                
            }
        }
    }
}
