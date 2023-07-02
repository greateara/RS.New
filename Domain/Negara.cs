namespace Domain
{
    public class Negara
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public int Deleted { get; set; } = 0;
        public string Uraian { get; set; } = "";

        //AS PK
        public ICollection<Pegawai> NegaraPegawai { get; set; }
    }
}