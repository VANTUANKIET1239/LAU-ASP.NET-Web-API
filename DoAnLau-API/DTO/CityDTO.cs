using DoAnLau_API.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DoAnLau_API.Interface
{
    public class CityDTO
    {

        

        public int ID { get; set; }
      
        public string tenTinhThanhPho { get; set; }

       
        public int quocGiaId { get; set; }

    }
}
