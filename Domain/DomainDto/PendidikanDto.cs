namespace DomainDto
{
    public class PendidikanDto
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public int Deleted { get; set; } = 0;
        public string Uraian { get; set; } = "";

    }
}