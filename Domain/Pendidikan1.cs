namespace Domain
{
    public class Pendidikan1
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public int Deleted { get; set; } = 0;
        public string Uraian { get; set; } = "";

        //AS FK
        public ICollection<Pendidikan2> Pendidikan1Ke2 { get; set; }
    }
}