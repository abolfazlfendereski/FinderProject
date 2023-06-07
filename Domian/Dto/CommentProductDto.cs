using FinderProject.Domian.Entities;
using System;

namespace FinderProject.Domian.Dto
{
    public class CommentProductDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public byte Score { get; set; }
        public string Comments { get; set; }
        public DateTime insertTime { get; set; }
        public long ProductId { get; set; }
        public string ProductName { get; set; }
        public User User { get; set; }
        public string userId { get; set; }
    }    
}