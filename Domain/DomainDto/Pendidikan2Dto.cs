namespace DomainDto
{
    public class Pendidikan2Dto
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public int Deleted { get; set; } = 0;
        public string Uraian { get; set; } ="";
        //AS FK
        public Guid ParentId { get; set; } = Guid.Empty;
    }
}