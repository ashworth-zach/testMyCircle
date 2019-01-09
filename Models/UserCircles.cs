using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace myCircle.Models{
    [Table("usercircles", Schema = "circlesDB")]

    public class usercircles{
        [Required]
        public int userId{get;set;}
        public users user{get;set;}
        [Required]
        public int circleId{get;set;}
        public List<circles> circle{get;set;}


    }
}