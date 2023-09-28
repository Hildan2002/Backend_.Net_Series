using Microsoft.EntityFrameworkCore;

namespace WebApplication3.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Pasien> Pasien { get; set; }
       
        public DbSet<Dokter> Dokter { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Atur konfigurasi tambahan sesuai kebutuhan Anda di sini,
            // seperti mengatur hubungan dan indeks.

            // Contoh konfigurasi untuk hubungan antara Pasien dan RiwayatPenyakit

            // Contoh konfigurasi untuk hubungan antara Pasien dan Dokter:
            modelBuilder.Entity<Pasien>()
                .HasOne(p => p.Dokter)
                .WithMany()
                .HasForeignKey(p => p.DokterId);
        }
    }
}
