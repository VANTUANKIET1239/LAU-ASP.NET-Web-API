using DoAnLau_API.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DoAnLau_API.Interface
{
    public class DistrictDTO
    {

       
        public int ID { get; set; }

        
        public string tenQuanHuyen { get; set; }

      
        public int tinhThanhPhoId { get; set; }

    }
}
