namespace Domain
{
    public class Bahasa
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public int Kode { get; set; }
        public int Deleted { get; set; } = 0;
        public string Uraian { get; set; } = "";
        public ICollection<Pegawai> BahasaPegawai { get; set; }

    }
}