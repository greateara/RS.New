namespace Domain
{
    public class Location
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public int Deleted { get; set; } = 0;
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public string Status { get; set; } = "active";
        public string Mode { get; set; } = "instance";
        public Guid OrgId { get; set; }

        //TO LocationType
        public Guid LocationTypeId { get; set; }
        public virtual LocationType LocationType { get; set; }

        //To Zone
        public Guid ZoneId { get; set; }
        public virtual Zone Zone { get; set; }
    }
}