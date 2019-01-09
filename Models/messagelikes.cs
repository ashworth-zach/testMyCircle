using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace myCircle.Models
{
    [Table("messagelikes", Schema = "circlesDB")]
    public class messagelikes
    {
        [Key]
        public int likeId{get;set;}
        [Required]
        public int userId{get;set;}
<<<<<<< HEAD
        public users user{get;set;}
        [Required]
        public int messageId{get;set;}
        public messages messages{get;set;}
=======
        [NotMapped]
        public users User{get;set;}
        [Required]
        public int messageId{get;set;}
        [NotMapped]
        public Messages Messages{get;set;}
>>>>>>> d908e83a3164ee070a4f31282bcb9916f05e0cca
    }
}