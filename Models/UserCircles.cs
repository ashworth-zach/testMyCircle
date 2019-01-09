using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace myCircle.Models{
    [Table("usercircles", Schema = "circlesDB")]

    public class UserCircles{
        [Key]
        public int usercircleId{get;set;}
        [Required]
        public int userId{get;set;}
        [NotMapped]
        public users User{get;set;}
        [Required]
        public int circleId{get;set;}
        [NotMapped]
        public circles Circle{get;set;}


    }
}