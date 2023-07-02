using Domain;

namespace DomainDto
{
    public class PegawaiDto
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public int Deleted { get; set; }
        public string NIP { get; set; }
        public string Nama { get; set; }
        public string TmpLahir { get; set; }
        public string Alamat { get; set; }
        public Agama PegawaiAgama { get; set; }
        public Bahasa PegawaiBahasa { get; set; }
        public Golongan PegawaiGolongan { get; set; }
        public Jabatan PegawaiJabatan { get; set; }
        public Negara PegawaiNegara { get; set; }
        public Pendidikan PegawaiPendidikan { get; set; }
        public Pendidikan3 PegawaiPendidikan3 { get; set; }
        public Perkawinan PegawaiPerkawinan { get; set; }
        public Gender PegawaiGender { get; set; }
        public Suku PegawaiSuku { get; set; }
        public Zone PegawaiZone { get; set; }
    }
}