using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace myCircle.Models{
    [Table("images", Schema = "circledb")]

    public class images{
        [Key]
        public int imageId{get;set;}

        [Required(ErrorMessage = "This field is required")]
        public string data{get;set;}
        [Required]
        public int messageId{get;set;}

        public Messages Message{get;set;}

    }
}