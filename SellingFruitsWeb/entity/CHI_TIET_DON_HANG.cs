namespace SellingFruitsWeb.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CHI_TIET_DON_HANG
    {
        [Key]
        [StringLength(10)]
        public string Ma_Chi_Tiet_DH { get; set; }

        public int So_Luong_Xuat { get; set; }

        public int Don_Gia_Xuat { get; set; }

        [Required]
        [StringLength(10)]
        public string Ma_Don_Hang { get; set; }

        [Required]
        [StringLength(10)]
        public string Ma_Trai_Cay { get; set; }

        public virtual DON_HANG DON_HANG { get; set; }

        public virtual TRAI_CAY TRAI_CAY { get; set; }
    }
}
