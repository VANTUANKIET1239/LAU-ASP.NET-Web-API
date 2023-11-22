using DoAnLau_API.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DoAnLau_API.Interface
{
    public class UserDTO
    {
        public string userId { get; set; }

        public byte[]? userImage { get; set; }
      
        public string name { get; set; }

        public string email { get; set; }

        public bool gender { get; set; }

        public DateTime birthDate { get; set; }

        public string phone { get; set; }

        public int rewardPoints { get; set; }

       // public IFormFile uploadImage { get; set; }

        /* public bool role { get; set; }


         public bool state { get; set; }*/


    }
}
