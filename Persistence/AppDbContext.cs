using Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Agama> Agama { get; set; }
        public DbSet<Bahasa> Bahasa { get; set; }
        public DbSet<Gender> Gender { get; set; }
        public DbSet<Golongan> Golongan { get; set; }
        public DbSet<Jabatan> Jabatan { get; set; }
        public DbSet<Location> Location { get; set; }
        public DbSet<LocationType> LocationType { get; set; }
        public DbSet<Negara> Negara { get; set; }
        public DbSet<Org> Org { get; set; }
        public DbSet<OrgType> OrgType { get; set; }
        public DbSet<Pegawai> Pegawai { get; set; }
        public DbSet<Pendidikan> Pendidikan { get; set; }
        public DbSet<Pendidikan1> Pendidikan1 { get; set; }
        public DbSet<Pendidikan2> Pendidikan2 { get; set; }
        public DbSet<Pendidikan3> Pendidikan3 { get; set; }
        public DbSet<Perkawinan> Perkawinan { get; set; }
        public DbSet<Suku> Suku { get; set; }
        public DbSet<Zone> Zone { get; set; }

        public DbSet<Provinsi> Provinsi { get; set; }
        public DbSet<KabKota> KabKota { get; set; }
        public DbSet<Kecamatan> Kecamatan { get; set; }
        public DbSet<Desa> Desa { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // builder.Entity<Org>( a => a.HasKey( aa => new { aa.OrgTypeID}));

            builder.Entity<Org>()
            .HasOne(u => u.OrgType)
            .WithMany(u => u.Org)
            .HasForeignKey(u => u.OrgTypeID);

            builder.Entity<Location>()
            .HasOne(u => u.LocationType)
            .WithMany(u => u.Location)
            .HasForeignKey(u => u.LocationTypeId);

            builder.Entity<Location>()
            .HasOne(u => u.Zone)
            .WithMany(u => u.Location)
            .HasForeignKey(u => u.ZoneId);

            builder.Entity<Pendidikan3>()
            .HasOne(u => u.Pendidikan3Ke2)
            .WithMany(u => u.Pendidikan2Ke3)
            .HasForeignKey(u => u.ParentId);

            builder.Entity<Pendidikan2>()
            .HasOne(u => u.Pendidikan2Ke1)
            .WithMany(u => u.Pendidikan1Ke2)
            .HasForeignKey(u => u.ParentId);

            builder.Entity<Pegawai>()
            .HasOne(u => u.PegawaiAgama)
            .WithMany(u => u.AgamaPegawai)
            .HasForeignKey(u => u.AgamaId);

            builder.Entity<Pegawai>()
            .HasOne(u => u.PegawaiBahasa)
            .WithMany(u => u.BahasaPegawai)
            .HasForeignKey(u => u.BahasaId);

            builder.Entity<Pegawai>()
            .HasOne(u => u.PegawaiGender)
            .WithMany(u => u.GenderPegawai)
            .HasForeignKey(u => u.GenderId);

            builder.Entity<Pegawai>()
            .HasOne(u => u.PegawaiGolongan)
            .WithMany(u => u.GolonganPegawai)
            .HasForeignKey(u => u.GolonganId);

            builder.Entity<Pegawai>()
            .HasOne(u => u.PegawaiJabatan)
            .WithMany(u => u.JabatanPegawai)
            .HasForeignKey(u => u.JabatanId);

            builder.Entity<Pegawai>()
            .HasOne(u => u.PegawaiNegara)
            .WithMany(u => u.NegaraPegawai)
            .HasForeignKey(u => u.NegaraId);

            builder.Entity<Pegawai>()
            .HasOne(u => u.PegawaiPendidikan)
            .WithMany(u => u.PendidikanPegawai)
            .HasForeignKey(u => u.PendidikanId);

            builder.Entity<Pegawai>()
            .HasOne(u => u.PegawaiPendidikan3)
            .WithMany(u => u.Pendidikan3Pegawai)
            .HasForeignKey(u => u.Pendidikan3Id);

            builder.Entity<Pegawai>()
            .HasOne(u => u.PegawaiSuku)
            .WithMany(u => u.SukuPegawai)
            .HasForeignKey(u => u.SukuId);

            builder.Entity<KabKota>()
            .HasOne(u => u.PKabKotaToProvinsi)
            .WithMany( u => u.CProvinsiToKabKota)
            .HasForeignKey(u => u.ParentId);

            builder.Entity<Kecamatan>()
            .HasOne(u => u.PKecamatanToKabKota)
            .WithMany( u => u.CKabKotaToKecamatan)
            .HasForeignKey(u => u.ParentId);

            builder.Entity<Desa>()
            .HasOne(u => u.PDesaToKecamatan)
            .WithMany( u => u.CKecamatanToDesa)
            .HasForeignKey(u => u.ParentId);
        }
    }
}