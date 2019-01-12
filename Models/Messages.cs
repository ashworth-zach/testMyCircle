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
        public int userId{get;set;}
        public users User{get;set;}
        public int channelId{get;set;}
        public channels Channel{get;set;}
        public List<images> Images{get;set;}
        public List<messagelikes> likes{get;set;}
        public messages(){
            createdAt = DateTime.Now;
            Images = new List<images>();
            likes = new List<messagelikes>();

        }
    }
}