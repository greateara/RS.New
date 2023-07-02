using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.DomainDto
{
    public class GenderDto
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public int Kode { get; set; }
         public int Deleted { get; set; } = 0;
        public string Uraian { get; set; } = "";
    }
}