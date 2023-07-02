namespace DomainDto
{
    public class GolonganDto
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public int Kode { get; set; } = 0;
        public int Deleted { get; set; } = 0;
        public string UraianGolongan { get; set; } = "";
        public string UraianPangkat { get; set; } = "";
    }
}