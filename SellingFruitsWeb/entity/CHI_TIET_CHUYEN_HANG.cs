namespace SellingFruitsWeb.entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CHI_TIET_CHUYEN_HANG
    {
        [Key]
        [StringLength(10)]
        public string Ma_Chi_Tiet_CH { get; set; }

        [Required]
        [StringLength(500)]
        public string Ho_Ten { get; set; }

        [Required]
        [StringLength(20)]
        public string So_Dien_Thoai { get; set; }

        [Required]
        [StringLength(500)]
        public string Dia_Chi_Nhan { get; set; }

        [Required]
        [StringLength(10)]
        public string Ma_Don_Hang { get; set; }

        public virtual DON_HANG DON_HANG { get; set; }
    }
}
