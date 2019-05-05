namespace SellingFruitsWeb.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class LOG_THANH_TOAN
    {
        [Key]
        [StringLength(10)]
        public string Auto_ID { get; set; }

        [Column(TypeName = "date")]
        public DateTime Thoi_Gian { get; set; }

        public int Tong_Tien { get; set; }

        [Required]
        [StringLength(10)]
        public string Ma_Don_Hang { get; set; }
    }
}
