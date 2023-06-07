using FinderProject.Domian.AutoMapperProfile;
using FinderProject.Domian.Dto;
using FinderProject.Domian.IContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinderProject.Application.Services.PersonalInfoServices.Queries
{
    public interface IGetInformationService
    {
       public PersonalInformationDto Execute(string userId);
    }
    public class GetInformationService : IGetInformationService
    {
        private readonly IApplicationDbContext _context;

        public GetInformationService(IApplicationDbContext context)
        {
            this._context = context;
        }
        public PersonalInformationDto Execute(string userId)
        {
            var result = _context.PersonalInformation.FirstOrDefault(a=>a.UserId==userId);
            var returnData = ObjectMapper.Mapper.Map<PersonalInformationDto>(result);
            return returnData==null?new PersonalInformationDto() {Address=" ",FullName=" ",BirthDate=" ",Email=" ",gender=" ",phoneNumber=" "}:returnData;
        }
    }
}
