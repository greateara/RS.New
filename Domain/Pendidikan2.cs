namespace Domain
{
    public class Pendidikan2
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public int Deleted { get; set; } = 0;
        public string Uraian { get; set; } ="";

        //AS FK
        public Guid ParentId { get; set; } = Guid.Empty;
        public virtual Pendidikan1 Pendidikan2Ke1 { get; set; }
        //AS PK
        public ICollection<Pendidikan3> Pendidikan2Ke3 {get;set;}
    }
}