using System.Collections.Generic;

namespace FinderProject.Domian.Dto
{
    public class GetFavoritePersonal
    {
        public List<ProdoctbriefDto> ProdoctbriefDtos { get; set; }
        public PersonalInformationDto PersonalInformation { get; set; }
        public bool HasBussiness { get; set; }
    }
    public class GetBussinessPersonal
    {
        public List<CategoryPersonalBussiness> CategoryDtos { get; set; }
        public List<ProdoctbriefDto> ProdoctbriefDtos { get; set; }
        public PersonalInformationDto PersonalInformation { get; set; }
    }
    public class CategoryPersonalBussiness
    {
        public int id { get; set; }
        public string Name { get; set; }
        public long numberCategory { get; set; }
    }
}
