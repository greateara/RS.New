namespace DomainDto
{
    public class ZoneDto
    {
         public int ProvinceId { get; set; }
        public int CityId { get; set; }
        public int DistrictId { get; set; }
        public int VillageId { get; set; }
        public string Definition { get; set; } = string.Empty;
    }
}