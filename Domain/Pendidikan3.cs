namespace Domain
{
    public class Pendidikan3
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public int Deleted { get; set; } = 0;
        public string Uraian { get; set; } ="";
        public Guid ParentId { get; set; } = Guid.Empty;
        public virtual Pendidikan2 Pendidikan3Ke2 {get;set;}
        public ICollection<Pegawai> Pendidikan3Pegawai { get; set; }

    }
}