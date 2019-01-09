using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace myCircle.Models{
    [Table("circles", Schema = "circlesDB")]

    public class circles{
        [Key]
        public int circleId{get;set;}

        [Required(ErrorMessage = "This field is required")]
        public string title{get;set;}
<<<<<<< HEAD
        public List<users> Users{get;set;}
        public List<messages> messages{get;set;}
=======
        [NotMapped]
        public List<users> Users{get;set;}
        [NotMapped]
        public List<Messages> Messages{get;set;}
>>>>>>> d908e83a3164ee070a4f31282bcb9916f05e0cca
        public DateTime createdAt{get;set;}
        public DateTime updatedAt{get;set;}

        
        public circles(){
            createdAt = DateTime.Now;
            updatedAt = DateTime.Now;

        }
    }
}