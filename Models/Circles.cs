using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace myCircle.Models{
    [Table("circles", Schema = "circlesdb")]

    public class circles{
        [Key]
        public int circleId{get;set;}

        [Required(ErrorMessage = "This field is required")]
        public string title{get;set;}
        public DateTime createdAt{get;set;}
        public DateTime updatedAt{get;set;}
        public List<messages> Messages{get;set;}
        public List<channels> channels{get;set;}
        public List<UserCircles> UserCircles{get;set;}

        
        public circles(){
            createdAt = DateTime.Now;
            updatedAt = DateTime.Now;
            Messages = new List<messages>();
            channels = new List<channels>();
            UserCircles = new List<UserCircles>();

        }
    }
}