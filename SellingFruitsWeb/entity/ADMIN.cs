namespace SellingFruitsWeb.entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ADMIN")]
    public partial class ADMIN
    {
        [Key]
        [StringLength(10)]
        public string Auto_ID { get; set; }

        [Required]
        [StringLength(500)]
        public string Ten_Dang_Nhap { get; set; }

        [Required]
        [StringLength(500)]
        public string Mat_Khau { get; set; }
    }
}
