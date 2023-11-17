using MainApp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MainApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Akun> DataAkun { get; set; }
        public DbSet<Kas> DataKas { get; set; }
        public DbSet<Kategori> DataKategori { get; set; }
        public DbSet<Periode> DataPeriode { get; set; }
        public DbSet<PeriodeKas> PeriodeKas { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Kategori>().HasIndex(x => x.Kode).IsUnique();
            builder.Entity<Akun>().HasIndex(x => x.Kode).IsUnique();
            builder.Entity<Periode>().HasIndex(x => x.Tahun).IsUnique();
            base.OnModelCreating(builder);
        }
    }
}
