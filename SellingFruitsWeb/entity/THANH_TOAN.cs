namespace SellingFruitsWeb.entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class THANH_TOAN
    {
        [Key]
        [StringLength(10)]
        public string Ma_Thanh_Toan { get; set; }

        [Required]
        [StringLength(500)]
        public string Bang_Chung_Thanh_Toan { get; set; }

        [Required]
        [StringLength(10)]
        public string Ma_Don_Hang { get; set; }

        public virtual DON_HANG DON_HANG { get; set; }
    }
}
