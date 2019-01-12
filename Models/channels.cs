using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace myCircle.Models{
    [Table("channels", Schema = "circlesDB")]

    public class channels{
        [Key]
        public int channelId{get;set;}

        [Required(ErrorMessage = "This field is required")]
        public string name{get;set;}
        public DateTime createdAt{get;set;}
        public int circleId{get;set;}
        public circles Circle{get;set;}
        public List<messages> Messages{get;set;}

        
        public channels(){
            createdAt = DateTime.Now;
            Messages = new List<messages>();
        }
    }
}