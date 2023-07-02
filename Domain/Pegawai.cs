using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Pegawai
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public int Deleted { get; set; } = 0;
        [MaxLength(255)] public string NIP { get; set; } = "";
        [MaxLength(255)] public string Nama { get; set; } = "";
        [MaxLength(255)] public string TmpLahir { get; set; } = "";
        [DataType(DataType.Date)] public DateTime TglLahir { get; set; }
        public string Alamat { get; set; } = "";
        
        [MaxLength(50)] public string Tlp { get; set; } = "";
        [DataType(DataType.Date)] public DateTime TlgMasuk { get; set; }
        public string PictFile { get; set; } = "";
        public int IsFakasi { get; set; } = 0;


        //TO SELF
        public Guid LeaderId { get; set; } = Guid.Empty;

        //AS PRIMARY KEY


        //AS FOREIG KEY
        public Guid AgamaId { get; set; }
        public virtual Agama PegawaiAgama { get; set; }
        public Guid BahasaId { get; set; }
        public virtual Bahasa PegawaiBahasa { get; set; }
        public Guid GenderId { get; set; }
        public virtual Gender PegawaiGender { get; set; }
        public Guid GolonganId { get; set; }
        public virtual Golongan PegawaiGolongan { get; set; }
        public Guid JabatanId { get; set; }
        public virtual Jabatan PegawaiJabatan { get; set; }
        public Guid NegaraId { get; set; }
        public virtual Negara PegawaiNegara { get; set; }
        public Guid PendidikanId { get; set; }
        public virtual Pendidikan PegawaiPendidikan { get; set; }
        public Guid Pendidikan3Id { get; set; }
        public virtual Pendidikan3 PegawaiPendidikan3 { get; set; }
        public Guid PerkawinanId { get; set; }
        public virtual Perkawinan PegawaiPerkawinan { get; set; }
        public Guid SukuId { get; set; }
        public virtual Suku PegawaiSuku { get; set; }
        public Guid ZoneId { get; set; }
        public virtual Zone PegawaiZone { get; set; }

        // public int KodeRuang3 { get; set; }
        // public virtual RRuang3 RRuang3 { get; set; }
        // public int KodePendidikan { get; set; }
        // public virtual RPendidikan RPendidikan { get; set; }


        // [Display(Name = "Image")]
        // [NotMapped]
        // public IFormFile FileImage { get; set; }

        // [Display(Name = "Pdf")]
        // [NotMapped]
        // public IFormFile FilePdf { get; set; }

        // [DefaultValue("")] public string SSCode { get; set; }
        // [DefaultValue("")] public string SSNIK { get; set; }
        // [DefaultValue("")] public string SSNama { get; set; }
        // [DefaultValue("")] public string SSGender { get; set; }
        // public DateTime? SSBirthDate { get; set; }

        // //PK
        // public ICollection<TMutasiDt> LstTMutasiDt { get; set; }
        // public ICollection<TPembelian> LstTPembelian { get; set; }
        // public ICollection<TResepDt> LstTResepDt { get; set; }
        // public ICollection<TReturResepDt> LstTReturResepDt { get; set; }

        // [InverseProperty("TPegawaiNIPTerima")]
        // public ICollection<TMutasi> LstTMutasiNIPTerima { get; set; }

        // [InverseProperty("TPegawaiNIPRequest")]
        // public ICollection<TMutasi> LstTMutasiNIPRequest { get; set; }

        // [InverseProperty("TPegawaiKodeDokter")]
        // public ICollection<TResep> LstTResepKodeDokter { get; set; }
        // [InverseProperty("TPegawaiKodeApoteker")]
        // public ICollection<TResep> LstTResepKodeApoteker { get; set; }

        // [InverseProperty("TPegawaiDokterIGD")]
        // public ICollection<TRegistrasi> LstTRegistrasiDokterIGD { get; set; }

        // [InverseProperty("TPegawaiDPJP")]
        // public ICollection<TRegistrasi> LstTRegistrasiDPJP { get; set; }
        // public ICollection<TReturPembelian> LstTReturPembelian { get; set; }
        // //public ICollection<TReturMutasiDt> LstTReturMutasiDt { get; set; }

        // //[InverseProperty("TPegawaiNIPTerima")]
        // //public ICollection<TReturMutasi> LstTReturMutasiNIPTerima { get; set; }

        // //[InverseProperty("TPegawaiNIPRequest")]
        // //public ICollection<TReturMutasi> LstTReturMutasiNIPRequest { get; set; }

        // [InverseProperty("TPegawaiDokter1")]
        // public ICollection<TTindakan1> LstTindakan1Dokter1 { get; set; }

        // [InverseProperty("TPegawaiDokter2")]
        // public ICollection<TTindakan1> LstTindakan1Dokter2 { get; set; }

        // [InverseProperty("TPegawaiKodeDokter")]
        // public ICollection<TReturResep> LstTReturResepKodeDokter { get; set; }
        // [InverseProperty("TPegawaiKodeApoteker")]
        // public ICollection<TReturResep> LstTReturResepKodeApoteker { get; set; }
        // public ICollection<TTutupStok> LstTTutupStok { get; set; }
        // public ICollection<TLogistikExpired> LstTLogistikExpired { get; set; }
        // public ICollection<TLogistikOperasional> LstTLogistikOperasional { get; set; }

        // [InverseProperty("TPegawaiKonsinyasiTerima")]
        // public ICollection<TKonsinyasi> LstTKonsinyasiTerima { get; set; }
        // [InverseProperty("TPegawaiKonsinyasiRequest")]
        // public ICollection<TKonsinyasi> LstTKonsinyasiRequest { get; set; }

        // public ICollection<TBayarSelisih> LstTBayarSelisih { get; set; }

        // [InverseProperty("TPegawaiKasir")]
        // public ICollection<TDeposit> LstTDepositKasir { get; set; }
        // [InverseProperty("TPegawaiEdit")]
        // public ICollection<TDeposit> LstTDepositKasirEdit { get; set; }
        // [InverseProperty("TPegawaiHapus")]
        // public ICollection<TDeposit> LstTDepositKasirHapus { get; set; }

        // public ICollection<RM04> LstRM04 { get; set; }
        // [InverseProperty("TPegawaiDpjp")]
        // public ICollection<RM05> LstRM05Dpjp { get; set; }
        // [InverseProperty("TPegawaiPetugas")]
        // public ICollection<RM05> LstRM05Petugas { get; set; }
        // public ICollection<RM08> LstRM08 { get; set; }
        // public ICollection<RM09> LstRM09 { get; set; }


        // [InverseProperty("TPegawaiOperator")]
        // public ICollection<RM24> LstRM24Operator { get; set; }
        // [InverseProperty("TPegawaiPemberiInformasi")]
        // public ICollection<RM24> LstRM24PemberiInformasi { get; set; }

        // [InverseProperty("TPegawaiDokterOperator")]
        // public ICollection<RM25> LstRM25DokterOperator { get; set; }
        // [InverseProperty("TPegawaiSaksiRS")]
        // public ICollection<RM25> LstRM25PegawaiSaksiRS { get; set; }

        // [InverseProperty("TPegawaiRuangan")]
        // public ICollection<RM26> LstRM26PegawaiRuangan { get; set; }
        // [InverseProperty("TPegawaiOK")]
        // public ICollection<RM26> LstRM26PegawaiOK { get; set; }
        // [InverseProperty("TPegawaiOK2")]
        // public ICollection<RM26> LstRM26PegawaiOK2 { get; set; }

        // [InverseProperty("TPegawaiDokterOperator")]
        // public ICollection<RM28> LstRM28PegawaiDokterOperator { get; set; }
        // [InverseProperty("TPegawaiInformasi")]
        // public ICollection<RM28> LstRM28PegawaiInformasi { get; set; }

        // [InverseProperty("TPegawaiDokter")]
        // public ICollection<RM29> LstRM29PegawaiDokter { get; set; }
        // [InverseProperty("TPegawaiSaksi")]
        // public ICollection<RM29> LstRM29PegawaiSaksi { get; set; }

        // [InverseProperty("TPegawaiPerawatAnastesi")]
        // public ICollection<RM30> LstRM30PegawaiPerawatAnastesi { get; set; }
        // [InverseProperty("TPegawaiDokterAnastesi")]
        // public ICollection<RM30> LstRM30PegawaiDokterAnastesi { get; set; }

        // [InverseProperty("TPegawaiDokter")]
        // public ICollection<RM31> LstRM31Dokter { get; set; }

        // [InverseProperty("TPegawaiDokter")]
        // public ICollection<RM34> LstRM34Dokter { get; set; }

        // [InverseProperty("TPegawaiPerawat")]
        // public ICollection<RM36> LstRM36PegawaiPerawat { get; set; }
        // [InverseProperty("TPegawaiKepalaRuangan")]
        // public ICollection<RM36> LstRM36PegawaiKepalaRuangan { get; set; }

        // [InverseProperty("TPegawaiPerawatSignIn")]
        // public ICollection<RM37> LstRM37PegawaiPerawatSignIn { get; set; }
        // [InverseProperty("TPegawaiPerawatTimeOut")]
        // public ICollection<RM37> LstRM37PegawaiPerawatTimeOut { get; set; }
        // [InverseProperty("TPegawaiDokterAnastesiSignOut")]
        // public ICollection<RM37> LstRM37PegawaiDokterAnastesiSignOut { get; set; }
        // [InverseProperty("TPegawaiDokterBedahSignOut")]
        // public ICollection<RM37> LstRM37PegawaiDokterBedahSignOut { get; set; }
        // [InverseProperty("TPegawaiPerawatSignOut")]
        // public ICollection<RM37> LstRM37PegawaiPerawatSignOut { get; set; }

        // [InverseProperty("TPegawaiDokter")]
        // public ICollection<RM39> LstRM39PegawaiDokter { get; set; }

        // [InverseProperty("TPegawaiDokterOperator")]
        // public ICollection<RM40> LstRM40PegawaiDokterOperator { get; set; }
        // [InverseProperty("TPegawaiDokterAnastesi")]
        // public ICollection<RM40> LstRM40PegawaiDokterAnastesi { get; set; }
        // [InverseProperty("TPegawaiAsistenOperator")]
        // public ICollection<RM40> LstRM40PegawaiAsistenOperator { get; set; }
        // [InverseProperty("TPegawaiPerawatAnastesi")]
        // public ICollection<RM40> LstRM40PegawaiPerawatAnastesi { get; set; }

        // [InverseProperty("TPegawaiPetugasRuangan")]
        // public ICollection<RM41> LstRM41PegawaiPetugasRuangan { get; set; }
        // [InverseProperty("TPegawaiPetugasOK")]
        // public ICollection<RM41> LstRM41PegawaiPetugasOK { get; set; }

        // [InverseProperty("TPegawaiPerawatPenerima")]
        // public ICollection<RM42> LstRM42PegawaiPerawatPenerima { get; set; }
        // [InverseProperty("TPegawaiPerawatRR")]
        // public ICollection<RM42> LstRM42PegawaiPerawatRR { get; set; }

        // [InverseProperty("TPegawaiDpjp")]
        // public ICollection<RM45> LstRM45PegawaiDpjp { get; set; }
        // [InverseProperty("TPegawaiPerujuk")]
        // public ICollection<RM45> LstRM45PegawaiPerujuk { get; set; }
        // [InverseProperty("TPegawaiStaf1")]
        // public ICollection<RM45> LstRM45PegawaiStaf1 { get; set; }
        // [InverseProperty("TPegawaiStaf2")]
        // public ICollection<RM45> LstRM45PegawaiStaf2 { get; set; }

        // [InverseProperty("TPegawaiDpjp")]
        // public ICollection<RM49> LstRM49PegawaiDpjp { get; set; }

        // [InverseProperty("TPegawaiKepalaRuangan")]
        // public ICollection<RM50> LstRM50PegawaiKepalaRuangan { get; set; }

        // [InverseProperty("TPegawaiPemberiInformasi")]
        // public ICollection<RM53> LstRM53PegawaiPemberiInformasi { get; set; }

        // [InverseProperty("TPegawaiDokter")]
        // public ICollection<RM56> LstRM56PegawaiDokter { get; set; }
        // [InverseProperty("TPegawaiSaksiRS")]
        // public ICollection<RM56> LstRM56PegawaiSaksiRS { get; set; }

        // [InverseProperty("TPegawaiYangMenyerahkan")]
        // public ICollection<RM61> LstRM61PegawaiYangMenyerahkan { get; set; }
        // [InverseProperty("TPegawaiDpjp")]
        // public ICollection<RM61> LstRM61PegawaiDpjp { get; set; }

        // [InverseProperty("TPegawaiDokter")]
        // public ICollection<RM62> LstRM62PegawaiDokter { get; set; }
        // [InverseProperty("TPegawaiSaksiRS")]
        // public ICollection<RM62> LstRM62PegawaiSaksiRS { get; set; }

        // [InverseProperty("TPegawaiPerawat")]
        // public ICollection<RM65> LstRM65PegawaiPerawat { get; set; }
        // [InverseProperty("TPegawaiDpjp")]
        // public ICollection<RM65> LstRM65PegawaiDpjp { get; set; }

        // //bof hansen

        // [InverseProperty("TPegawaiDokter")]
        // public ICollection<RM27> LstRM27TPegawaiDokter { get; set; }

        // [InverseProperty("TPegawaiPerawat")]
        // public ICollection<RM27> LstRM27TPegawaiPerawat { get; set; }
    }
}