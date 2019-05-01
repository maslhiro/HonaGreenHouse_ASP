namespace SellingFruitsWeb.entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("USERS")]
    public partial class USER
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public USER()
        {
            DON_HANG = new HashSet<DON_HANG>();
        }

        [Key]
        [StringLength(10)]
        public string Ma_Khach_Hang { get; set; }

        [Required]
        [StringLength(500)]
        public string Ten_Dang_Nhap { get; set; }

        [Required]
        [StringLength(500)]
        public string Mat_Khau { get; set; }

        [Required]
        [StringLength(500)]
        public string Ho_Ten { get; set; }

        [Required]
        [StringLength(20)]
        public string So_Dien_Thoai { get; set; }

        [Required]
        [StringLength(500)]
        public string Dia_Chi { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DON_HANG> DON_HANG { get; set; }
    }
}
