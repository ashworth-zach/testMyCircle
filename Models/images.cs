using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace myCircle.Models{
    public class images{
        [Key]
        public int imageId{get;set;}

        [Required(ErrorMessage = "This field is required")]
        public string image{get;set;}

        public DateTime createdAt{get;set;}
        public images(){
            createdAt = DateTime.Now;
        }
    }
}