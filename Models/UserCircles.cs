using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace myCircle.Models{
    [Table("usercircles", Schema = "circlesDB")]

    public class UserCircles{
        [Key]
        public int usercircleId{get;set;}
        public int userId{get;set;}
        public users User{get;set;}
        public int circleId{get;set;}
        public circles Circle{get;set;}


    }
}