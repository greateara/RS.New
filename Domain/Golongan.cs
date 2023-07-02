namespace Domain
{
    public class Golongan
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public int Kode { get; set; }
        public int Deleted { get; set; } = 0;
        public string UraianGolongan { get; set; } = "";
        public string UraianPangkat { get; set; } = "";

        //AS PK
        public ICollection<Pegawai> GolonganPegawai { get; set; }

    }
}