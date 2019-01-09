using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace myCircle.Models{
    [Table("usercircles", Schema = "circlesDB")]

<<<<<<< HEAD
    public class usercircles{
        [Required]
        public int userId{get;set;}
        public users user{get;set;}
        [Required]
        public int circleId{get;set;}
        public List<circles> circle{get;set;}
=======
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
        public Circles Circle{get;set;}
>>>>>>> d908e83a3164ee070a4f31282bcb9916f05e0cca


    }
}