namespace SellingFruitsWeb.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DON_HANG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DON_HANG()
        {
            CHI_TIET_CHUYEN_HANG = new HashSet<CHI_TIET_CHUYEN_HANG>();
            CHI_TIET_DON_HANG = new HashSet<CHI_TIET_DON_HANG>();
        }

        [Key]
        [StringLength(10)]
        public string Ma_Don_Hang { get; set; }

        [Required]
        [StringLength(10)]
        public string Ma_Chi_Tiet_DH { get; set; }

        [Column(TypeName = "date")]
        public DateTime Ngay_Dat { get; set; }

        public int Hinh_Thuc_Thanh_Toan { get; set; }

        [Required]
        public string Bang_Chung_Thanh_Toan { get; set; }

        public int Tinh_Trang { get; set; }

        [Required]
        [StringLength(10)]
        public string Ma_Khach_Hang { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHI_TIET_CHUYEN_HANG> CHI_TIET_CHUYEN_HANG { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHI_TIET_DON_HANG> CHI_TIET_DON_HANG { get; set; }

        public virtual USER USER { get; set; }
    }
}
