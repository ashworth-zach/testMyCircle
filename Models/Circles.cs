using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace myCircle.Models{
    [Table("circles", Schema = "circledb")]

    public class Circles{
        [Key]
        public int circleId{get;set;}

        [Required(ErrorMessage = "This field is required")]
        public string title{get;set;}
        [NotMapped]
        public List<users> Users{get;set;}
        [NotMapped]
        public List<Messages> Messages{get;set;}
        public DateTime createdAt{get;set;}
        public DateTime updatedAt{get;set;}

        
        public Circles(){
            createdAt = DateTime.Now;
            updatedAt = DateTime.Now;

        }
    }
}