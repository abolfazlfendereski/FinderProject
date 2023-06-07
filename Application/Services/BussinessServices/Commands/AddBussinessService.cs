using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinderProject.Common.Results;
using FinderProject.Domian.AutoMapperProfile;
using FinderProject.Domian.Dto;
using FinderProject.Domian.Entities;
using FinderProject.Domian.IContext;
using Microsoft.Extensions.Logging;

namespace FinderProject.Application.Services.BussinessServices.Commands
{
    public interface IAddBussinessService
    {
        public ResultMethodsWithOutData Execute(RequestDataBussiness request,string userId);
    }
    public class AddBussinessService : IAddBussinessService
    {
        private readonly IApplicationDbContext _context;
        private readonly ILogger<AddBussinessService> _Logger;
        public AddBussinessService(IApplicationDbContext context, ILogger<AddBussinessService> logger)
        {
            this._context = context;
            _Logger = logger;
        }

        public ResultMethodsWithOutData Execute(RequestDataBussiness request,string userId)
        {
            try
            {
                var category = _context.Categories.Include(a => a.ParentCategory)
               .FirstOrDefault(a => a.Id == request.Product.SubCategoryId);

                //Add Product to DataBase
                var product = ObjectMapper.Mapper.Map<Product>(request.Product);

                product.Category = category;
                product.CategoryId = category.Id;

                var user = _context.Users.FirstOrDefault(a => a.Id == userId);
                product.User = user;
                //Add Image to DataBase
                List<Images> images = new List<Images>();
                foreach (var imgs in request.ImagesSrc)
                {
                    var img = new Images()
                    {
                        Src = imgs.Src,
                        Product = product,
                    };
                    images.Add(img);
                }
                _context.Images.AddRange(images);

                //Add Address info to DataBase
                var AddressInfo = ObjectMapper.Mapper.Map<AddressInfo>(request.AddressDto);
                _context.AddressInfos.Add(AddressInfo);

                //Add Feature To DataBase
                List<Features> features = new List<Features>();
                foreach (var fea in request.feactures)
                {
                    var featureData = ObjectMapper.Mapper.Map<Features>(fea);
                    featureData.Product = product;

                    features.Add(featureData);
                }
                _context.Features.AddRange(features);

                //Add Possibilities to DataBase
                List<Possibilities> Possibilities = new List<Possibilities>();
                foreach (var pos in request.possibilities)
                {
                    var PossibilitiesData = ObjectMapper.Mapper.Map<Possibilities>(pos);
                    PossibilitiesData.Product = product;

                    Possibilities.Add(PossibilitiesData);
                }
                _context.Possibilities.AddRange(Possibilities);

                //Add TypeRoom To DataBase
                List<TypeRoom> TypeRoom = new List<TypeRoom>();
                foreach (var room in request.typeRooms)
                {
                    var RoomData = ObjectMapper.Mapper.Map<TypeRoom>(room);
                    RoomData.Product = product;

                    TypeRoom.Add(RoomData);
                }
                _context.TypeRooms.AddRange(TypeRoom);
                //Add HotelFeature To DataBase
                List<HotelFeature> hotelFeatures = new List<HotelFeature>();
                foreach (var hotel in request.HotelFeactures)
                {
                    var hotelFeatureData = ObjectMapper.Mapper.Map<HotelFeature>(hotel);
                    hotelFeatureData.Product = product;
                    hotelFeatures.Add(hotelFeatureData);
                }
                _context.HotelFeatures.AddRange(hotelFeatures);
                //Add SocialMedia To DataBase
                List<SocialMedia> socialMedias = new List<SocialMedia>();
                foreach (var media in request.SocialMedia)
                {
                    if (media.SocialMediaSrc != null)
                    {
                        var socialMediaData = new SocialMedia()
                        { AddressSocialMedia = media.SocialMediaSrc, InsertTime = DateTime.Now, Product = product };
                        socialMedias.Add(socialMediaData);
                    }
                }
                _context.SocialMedias.AddRange(socialMedias);
                product.AddressInfo = AddressInfo;
                _context.Products.Add(product);
                _context.SaveChanges();
                return new ResultMethodsWithOutData()
                {
                    Message = "افزودن کسب و کار با موفقیت انجام شد",
                    Res = resMethod.Success
                };
            }
            catch (Exception ex)
            {
                _Logger.LogError($" رو به رو شد{ex.Message}افزودن کسب و کار با مشکل ");
                return new ResultMethodsWithOutData()
                {

                    Message = $" رو به رو شد{ex.Message}افزودن کسب و کار با مشکل ",
                    Res = resMethod.Error
                };

            }


        }
    }
}
