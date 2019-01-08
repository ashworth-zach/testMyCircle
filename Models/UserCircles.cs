using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace myCircle.Models{
    [Table("usercircles", Schema = "circledb")]

    public class UserCircles{
        [Required]
        public int userId{get;set;}
        public users User{get;set;}
        [Required]
        public int circleId{get;set;}
        public Circles Circle{get;set;}


    }
}