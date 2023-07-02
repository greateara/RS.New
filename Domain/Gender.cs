namespace Domain
{
    public class Gender
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public int Kode { get; set; }
         public int Deleted { get; set; } = 0;
        public string Uraian { get; set; } = "";
        
        //AS PK
        public ICollection<Pegawai> GenderPegawai{get;set;}
    }
}