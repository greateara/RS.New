namespace Domain.DomainDto
{
    public class OrgDto
    {
        public Guid Id { get; set; }
        public int Deleted { get; set; }
        public DateTime SaveDate { get; set; }
        public Guid SSOrganizationId { get; set; }
        public Guid SSClientID { get; set; }
        public Guid SSClientSecret { get; set; }
        public string OrgName { get; set; }
        public Guid Parent { get; set; }
        public OrgTypeDto OrgType { get; set; }
    }
}