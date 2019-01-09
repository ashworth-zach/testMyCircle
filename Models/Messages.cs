using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace myCircle.Models{
    [Table("messages", Schema = "circlesDB")]

    public class messages{
        [Key]
        public int messageId{get;set;}

        [Required(ErrorMessage = "This field is required")]
        public string content{get;set;}

        public DateTime createdAt{get;set;}
        [Required]
        public int userId{get;set;}
        public users user{get;set;}
        public int circleId{get;set;}
        public circles circle{get;set;}
        public List<images> images{get;set;}
        public messages(){
            createdAt = DateTime.Now;
        }
    }
}