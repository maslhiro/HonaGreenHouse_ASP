namespace SellingFruitsWeb.entity
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class HonaModel : DbContext
    {
        public HonaModel()
            : base("name=HonaModel")
        {
        }

        public virtual DbSet<ADMIN> ADMINs { get; set; }
        public virtual DbSet<CHI_TIET_CHUYEN_HANG> CHI_TIET_CHUYEN_HANG { get; set; }
        public virtual DbSet<CHI_TIET_DON_HANG> CHI_TIET_DON_HANG { get; set; }
        public virtual DbSet<DON_HANG> DON_HANG { get; set; }
        public virtual DbSet<LOAI_TRAI_CAY> LOAI_TRAI_CAY { get; set; }
        public virtual DbSet<THANH_TOAN> THANH_TOAN { get; set; }
        public virtual DbSet<TRAI_CAY> TRAI_CAY { get; set; }
        public virtual DbSet<USER> USERS { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ADMIN>()
                .Property(e => e.Auto_ID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ADMIN>()
                .Property(e => e.Ten_Dang_Nhap)
                .IsUnicode(false);

            modelBuilder.Entity<ADMIN>()
                .Property(e => e.Mat_Khau)
                .IsUnicode(false);

            modelBuilder.Entity<CHI_TIET_CHUYEN_HANG>()
                .Property(e => e.Ma_Chi_Tiet_CH)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CHI_TIET_CHUYEN_HANG>()
                .Property(e => e.Ho_Ten)
                .IsUnicode(false);

            modelBuilder.Entity<CHI_TIET_CHUYEN_HANG>()
                .Property(e => e.So_Dien_Thoai)
                .IsUnicode(false);

            modelBuilder.Entity<CHI_TIET_CHUYEN_HANG>()
                .Property(e => e.Dia_Chi_Nhan)
                .IsUnicode(false);

            modelBuilder.Entity<CHI_TIET_CHUYEN_HANG>()
                .Property(e => e.Ma_Don_Hang)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CHI_TIET_DON_HANG>()
                .Property(e => e.Ma_Chi_Tiet_DH)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CHI_TIET_DON_HANG>()
                .Property(e => e.Ma_Don_Hang)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CHI_TIET_DON_HANG>()
                .Property(e => e.Ma_Trai_Cay)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DON_HANG>()
                .Property(e => e.Ma_Don_Hang)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DON_HANG>()
                .Property(e => e.Ma_Chi_Tiet_DH)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DON_HANG>()
                .Property(e => e.Ma_Khach_Hang)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DON_HANG>()
                .HasMany(e => e.CHI_TIET_CHUYEN_HANG)
                .WithRequired(e => e.DON_HANG)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DON_HANG>()
                .HasMany(e => e.CHI_TIET_DON_HANG)
                .WithRequired(e => e.DON_HANG)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DON_HANG>()
                .HasMany(e => e.THANH_TOAN)
                .WithRequired(e => e.DON_HANG)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LOAI_TRAI_CAY>()
                .Property(e => e.Ma_Loai_Trai_Cay)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<LOAI_TRAI_CAY>()
                .Property(e => e.Ten_Loai_Trai_Cay)
                .IsUnicode(false);

            modelBuilder.Entity<LOAI_TRAI_CAY>()
                .Property(e => e.Xuat_Xu)
                .IsUnicode(false);

            modelBuilder.Entity<LOAI_TRAI_CAY>()
                .HasMany(e => e.TRAI_CAY)
                .WithRequired(e => e.LOAI_TRAI_CAY)
                .HasForeignKey(e => e.Loai_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<THANH_TOAN>()
                .Property(e => e.Ma_Thanh_Toan)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<THANH_TOAN>()
                .Property(e => e.Bang_Chung_Thanh_Toan)
                .IsUnicode(false);

            modelBuilder.Entity<THANH_TOAN>()
                .Property(e => e.Ma_Don_Hang)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TRAI_CAY>()
                .Property(e => e.Ma_Trai_Cay)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TRAI_CAY>()
                .Property(e => e.Ten_Trai_Cay)
                .IsUnicode(false);

            modelBuilder.Entity<TRAI_CAY>()
                .Property(e => e.Don_Vi_Tinh)
                .IsUnicode(false);

            modelBuilder.Entity<TRAI_CAY>()
                .Property(e => e.Loai_ID)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TRAI_CAY>()
                .HasMany(e => e.CHI_TIET_DON_HANG)
                .WithRequired(e => e.TRAI_CAY)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<USER>()
                .Property(e => e.Ma_Khach_Hang)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<USER>()
                .Property(e => e.Ten_Dang_Nhap)
                .IsUnicode(false);

            modelBuilder.Entity<USER>()
                .Property(e => e.Mat_Khau)
                .IsUnicode(false);

            modelBuilder.Entity<USER>()
                .Property(e => e.Ho_Ten)
                .IsUnicode(false);

            modelBuilder.Entity<USER>()
                .Property(e => e.So_Dien_Thoai)
                .IsUnicode(false);

            modelBuilder.Entity<USER>()
                .Property(e => e.Dia_Chi)
                .IsUnicode(false);

            modelBuilder.Entity<USER>()
                .HasMany(e => e.DON_HANG)
                .WithRequired(e => e.USER)
                .WillCascadeOnDelete(false);
        }
    }
}
