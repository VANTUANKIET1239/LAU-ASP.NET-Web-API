using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DoAnLau_API.Models
{
    public class XaPhuong
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string tenXaPhuong { get; set;}

        [ForeignKey("QuanHuyen")]
        public int quanHuyenId { get; set; }
        public QuanHuyen quanHuyen { get; set; }
    }
}
