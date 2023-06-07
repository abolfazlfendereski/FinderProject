using FinderProject.Common.Results;
using FinderProject.Domian.AutoMapperProfile;
using FinderProject.Domian.Dto;
using FinderProject.Domian.Entities;
using FinderProject.Domian.IContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinderProject.Application.Services.PersonalInfoServices.Commands
{
    public interface IAddPersonalInformationService
    {
        public ResultMethodsWithOutData Execute(PersonalInformationDto dto);
    }
    public class AddPersonalInformationService : IAddPersonalInformationService
    {
        private readonly IApplicationDbContext _context;

        public AddPersonalInformationService(IApplicationDbContext context)
        {
            this._context = context;
        }
        public ResultMethodsWithOutData Execute(PersonalInformationDto dto)
        {
                    
            var userInfo = _context.PersonalInformation.FirstOrDefault(a=>a.UserId== dto.UserId);
            if (userInfo==null)
            {
                var user = _context.Users.FirstOrDefault(a => a.Id == dto.UserId);
                var information = ObjectMapper.Mapper.Map<PersonalInformation>(dto);
                information.User = user;
                _context.PersonalInformation.Add(information);
            }
            else
            {
                userInfo.Address = dto.Address;
                userInfo.BirthDate = dto.BirthDate;
                userInfo.Email = dto.Email;
                userInfo.FullName = dto.FullName;
                userInfo.gender = dto.gender;
                userInfo.phoneNumber = dto.phoneNumber;               
            }
            
            _context.SaveChanges();
            return new ResultMethodsWithOutData()
            {
                Message = "اطلاعات فردی با موفقیت ثبت شد",
                Res = resMethod.Success
            };
        }
    }
}
