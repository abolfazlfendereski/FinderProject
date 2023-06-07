using FinderProject.Domian.Entities;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinderProject.Domian.Dto
{
    public class PersonalInformationDto
    {
        public string FullName { get; set; }
        public string gender { get; set; }
        public string BirthDate { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string phoneNumber { get; set; }
        public string Address { get; set; }
        public User User { get; set; }
        public string UserId { get; set; }
        public bool HasBussiness { get; set; }
    }
}
