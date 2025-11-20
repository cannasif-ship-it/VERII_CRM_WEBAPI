using Microsoft.EntityFrameworkCore;
using depoWebAPI.Models;

namespace cms_webapi.Data
{
    /// <summary>
    /// ERP veritabanı bağlantısı için DbContext
    /// SQL View'lar ve Function'lar için kullanılır
    /// </summary>
    public class ErpCmsDbContext : DbContext
    {
        public ErpCmsDbContext(DbContextOptions<ErpCmsDbContext> options) : base(options)
        {
        }

        // ERP DbSet'leri
        public DbSet<RII_FN_ONHANDQUANTITY> RII_FN_ONHANDQUANTITY { get; set; }
        public DbSet<RII_VW_CARI> RII_VW_CARI { get; set; }
        public DbSet<RII_VW_DEPO> RII_VW_DEPO { get; set; }
        public DbSet<RII_VW_PROJE> RII_VW_PROJE { get; set; }
        public DbSet<RII_VW_STOK> RII_VW_STOK { get; set; }
        public DbSet<RII_FN_GetProductPricing> RII_FN_GetProductPricing { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Function yapılandırması - Key yok
            modelBuilder.Entity<RII_FN_ONHANDQUANTITY>(entity =>
            {
                entity.HasNoKey();
                entity.ToView("RII_FN_ONHANDQUANTITY");
            });

            // Cari view yapılandırması - Key yok
            modelBuilder.Entity<RII_VW_CARI>(entity =>
            {
                entity.HasNoKey();
                entity.ToView("RII_VW_CARI");
                entity.Property(e => e.CARI_KOD).HasMaxLength(25);
                entity.Property(e => e.CARI_ISIM).HasMaxLength(100);
                entity.Property(e => e.CARI_TEL).HasMaxLength(20);
                entity.Property(e => e.CARI_IL).HasMaxLength(50);
                entity.Property(e => e.CARI_ADRES).HasMaxLength(500);
            });

            // Depo view yapılandırması - Key yok
            modelBuilder.Entity<RII_VW_DEPO>(entity =>
            {
                entity.HasNoKey();
                entity.ToView("RII_VW_DEPO");
                entity.Property(e => e.DEPO_ISMI).HasMaxLength(100);
                entity.Property(e => e.CARI_KODU).HasMaxLength(25);
            });

            // Proje view yapılandırması - Key yok
            modelBuilder.Entity<RII_VW_PROJE>(entity =>
            {
                entity.HasNoKey();
                entity.ToView("RII_VW_PROJE");
                entity.Property(e => e.ProjeKod).HasMaxLength(15).HasColumnName("PROJE_KODU");
                entity.Property(e => e.ProjeAciklama).HasMaxLength(50).HasColumnName("PROJE_ACIKLAMA");
            });

            // Stok view yapılandırması - Key yok
            modelBuilder.Entity<RII_VW_STOK>(entity =>
            {
                entity.HasNoKey();
                entity.ToView("RII_VW_STOK");
                entity.Property(e => e.STOK_KODU).HasMaxLength(25);
                entity.Property(e => e.STOK_ADI).HasMaxLength(50);
                entity.Property(e => e.GRUP_KODU).HasMaxLength(10);
                entity.Property(e => e.URETICI_KODU).HasMaxLength(25);
            });

            modelBuilder.Entity<RII_FN_GetProductPricing>(entity =>
            {
                entity.HasNoKey();
                entity.Property(e => e.STOK_KODU).HasMaxLength(35);
                entity.Property(e => e.STOK_ADI).HasMaxLength(200);
                entity.Property(e => e.Currency).HasMaxLength(100);
            });
        }
    }
}
