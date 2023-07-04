using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain
{
    public class Provinsi
    {
        public Guid Id { get; set; } 
        public int Kode { get; set; } = 0;
        public int Deleted { get; set; } = 0;
        public string Uraian { get; set; } = "";
        public DateTime TimeStamp { get; set; } = DateTime.UtcNow;
        public ICollection<KabKota> CProvinsiToKabKota { get; set; }
    }

    public class KabKota
    {
        public Guid Id { get; set; }
        public int Kode { get; set; } = 0;
        public int Deleted { get; set; } = 0;
        public string Uraian { get; set; } = "";
        public DateTime TimeStamp { get; set; } = DateTime.UtcNow;
        public Guid ParentId { get; set; }
        public virtual Provinsi PKabKotaToProvinsi { get; set; }
        public ICollection<Kecamatan> CKabKotaToKecamatan { get; set; }
    }

    public class Kecamatan
    {
        public Guid Id { get; set; }
        public int Kode { get; set; } = 0;
        public int Deleted { get; set; } = 0;
        public string Uraian { get; set; } = "";
        public DateTime TimeStamp { get; set; } = DateTime.UtcNow;
        public Guid ParentId { get; set; }
        public virtual KabKota PKecamatanToKabKota { get; set; }
        public ICollection<Desa> CKecamatanToDesa { get; set; }
    }
    public class Desa
    {
        public Guid Id { get; set; }
        public int Kode { get; set; } = 0;
        public int Deleted { get; set; } = 0;
        public string Uraian { get; set; } = "";
        public DateTime TimeStamp { get; set; } = DateTime.UtcNow;
        //AS FK
        public Guid ParentId { get; set; }
        public virtual Kecamatan PDesaToKecamatan { get; set; }
    }
}