using DoAnLau_API.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DoAnLau_API.Interface
{
    public class WardDTO
    {

        public int ID { get; set; }

        public string tenXaPhuong { get; set; }

        public int quanHuyenId { get; set; }

    }
}
