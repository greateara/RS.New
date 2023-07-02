namespace Domain
{
    public class LocationType
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Code { get; set; }
        public string Display { get; set; } 
        public string Definition  { get; set; }
        public ICollection<Location> Location { get; set; } = new List<Location>();

    }

    public class LocationTypeDto
    {
        public string Code { get; set; }
        public string Display { get; set; } 
        public string Definition  { get; set; }
    }
}