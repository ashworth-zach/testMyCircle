using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace myCircle.Models
{
    public class Login
    {
        [Required]
        [Display(Name = "Email:")]
        [EmailAddress(ErrorMessage = "Invalid email")]
        public string email{get;set;}
        
        [Required]
        [Display(Name = "Password:")]
        [DataType(DataType.Password)]
        public string password{get;set;}
        
    }
}