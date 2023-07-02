namespace Domain
{
    public class Pendidikan
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public int Deleted { get; set; } = 0;
        public string Uraian { get; set; } = "";
        public ICollection<Pegawai> PendidikanPegawai { get; set; }

    }
}