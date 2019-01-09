using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace myCircle.Models{
    [Table("messages", Schema = "circlesDB")]

    public class messages{
        [Key]
        public int messageId{get;set;}

        [Required(ErrorMessage = "This field is required")]
        public string content{get;set;}

        public DateTime createdAt{get;set;}
        [Required]
        public int userId{get;set;}
<<<<<<< HEAD
        public users user{get;set;}
        public int circleId{get;set;}
        public circles circle{get;set;}
        public List<images> images{get;set;}
        public messages(){
=======
        [NotMapped]
        public users User{get;set;}
        public int circleId{get;set;}
        [NotMapped]
        public Circles Circle{get;set;}
        [NotMapped]
        public List<images> Images{get;set;}
        public Messages(){
>>>>>>> d908e83a3164ee070a4f31282bcb9916f05e0cca
            createdAt = DateTime.Now;
        }
    }
}