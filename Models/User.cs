
namespace DesafioFullStackTotvs.Models {
    public class User {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Email {get; set;}
        public string User { get; set; }
        public HashSet<string> Password { get; set; }
        public string Cpf { get; set; }
        public bool IsAdmin { get; set;}
        public bool IsActive { get; set;}
    }
}