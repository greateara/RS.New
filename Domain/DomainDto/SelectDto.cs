namespace DomainDto
{
    public class SelectDto
    {
        public Guid Id { get; set; }
        public string Uraian { get; set; }
        public SelectDto(Guid id, string uraian)
        {
            Id = id;
            Uraian = uraian;
        }
    }
}