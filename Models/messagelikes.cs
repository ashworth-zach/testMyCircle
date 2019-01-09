using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace myCircle.Models
{
    [Table("messagelikes", Schema = "circlesDB")]
    public class messagelikes
    {
        [Required]
        public int userId{get;set;}
        public users user{get;set;}
        [Required]
        public int messageId{get;set;}
        public messages messages{get;set;}
    }
}