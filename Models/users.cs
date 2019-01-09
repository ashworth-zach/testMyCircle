using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace myCircle.Models{
    [Table("users", Schema = "circlesDB")]

    public class users{
        [Key]
        public int userId{get;set;}

        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Username:")]
        [MinLength(2, ErrorMessage = "Username must be atleast 2 characters")]
        [MaxLength(100, ErrorMessage = "Username must be less than 100 characters")]
        public string username{get;set;}

        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Email:")]
        [EmailAddress(ErrorMessage = "Invalid email")]
        [MaxLength(100, ErrorMessage = "Email Name must be atleast 2 characters")]
        public string email{get;set;}

        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Password:")]
        [DataType(DataType.Password)]
        [MinLength(8, ErrorMessage = "Password must be longer than 8 characters")]
        [MaxLength(255, ErrorMessage = "Password must be less than 255 characters")]
        public string password{get;set;}


        [NotMapped]
        [Display(Name = "Confirm Password:")]
        [Compare("password", ErrorMessage = "Password and Confirm do not match")]
        [DataType(DataType.Password)]
        public string confirm {get;set;}
        public List<usercircles> usercircles{get;set;}
        public List<messages> messages{get;set;}
        public List<messagelikes> Likes{get;set;}
        
        public DateTime createdAt{get;set;}
        public DateTime updatedAt{get;set;}
        public users(){
            createdAt = DateTime.Now;
            updatedAt = DateTime.Now;
        }
    }
}