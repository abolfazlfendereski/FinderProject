using System.Collections.Generic;

namespace FinderProject.Domian.Dto
{
    public class GetMyOrdersDto
    {
        public ProdoctbriefDto ProdoctbriefDtos { get; set; }
        public BookBussinessDto BookBussinessDtos { get; set; }
    }
    public class OrderDto
    {
        public long id { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public string Codemeli { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public int Number { get; set; }
        public string PhoneNumber { get; set; }
        public string Product { get; set; }
        public string Category { get; set; }
    }
}
