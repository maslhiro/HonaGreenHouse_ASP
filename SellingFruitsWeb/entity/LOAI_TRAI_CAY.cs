namespace SellingFruitsWeb.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class LOAI_TRAI_CAY
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LOAI_TRAI_CAY()
        {
            TRAI_CAY = new HashSet<TRAI_CAY>();
        }

        [Key]
        [StringLength(10)]
        public string Ma_Loai_Trai_Cay { get; set; }

        [Required]
        [StringLength(500)]
        public string Ten_Loai_Trai_Cay { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TRAI_CAY> TRAI_CAY { get; set; }
    }
}
