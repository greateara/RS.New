namespace DomainDto
{
    public class AgamaDto
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public int Kode {get;set;}
        public int Deleted { get; set; } = 0;
        public string Uraian { get; set; } = "";
        public DateTime TimeStamp { get; set; } = DateTime.UtcNow;

    }
}