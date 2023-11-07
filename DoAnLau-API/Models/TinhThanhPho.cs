using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DoAnLau_API.Models
{
    public class TinhThanhPho
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
       
        public int ID { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string tenTinhThanhPho { get; set; }

        [ForeignKey("QuocGia")]
        public int quocGiaId { get; set; }
        public QuocGia quocGia { get; set; }
        public ICollection<QuanHuyen> quanHuyens { get; set; }
    }
}
