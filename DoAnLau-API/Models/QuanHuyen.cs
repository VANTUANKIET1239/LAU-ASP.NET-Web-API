using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DoAnLau_API.Models
{
    public class QuanHuyen
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public  int ID { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string tenQuanHuyen { get; set; }

        [ForeignKey("TinhThanhPho")]
        public int tinhThanhPhoId { get; set; }
        public TinhThanhPho tinhThanhPho { get; set; }

        public ICollection<XaPhuong> xaPhuongs { get; set; }
    }
}
