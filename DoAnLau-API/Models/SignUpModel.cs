using System.ComponentModel.DataAnnotations;

namespace DoAnLau_API.Models
{
    public class SignUpModel
    {
        [EmailAddress]
        public string email { get; set; } = null!;
      
        public string name { get; set; }
        public string password { get; set; } = null!;
       
        public DateTime birthdate { get; set; }
     
        public bool gender { get; set; }
      
        public string confirmPassword { get; set; } = null!;

        public string Phone { get; set; }

    }
}
