using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DesafioFullStackTotvs.Models {
    public class User {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long UserID { get; set; }
        public string Name { get; set; }
        public string Email {get; set;}        
        public string Password { get; set; }
        public string Cpf { get; set; }
        public bool IsAdmin { get; set;}
        public bool IsActive { get; set;}
        public string Token { get; set; }

    }
}