using AutoMapper;
using EndPoint.FinderProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinderProject.Domian.Dto;
using EndPoint.FinderProject.Areas.Admin.Models;
using FinderProject.Domian.Entities;

namespace EndPoint.FinderProject.AutoMapperService
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<ProductDto, ProductViewModel>().ReverseMap()
                .AfterMap((vm,dto) =>
            {
                
                dto.numberRoom = int.Parse(vm.numberRoom); 
            });
            CreateMap<product_FeactureDto, product_Feacture>().ReverseMap();
            CreateMap<product_PossibilitiesDto, product_Possibilities>().ReverseMap();
            CreateMap<product_TypeRoomDto, product_TypeRoom>().ReverseMap();
            CreateMap<Product_SocialMediaDto, Product_SocialMedia>().ReverseMap();
            CreateMap<ProdoctbriefDto, ProdoctBriefVM>().ReverseMap();
            CreateMap<ProductDto, DetailMainViewModel>().ReverseMap();
            CreateMap<ProductDto, DetailBussinessInfoViewModel>().ReverseMap();
            CreateMap<NewsDto, NewsViewModel>().ReverseMap();
            CreateMap<Advertising, AdvertisingViewModel>().ReverseMap();
            CreateMap<BookBussinessDto, AddOrderBussinessViewModel>().ReverseMap();
        }
        
    }
}
