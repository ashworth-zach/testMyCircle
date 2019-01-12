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
        public int userId{get;set;}
        public users User{get;set;}
        public int messageId{get;set;}
        public messages Messages{get;set;}
    }
}