using DoAnLau_API.Data;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DoAnLau_API.Models
{
    public class SYS_INDEX
    {
        
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string prefix { get; set; }
        public int currentIndex { get; set; }
        [Column(TypeName = " nvarchar(100)")]
        public string nameIndex { get; set; }

    }
}
