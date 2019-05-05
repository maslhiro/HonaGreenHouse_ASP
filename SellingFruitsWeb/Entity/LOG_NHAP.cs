namespace SellingFruitsWeb.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class LOG_NHAP
    {
        [Key]
        [StringLength(10)]
        public string Auto_ID { get; set; }

        [Required]
        [StringLength(10)]
        public string Ma_Trai_Cay { get; set; }

        [Column(TypeName = "date")]
        public DateTime Thoi_Gian { get; set; }

        public int Tong_Tien { get; set; }

        public int So_Luong_Nhap { get; set; }
    }
}
