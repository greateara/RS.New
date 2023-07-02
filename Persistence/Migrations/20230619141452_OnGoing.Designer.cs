﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistence;

#nullable disable

namespace Persistence.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230619141452_OnGoing")]
    partial class OnGoing
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.4");

            modelBuilder.Entity("Domain.Agama", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<int>("Deleted")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Kode")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("TimeStamp")
                        .HasColumnType("TEXT");

                    b.Property<string>("Uraian")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Agama");
                });

            modelBuilder.Entity("Domain.AppUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Bio")
                        .HasColumnType("TEXT");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("DisplayName")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("TEXT");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Domain.Bahasa", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<int>("Deleted")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Kode")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Uraian")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Bahasa");
                });

            modelBuilder.Entity("Domain.Desa", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<int>("Deleted")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Kode")
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("ParentId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("TimeStamp")
                        .HasColumnType("TEXT");

                    b.Property<string>("Uraian")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.ToTable("Desa");
                });

            modelBuilder.Entity("Domain.Gender", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<int>("Deleted")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Kode")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Uraian")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Gender");
                });

            modelBuilder.Entity("Domain.Golongan", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<int>("Deleted")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Kode")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UraianGolongan")
                        .HasColumnType("TEXT");

                    b.Property<string>("UraianPangkat")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Golongan");
                });

            modelBuilder.Entity("Domain.Jabatan", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<int>("Deleted")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Kode")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Uraian")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Jabatan");
                });

            modelBuilder.Entity("Domain.KabKota", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<int>("Deleted")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Kode")
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("ParentId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("TimeStamp")
                        .HasColumnType("TEXT");

                    b.Property<string>("Uraian")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.ToTable("KabKota");
                });

            modelBuilder.Entity("Domain.Kecamatan", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<int>("Deleted")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Kode")
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("ParentId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("TimeStamp")
                        .HasColumnType("TEXT");

                    b.Property<string>("Uraian")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.ToTable("Kecamatan");
                });

            modelBuilder.Entity("Domain.Location", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<int>("Deleted")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("LocationTypeId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Mode")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("OrgId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Status")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ZoneId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("LocationTypeId");

                    b.HasIndex("OrgId");

                    b.HasIndex("ZoneId");

                    b.ToTable("Location");
                });

            modelBuilder.Entity("Domain.LocationType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Code")
                        .HasColumnType("TEXT");

                    b.Property<string>("Definition")
                        .HasColumnType("TEXT");

                    b.Property<string>("Display")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("LocationType");
                });

            modelBuilder.Entity("Domain.Negara", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<int>("Deleted")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Uraian")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Negara");
                });

            modelBuilder.Entity("Domain.Org", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<int>("Deleted")
                        .HasColumnType("INTEGER");

                    b.Property<string>("OrgName")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("OrgTypeID")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("Parent")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("SSClientID")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("SSClientSecret")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("SSOrganizationId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("SaveDate")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("OrgTypeID");

                    b.ToTable("Org");
                });

            modelBuilder.Entity("Domain.OrgType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Code")
                        .HasColumnType("TEXT");

                    b.Property<string>("Definition")
                        .HasColumnType("TEXT");

                    b.Property<int>("Deleted")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Display")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("SaveDate")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("OrgType");
                });

            modelBuilder.Entity("Domain.Pegawai", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("AgamaId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Alamat")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("BahasaId")
                        .HasColumnType("TEXT");

                    b.Property<int>("Deleted")
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("GenderId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("GolonganId")
                        .HasColumnType("TEXT");

                    b.Property<int>("IsFakasi")
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("JabatanId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("LeaderId")
                        .HasColumnType("TEXT");

                    b.Property<string>("NIP")
                        .HasMaxLength(255)
                        .HasColumnType("TEXT");

                    b.Property<string>("Nama")
                        .HasMaxLength(255)
                        .HasColumnType("TEXT");

                    b.Property<Guid>("NegaraId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("Pendidikan3Id")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("PendidikanId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("PerkawinanId")
                        .HasColumnType("TEXT");

                    b.Property<string>("PictFile")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("SukuId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("TglLahir")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("TlgMasuk")
                        .HasColumnType("TEXT");

                    b.Property<string>("Tlp")
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.Property<string>("TmpLahir")
                        .HasMaxLength(255)
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ZoneId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("AgamaId");

                    b.HasIndex("BahasaId");

                    b.HasIndex("GenderId");

                    b.HasIndex("GolonganId");

                    b.HasIndex("JabatanId");

                    b.HasIndex("NegaraId");

                    b.HasIndex("Pendidikan3Id");

                    b.HasIndex("PendidikanId");

                    b.HasIndex("PerkawinanId");

                    b.HasIndex("SukuId");

                    b.HasIndex("ZoneId");

                    b.ToTable("Pegawai");
                });

            modelBuilder.Entity("Domain.Pendidikan", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<int>("Deleted")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Uraian")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Pendidikan");
                });

            modelBuilder.Entity("Domain.Pendidikan1", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<int>("Deleted")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Uraian")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Pendidikan1");
                });

            modelBuilder.Entity("Domain.Pendidikan2", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<int>("Deleted")
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("ParentId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Uraian")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.ToTable("Pendidikan2");
                });

            modelBuilder.Entity("Domain.Pendidikan3", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<int>("Deleted")
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("ParentId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Uraian")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.ToTable("Pendidikan3");
                });

            modelBuilder.Entity("Domain.Perkawinan", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<int>("Deleted")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Uraian")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Perkawinan");
                });

            modelBuilder.Entity("Domain.Provinsi", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<int>("Deleted")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Kode")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("TimeStamp")
                        .HasColumnType("TEXT");

                    b.Property<string>("Uraian")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Provinsi");
                });

            modelBuilder.Entity("Domain.Suku", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<int>("Deleted")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Uraian")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Suku");
                });

            modelBuilder.Entity("Domain.Zone", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<int>("CityId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Definition")
                        .HasColumnType("TEXT");

                    b.Property<int>("DistrictId")
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("IdCity")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("IdDistrict")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("IdVillage")
                        .HasColumnType("TEXT");

                    b.Property<int>("ProvinceId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("VillageId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Zone");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Value")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Domain.Desa", b =>
                {
                    b.HasOne("Domain.Kecamatan", "PDesaToKecamatan")
                        .WithMany("CKecamatanToDesa")
                        .HasForeignKey("ParentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PDesaToKecamatan");
                });

            modelBuilder.Entity("Domain.KabKota", b =>
                {
                    b.HasOne("Domain.Provinsi", "PKabKotaToProvinsi")
                        .WithMany("CProvinsiToKabKota")
                        .HasForeignKey("ParentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PKabKotaToProvinsi");
                });

            modelBuilder.Entity("Domain.Kecamatan", b =>
                {
                    b.HasOne("Domain.KabKota", "PKecamatanToKabKota")
                        .WithMany("CKabKotaToKecamatan")
                        .HasForeignKey("ParentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PKecamatanToKabKota");
                });

            modelBuilder.Entity("Domain.Location", b =>
                {
                    b.HasOne("Domain.LocationType", "LocationType")
                        .WithMany("Location")
                        .HasForeignKey("LocationTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Org", null)
                        .WithMany("Location")
                        .HasForeignKey("OrgId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Zone", "Zone")
                        .WithMany("Location")
                        .HasForeignKey("ZoneId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LocationType");

                    b.Navigation("Zone");
                });

            modelBuilder.Entity("Domain.Org", b =>
                {
                    b.HasOne("Domain.OrgType", "OrgType")
                        .WithMany("Org")
                        .HasForeignKey("OrgTypeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("OrgType");
                });

            modelBuilder.Entity("Domain.Pegawai", b =>
                {
                    b.HasOne("Domain.Agama", "PegawaiAgama")
                        .WithMany("AgamaPegawai")
                        .HasForeignKey("AgamaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Bahasa", "PegawaiBahasa")
                        .WithMany("BahasaPegawai")
                        .HasForeignKey("BahasaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Gender", "PegawaiGender")
                        .WithMany("GenderPegawai")
                        .HasForeignKey("GenderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Golongan", "PegawaiGolongan")
                        .WithMany("GolonganPegawai")
                        .HasForeignKey("GolonganId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Jabatan", "PegawaiJabatan")
                        .WithMany("JabatanPegawai")
                        .HasForeignKey("JabatanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Negara", "PegawaiNegara")
                        .WithMany("NegaraPegawai")
                        .HasForeignKey("NegaraId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Pendidikan3", "PegawaiPendidikan3")
                        .WithMany("Pendidikan3Pegawai")
                        .HasForeignKey("Pendidikan3Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Pendidikan", "PegawaiPendidikan")
                        .WithMany("PendidikanPegawai")
                        .HasForeignKey("PendidikanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Perkawinan", "PegawaiPerkawinan")
                        .WithMany("PerkawinanPegawai")
                        .HasForeignKey("PerkawinanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Suku", "PegawaiSuku")
                        .WithMany("SukuPegawai")
                        .HasForeignKey("SukuId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Zone", "PegawaiZone")
                        .WithMany()
                        .HasForeignKey("ZoneId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PegawaiAgama");

                    b.Navigation("PegawaiBahasa");

                    b.Navigation("PegawaiGender");

                    b.Navigation("PegawaiGolongan");

                    b.Navigation("PegawaiJabatan");

                    b.Navigation("PegawaiNegara");

                    b.Navigation("PegawaiPendidikan");

                    b.Navigation("PegawaiPendidikan3");

                    b.Navigation("PegawaiPerkawinan");

                    b.Navigation("PegawaiSuku");

                    b.Navigation("PegawaiZone");
                });

            modelBuilder.Entity("Domain.Pendidikan2", b =>
                {
                    b.HasOne("Domain.Pendidikan1", "Pendidikan2Ke1")
                        .WithMany("Pendidikan1Ke2")
                        .HasForeignKey("ParentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pendidikan2Ke1");
                });

            modelBuilder.Entity("Domain.Pendidikan3", b =>
                {
                    b.HasOne("Domain.Pendidikan2", "Pendidikan3Ke2")
                        .WithMany("Pendidikan2Ke3")
                        .HasForeignKey("ParentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pendidikan3Ke2");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Domain.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Domain.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Domain.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Agama", b =>
                {
                    b.Navigation("AgamaPegawai");
                });

            modelBuilder.Entity("Domain.Bahasa", b =>
                {
                    b.Navigation("BahasaPegawai");
                });

            modelBuilder.Entity("Domain.Gender", b =>
                {
                    b.Navigation("GenderPegawai");
                });

            modelBuilder.Entity("Domain.Golongan", b =>
                {
                    b.Navigation("GolonganPegawai");
                });

            modelBuilder.Entity("Domain.Jabatan", b =>
                {
                    b.Navigation("JabatanPegawai");
                });

            modelBuilder.Entity("Domain.KabKota", b =>
                {
                    b.Navigation("CKabKotaToKecamatan");
                });

            modelBuilder.Entity("Domain.Kecamatan", b =>
                {
                    b.Navigation("CKecamatanToDesa");
                });

            modelBuilder.Entity("Domain.LocationType", b =>
                {
                    b.Navigation("Location");
                });

            modelBuilder.Entity("Domain.Negara", b =>
                {
                    b.Navigation("NegaraPegawai");
                });

            modelBuilder.Entity("Domain.Org", b =>
                {
                    b.Navigation("Location");
                });

            modelBuilder.Entity("Domain.OrgType", b =>
                {
                    b.Navigation("Org");
                });

            modelBuilder.Entity("Domain.Pendidikan", b =>
                {
                    b.Navigation("PendidikanPegawai");
                });

            modelBuilder.Entity("Domain.Pendidikan1", b =>
                {
                    b.Navigation("Pendidikan1Ke2");
                });

            modelBuilder.Entity("Domain.Pendidikan2", b =>
                {
                    b.Navigation("Pendidikan2Ke3");
                });

            modelBuilder.Entity("Domain.Pendidikan3", b =>
                {
                    b.Navigation("Pendidikan3Pegawai");
                });

            modelBuilder.Entity("Domain.Perkawinan", b =>
                {
                    b.Navigation("PerkawinanPegawai");
                });

            modelBuilder.Entity("Domain.Provinsi", b =>
                {
                    b.Navigation("CProvinsiToKabKota");
                });

            modelBuilder.Entity("Domain.Suku", b =>
                {
                    b.Navigation("SukuPegawai");
                });

            modelBuilder.Entity("Domain.Zone", b =>
                {
                    b.Navigation("Location");
                });
#pragma warning restore 612, 618
        }
    }
}
