namespace DomainDto
{
    public class Pendidikan1Dto
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public int Deleted { get; set; } = 0;
        public string Uraian { get; set; } = "";
    }
}