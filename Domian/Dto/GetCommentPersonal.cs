using FinderProject.Domian.Dto;
using System.Collections.Generic;

namespace FinderProject.Domian.Dto
{
    public class GetCommentPersonal
    {
        public List<CommentProductDto> Comments { get; set; }
        public PersonalInformationDto PersonalInformation { get; set; }
        public bool HasBussiness { get; set; }
    }
}
