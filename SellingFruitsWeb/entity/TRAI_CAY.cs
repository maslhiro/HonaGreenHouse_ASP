namespace SellingFruitsWeb.entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TRAI_CAY
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TRAI_CAY()
        {
            CHI_TIET_DON_HANG = new HashSet<CHI_TIET_DON_HANG>();
        }

        [Key]
        [StringLength(10)]
        public string Ma_Trai_Cay { get; set; }

        [Required]
        [StringLength(500)]
        public string Ten_Trai_Cay { get; set; }

        public int So_Luong { get; set; }

        public int Tinh_Trang { get; set; }

        public int Don_Gia { get; set; }

        [Required]
        [StringLength(500)]
        public string Don_Vi_Tinh { get; set; }

        [Required]
        [StringLength(10)]
        public string Loai_ID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHI_TIET_DON_HANG> CHI_TIET_DON_HANG { get; set; }

        public virtual LOAI_TRAI_CAY LOAI_TRAI_CAY { get; set; }
    }
}
