using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class Org
    {
        [Key]
        // [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; } = Guid.NewGuid();
        public int Deleted { get; set; } = 0;
        public DateTime SaveDate { get; set; }
        public Guid SSOrganizationId { get; set; } = Guid.NewGuid();
        public Guid SSClientID { get; set; } = Guid.NewGuid();
        public Guid SSClientSecret { get; set; } = Guid.NewGuid();
        public string OrgName { get; set; } = "";
        public Guid Parent { get; set; } = Guid.NewGuid();

        // to FK OrgType
        public Guid OrgTypeID { get; set; }
        public virtual OrgType OrgType { get; set; }

        // to Location
        public ICollection<Location> Location {get;set;}

    }
}