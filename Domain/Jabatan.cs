namespace Domain
{
    public class Jabatan
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public int Kode { get; set; } = 0;
        public int Deleted { get; set; } = 0;
        public string Uraian { get; set; } = "";

        //AS PK
        public ICollection<Pegawai> JabatanPegawai{ get; set; }
    }
}