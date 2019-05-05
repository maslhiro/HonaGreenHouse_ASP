namespace SellingFruitsWeb.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CHI_TIET_TRAI_CAY
    {
        [Key]
        [StringLength(10)]
        public string Ma_Chi_Tiet_Trai_Cay { get; set; }

        [Required]
        public string Hinh_Trai_Cay { get; set; }

        [Required]
        [StringLength(10)]
        public string Ma_Trai_Cay { get; set; }

        public virtual TRAI_CAY TRAI_CAY { get; set; }
    }
}
