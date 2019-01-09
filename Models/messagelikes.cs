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
        [NotMapped]
        public users User{get;set;}
        [Required]
        public int messageId{get;set;}
        [NotMapped]
        public messages Messages{get;set;}
    }
}