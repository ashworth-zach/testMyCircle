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
        [NotMapped]
        public users User{get;set;}
        [Required]
        public int channelId{get;set;}
        [NotMapped]
        public channels Channel{get;set;}
        [NotMapped]
        public List<images> Images{get;set;}
        public messages(){
            createdAt = DateTime.Now;
        }
    }
}