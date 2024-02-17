using DoAnLau_API.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DoAnLau_API.Interface
{
    public class ReservationDTO
    {
       
        public string reservation_Id { get; set; }

        public DateTime reservationDate { get; set; }

        public string customerSizeId { get; set; }

        public string branchId { get; set; }

        public string reservationTimeId { get; set; }

        public int customerSize { get; set; }

        public string branchName { get; set; }

        public string branchAddress { get; set; }

        public string time { get; set; }

        public bool state { get; set; }

       
    }
}
