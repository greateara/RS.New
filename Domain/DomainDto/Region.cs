using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DomainDto
{
    public class ProvinsiDto
    {
        public Guid Id { get; set; }
        public int Kode { get; set; } = 0;
        public int Deleted { get; set; } = 0;
        public string Uraian { get; set; } = "";
        public DateTime TimeStamp { get; set; } = DateTime.UtcNow;
    }

    public class KabKotaDto
    {
        public Guid Id { get; set; }
        public int Kode { get; set; } = 0;
        public int Deleted { get; set; } = 0;
        public string Uraian { get; set; } = "";
        public DateTime TimeStamp { get; set; } = DateTime.UtcNow;
        public Guid ParentId { get; set; }
    }

    public class KecamatanDto
    {
        public Guid Id { get; set; }
        public int Kode { get; set; } = 0;
        public int Deleted { get; set; } = 0;
        public string Uraian { get; set; } = "";
        public DateTime TimeStamp { get; set; } = DateTime.UtcNow;
        public Guid ParentId { get; set; }
    }
    public class DesaDto
    {
        public Guid Id { get; set; }
        public int Kode { get; set; } = 0;
        public int Deleted { get; set; } = 0;
        public string Uraian { get; set; } = "";
        public DateTime TimeStamp { get; set; } = DateTime.UtcNow;
        //AS FK
        public Guid ParentId { get; set; }
    }
}