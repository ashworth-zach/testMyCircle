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
        public int circleId{get;set;}
        [NotMapped]
        public circles Circle{get;set;}
        [NotMapped]
        public List<messages> Messages{get;set;}
        public DateTime createdAt{get;set;}

        
        public circles(){
            createdAt = DateTime.Now;
        }
    }
}