using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EndPoint.FinderProject.Models
{
    public class RegisterViewModel
    {
        [Required]
        [Display(Name ="نام و نام خانوادگی")]
        public string FullName { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name = "پست الکترونیکی")]
        [Remote("IsEmailInUse","Account",HttpMethod ="Post", AdditionalFields = "__RequestVerificationToken")]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }
    }
}
