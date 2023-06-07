using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinderProject.Domian.Dto
{
  public  class CommentDetailDto
    {
        public ProductDto ProductDto { get; set; }
        public List<CommentProductDto> CommentProducts  { get; set; }
        public string categoryName { get; set; }
        public addressDto Address { get; set; }
        public List<ProdoctbriefDto> RelatedBussiness { get; set; }
        public CommentProductDto AddCommentProductDto { get; set; }
        public PersonalInformationDto PersonalInformationDto { get; set; }

    }
}
