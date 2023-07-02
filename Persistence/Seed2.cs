
using AutoMapper;
using Domain;
using Domain.DomainDto;
using DomainDto;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;

namespace Persistence

{

    public class Seed2
    {
        // public static async Task SeedProvinsi(AppDbContext context)
        // {
        //     if (context.Provinsi.Any()) return;
        //     string jsonFilePath = Path.Combine(Directory.GetCurrentDirectory(), "SeedFiles//ZoneSeed.Json");
        //     string jsonData = File.ReadAllText(jsonFilePath);
        //     ZoneDto[] zoneDto = JsonConvert.DeserializeObject<ZoneDto[]>(jsonData);
        //     IMapper mapper = new MapperConfiguration(cfg =>
        //     {
        //         cfg.CreateMap<ZoneDto, Zone>();
        //     }).CreateMapper();

        //     var zones = mapper.Map<Zone[]>(zoneDto);
        //     // var ProvinsiRow = new Provinsi();
        //     foreach (var zone in zones)
        //     {
        //         if (zone.CityId == 0)
        //         {
        //             var ProvinsiRow = new Provinsi
        //             {
        //                 Id = Guid.NewGuid(),
        //                 Kode = zone.ProvinceId,
        //                 Deleted = 0,
        //                 Uraian = zone.Definition,
        //                 TimeStamp = DateTime.UtcNow
        //             };

        //             context.Provinsi.Add(ProvinsiRow);
        //         }
        //     }
        //     await context.SaveChangesAsync();
        //     return;
        // }

        // public static async Task SeedKabKota(AppDbContext context)
        // {
        //     if (context.KabKota.Any()) return;
        //     string jsonFilePath = Path.Combine(Directory.GetCurrentDirectory(), "SeedFiles//ZoneSeed.Json");
        //     string jsonData = File.ReadAllText(jsonFilePath);
        //     ZoneDto[] zoneDto = JsonConvert.DeserializeObject<ZoneDto[]>(jsonData);
        //     IMapper mapper = new MapperConfiguration(cfg =>
        //     {
        //         cfg.CreateMap<ZoneDto, Zone>();
        //     }).CreateMapper();

        //     var zones = mapper.Map<Zone[]>(zoneDto);
        //     // var ProvinsiRow = new Provinsi();
        //     foreach (var zone in zones)
        //     {
        //         if (zone.DistrictId == 0)
        //         {

        //             var parentId = context.Provinsi.FirstOrDefault(c => c.Kode == zone.ProvinceId).Id;
        //             var KabKotaRow = new KabKota
        //             {
        //                 Id = Guid.NewGuid(),
        //                 Kode = zone.ProvinceId,
        //                 Deleted = 0,
        //                 Uraian = zone.Definition,
        //                 TimeStamp = DateTime.UtcNow,
        //                 ParentId = parentId
        //             };

        //             context.KabKota.Add(KabKotaRow);
        //         }
        //     }
        //     await context.SaveChangesAsync();
        //     return;
        // }


        // public static async Task SeedKecamatan(AppDbContext context)
        // {
        //     if (context.KabKota.Any()) return;
        //     string jsonFilePath = Path.Combine(Directory.GetCurrentDirectory(), "SeedFiles//ZoneSeed.Json");
        //     string jsonData = File.ReadAllText(jsonFilePath);
        //     ZoneDto[] zoneDto = JsonConvert.DeserializeObject<ZoneDto[]>(jsonData);
        //     IMapper mapper = new MapperConfiguration(cfg =>
        //     {
        //         cfg.CreateMap<ZoneDto, Zone>();
        //     }).CreateMapper();

        //     var zones = mapper.Map<Zone[]>(zoneDto);
        //     // var ProvinsiRow = new Provinsi();
        //     foreach (var zone in zones)
        //     {
        //         if (zone.DistrictId == 0)
        //         {

        //             var parentId = context.KabKota.FirstOrDefault(c => c.Kode == zone.DistrictId).Id;
        //             var KecamatanRow = new Kecamatan
        //             {
        //                 Id = Guid.NewGuid(),
        //                 Kode = zone.ProvinceId,
        //                 Deleted = 0,
        //                 Uraian = zone.Definition,
        //                 TimeStamp = DateTime.UtcNow,
        //                 ParentId = parentId
        //             };

        //             context.Kecamatan.Add(KecamatanRow);
        //         }
        //     }
        //     await context.SaveChangesAsync();
        //     return;
        // }

        public static async Task SeedRegion(AppDbContext context)
        {
            if (context.Provinsi.Any()) return;
            var zones = context.Zone.OrderBy(c => c.ProvinceId)
            .OrderBy(c => c.CityId).OrderBy(c => c.DistrictId)
            .OrderBy(c => c.VillageId);

            foreach (var zone in zones)
            {
                if (zone.VillageId == 0 && zone.DistrictId == 0 &&
                    zone.CityId == 0 && zone.ProvinceId != 0)
                {
                    var provinsi = new Provinsi
                    {
                        Id = zone.Id,
                        Kode = zone.ProvinceId,
                        Deleted = 0,
                        Uraian = zone.Definition,
                        TimeStamp = DateTime.UtcNow,
                        // ParentId = parentId
                    };
                    context.Provinsi.Add(provinsi);
                }
            }
            await context.SaveChangesAsync();

            foreach (var zone in zones)
            {
                if (zone.VillageId == 0 && zone.DistrictId == 0 &&
                    zone.CityId != 0 && zone.ProvinceId != 0)
                {
                    var parentId = context.Zone.FirstOrDefault(
                        c => c.ProvinceId != zone.ProvinceId &&
                        c.CityId == 0 && c.DistrictId == 0 &&
                        c.VillageId == 0).Id;
                    var kabkota = new KabKota
                    {
                        Id = zone.IdCity,
                        Kode = zone.CityId,
                        Deleted = 0,
                        Uraian = zone.Definition,
                        TimeStamp = DateTime.UtcNow,
                        ParentId = parentId
                    };
                    context.KabKota.Add(kabkota);
                }
            }
            await context.SaveChangesAsync();

            foreach (var zone in zones)
            {
                if (zone.VillageId == 0 && zone.DistrictId != 0 &&
                    zone.CityId != 0 && zone.ProvinceId != 0)
                {
                    var parentId = context.Zone.FirstOrDefault(
                        c => c.ProvinceId != zone.ProvinceId &&
                        c.CityId != 0 && c.DistrictId == 0 &&
                        c.VillageId == 0).IdCity;
                    var kecamatan = new Kecamatan
                    {
                        Id = zone.IdDistrict,
                        Kode = zone.DistrictId,
                        Deleted = 0,
                        Uraian = zone.Definition,
                        TimeStamp = DateTime.UtcNow,
                        ParentId = parentId
                    };
                    context.Kecamatan.Add(kecamatan);
                }
            }
            await context.SaveChangesAsync();

            foreach (var zone in zones)
            {
                if (zone.VillageId != 0 && zone.DistrictId != 0 &&
                    zone.CityId != 0 && zone.ProvinceId != 0)
                {
                    var parentId = context.Zone.FirstOrDefault(
                       c => c.ProvinceId != zone.ProvinceId &&
                       c.CityId != 0 && c.DistrictId != 0 &&
                       c.VillageId == 0).IdDistrict;
                    var desa = new Desa
                    {
                        Id = zone.IdVillage,
                        Kode = zone.VillageId,
                        Deleted = 0,
                        Uraian = zone.Definition,
                        TimeStamp = DateTime.UtcNow,
                        ParentId = parentId
                    };
                    context.Desa.Add(desa);
                }
            }
            await context.SaveChangesAsync();

            return;
        }


    }
}