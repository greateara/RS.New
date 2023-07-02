
using AutoMapper;
using Domain;
using Domain.DomainDto;
using DomainDto;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;

namespace Persistence

{

    public class Seed
    {
        // private readonly AppDbContext _context;
        // private readonly IMapper _mapper;

        // public Seed(AppDbContext context, IMapper mapper)
        // {
        //     _mapper = mapper;
        //     _context = context;
        // }

        // public static async Task SeedAll()
        // {
        //     var seed = new Seed(_context, _mapper);
        //     await seed.SeedData(userManager);
        //     await SeedOrgType();
        //     await SeedZone();
        //     return;
        // }
        public static async Task SeedData(UserManager<AppUser> userManager,
        AppDbContext context)
        {
            if (!userManager.Users.Any())
            {
                var users = new List<AppUser>
                    {
                        new AppUser{DisplayName = "Satu",  UserName="NamaSatu", Email ="satu@satu.com"},
                        new AppUser{DisplayName = "Dua",  UserName="NamaDua", Email ="dua@dua.com"},
                        new AppUser{DisplayName = "Tiga", UserName="NamaTiga", Email ="tiga@tiga.com"}
                    };
                foreach (var user in users)
                {
                    await userManager.CreateAsync(user, "Pa$$w0d");
                }
            }

            if (context.OrgType.Any()) return;
            var lstROrgType = new List<OrgType>
            {
                new OrgType
                {
                    // Id = 1,
                    Deleted = 0,
                    SaveDate = DateTime.UtcNow,
                    Code = "prov",
                    Display = "Healthcare Provider",
                    Definition = "An organization that provides healthcare services."
                },
                new OrgType
                {
                    // Id = 2,
                    Deleted = 0,
                    SaveDate = DateTime.UtcNow,
                    Code = "dept",
                    Display = "Hospital Department",
                    Definition = "A department or ward within a hospital (Generally is not applicable to top level organizations)"

                }
            };
            await context.OrgType.AddRangeAsync(lstROrgType);
            await context.SaveChangesAsync();

            return;
        }
        public static async Task SeedAgama(AppDbContext context)
        {

            if (context.Agama.Any()) return;
            string jsonFilePath = Path.Combine(Directory.GetCurrentDirectory(),
                "SeedFiles//AgamaSeed.Json");
            string jsonData = File.ReadAllText(jsonFilePath);
            AgamaDto[] agamaDto = JsonConvert.DeserializeObject<AgamaDto[]>(jsonData);
            IMapper mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<AgamaDto, Agama>();
            }).CreateMapper();

            var agamas = mapper.Map<Agama[]>(agamaDto);
            foreach (var agama in agamas)
            {
                context.Agama.Add(agama);
                // await context.SaveChangesAsync();
            }
            await context.SaveChangesAsync();
            return;
        }
        public static async Task SeedBahasa(AppDbContext context)
        {


            if (context.Bahasa.Any()) return;
            string jsonFilePath = Path.Combine(Directory.GetCurrentDirectory(),
                "SeedFiles//BahasaSeed.Json");
            string jsonData = File.ReadAllText(jsonFilePath);
            BahasaDto[] bahasaDto = JsonConvert.DeserializeObject<BahasaDto[]>(jsonData);
            IMapper mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<BahasaDto, Bahasa>();
            }).CreateMapper();

            var bahasas = mapper.Map<Bahasa[]>(bahasaDto);
            foreach (var bahasa in bahasas)
            {
                context.Bahasa.Add(bahasa);
            }
            await context.SaveChangesAsync();
            return;
        }
        public static async Task SeedGender(AppDbContext context)
        {
            if (!context.Gender.Any())
            {
                var lst = new List<Gender>
                    {
                        new Gender{Uraian="Laki-laki"},
                        new Gender{Uraian="Perempuan"},
                        new Gender{Uraian="Tidak diketahui"},
                        new Gender{Uraian="---"}
                    };
                foreach (var row in lst)
                {
                    context.Gender.Add(row);
                }
            }
            await context.SaveChangesAsync();
            return;
        }
        public static async Task SeedGolongan(AppDbContext context)
        {


            if (context.Golongan.Any()) return;
            string jsonFilePath = Path.Combine(Directory.GetCurrentDirectory(),
                "SeedFiles//GolonganSeed.Json");
            string jsonData = File.ReadAllText(jsonFilePath);
            GolonganDto[] golonganDto = JsonConvert.DeserializeObject<GolonganDto[]>(jsonData);
            IMapper mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<GolonganDto, Golongan>()
                .ForMember(dest => dest.UraianGolongan,
                    opt => opt.MapFrom(src => src.UraianGolongan))
                .ForMember(dest => dest.UraianPangkat,
                    opt => opt.MapFrom(src => src.UraianPangkat))
                ;
            }).CreateMapper();

            var golongans = mapper.Map<Golongan[]>(golonganDto);
            foreach (var golongan in golongans)
            {
                context.Golongan.Add(golongan);
            }
            await context.SaveChangesAsync();
            return;
        }
        public static async Task SeedJabatan(AppDbContext context)
        {
            if (!context.Jabatan.Any())
            {
                var lst = new List<Jabatan>
                    {
                        new Jabatan{Uraian="Direktur RS"},
                        new Jabatan{Uraian="Kepala Dept. Rawat Jalan"},
                        new Jabatan{Uraian="Kepala Dept. Rawat Inap"},
                        new Jabatan{Uraian="Kepala Dept. IGD"},
                        new Jabatan{Uraian="Kepala Dept. Poli"},
                        new Jabatan{Uraian="Kepala Dept. Administrasi"},
                        new Jabatan{Uraian="---"}
                    };
                foreach (var row in lst)
                {
                    context.Jabatan.Add(row);
                }
            }
            await context.SaveChangesAsync();
            return;
        }
        public static async Task SeedLocationType(AppDbContext context)
        {


            if (context.LocationType.Any()) return;
            string jsonFilePath = Path.Combine(Directory.GetCurrentDirectory(), "SeedFiles//LocationTypeSeed.Json");
            string jsonData = File.ReadAllText(jsonFilePath);
            LocationTypeDto[] locationTypeDto = JsonConvert.DeserializeObject<LocationTypeDto[]>(jsonData);
            IMapper mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<LocationTypeDto, LocationType>();
            }).CreateMapper();

            var locationTypes = mapper.Map<LocationType[]>(locationTypeDto);
            foreach (var locationType in locationTypes)
            {
                context.LocationType.Add(locationType);
            }
            await context.SaveChangesAsync();
            return;
        }
        public static async Task SeedZone(AppDbContext context)
        {
            if (context.Zone.Any()) return;
            string jsonFilePath = Path.Combine(Directory.GetCurrentDirectory(), "SeedFiles//ZoneSeed.Json");
            string jsonData = File.ReadAllText(jsonFilePath);
            ZoneDto[] zoneDto = JsonConvert.DeserializeObject<ZoneDto[]>(jsonData);
            IMapper mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ZoneDto, Zone>();
            }).CreateMapper();

            var zones = mapper.Map<Zone[]>(zoneDto);
            foreach (var zone in zones)
            {
                context.Zone.Add(zone);
            }
            await context.SaveChangesAsync();
            return;
        }
        public static async Task SeedOrgType(AppDbContext context)
        {
            if (context.OrgType.Any()) return;
            var orgTypeString = "";
            var rootObject = JsonConvert.DeserializeObject<RootObject>(orgTypeString);
            var listOrgType = new List<OrgType>();
            foreach (var item in rootObject.concept)
            {
                var orgType = new OrgType
                {
                    Id = Guid.NewGuid(),
                    Code = item.Code,
                    Display = item.Display,
                    Definition = item.Definition,
                    Deleted = 0
                };
                listOrgType.Add(orgType);
            }
            await context.OrgType.AddRangeAsync(listOrgType);
            await context.SaveChangesAsync();
            return;
        }
        public static async Task SeedOrg(AppDbContext context)
        {
            if (!context.Org.Any())
            {
                var lst = new List<Org>();
                Org org = new Org
                {
                    OrgName = "Dept. Rawat Jalan",
                    OrgTypeID = context.OrgType.FirstOrDefault().Id
                }; lst.Add(org);
                org = new Org
                {
                    OrgName = "Dept. Rawat Inap",
                    OrgTypeID = context.OrgType.FirstOrDefault().Id
                }; lst.Add(org);
                org = new Org
                {
                    OrgName = "Dept. Farmasi",
                    OrgTypeID = context.OrgType.FirstOrDefault().Id
                }; lst.Add(org);
                org = new Org
                {
                    OrgName = "Dept. Laboratoriun",
                    OrgTypeID = context.OrgType.FirstOrDefault().Id
                }; lst.Add(org);
                await context.Org.AddRangeAsync(lst);
            }
            await context.SaveChangesAsync();
            return;
        }
        public static async Task SeedLocation(AppDbContext context)
        {
            if (!context.Location.Any())
            {
                var lst = new List<Location>();
                Location location = new Location
                {
                    Name = "IGD",
                    Description = "Ruangan IGD",
                    OrgId = context.Org.FirstOrDefault().Id,
                    LocationTypeId = context.LocationType.FirstOrDefault().Id,
                    ZoneId = context.Zone.FirstOrDefault().Id
                }; lst.Add(location);
                location = new Location
                {
                    Name = "RI-01",
                    Description = "Rawat Inap 1",
                    OrgId = context.Org.FirstOrDefault().Id,
                    LocationTypeId = context.LocationType.FirstOrDefault().Id,
                    ZoneId = context.Zone.FirstOrDefault().Id
                }; lst.Add(location);
                location = new Location
                {
                    Name = "RI-02",
                    Description = "Rawat Inap 2",
                    OrgId = context.Org.FirstOrDefault().Id,
                    LocationTypeId = context.LocationType.FirstOrDefault().Id,
                    ZoneId = context.Zone.FirstOrDefault().Id
                }; lst.Add(location);
                location = new Location
                {
                    Name = "RI-03",
                    Description = "Rawat Inap 3",
                    OrgId = context.Org.FirstOrDefault().Id,
                    LocationTypeId = context.LocationType.FirstOrDefault().Id,
                    ZoneId = context.Zone.FirstOrDefault().Id
                }; lst.Add(location);
                location = new Location
                {
                    Name = "RI-04",
                    Description = "Rawat Inap 4",
                    OrgId = context.Org.FirstOrDefault().Id,
                    LocationTypeId = context.LocationType.FirstOrDefault().Id,
                    ZoneId = context.Zone.FirstOrDefault().Id
                }; lst.Add(location);
                await context.Location.AddRangeAsync(lst);
            }
            await context.SaveChangesAsync();
            return;
        }
        public static async Task SeedNegara(AppDbContext context)
        {
            if (!context.Negara.Any())
            {
                var lst = new List<Negara>
                    {
                        new Negara{Uraian="Indonesia"},
                        new Negara{Uraian="United States"},
                        new Negara{Uraian="Singapore"},
                        new Negara{Uraian="---"}
                    };
                foreach (var row in lst)
                {
                    context.Negara.Add(row);
                }
            }
            await context.SaveChangesAsync();
            return;
        }
        public static async Task SeedPendidikan(AppDbContext context)
        {

            if (context.Pendidikan.Any()) return;
            string jsonFilePath = Path.Combine(Directory.GetCurrentDirectory(),
                "SeedFiles//PendidikanSeed.Json");
            string jsonData = File.ReadAllText(jsonFilePath);
            PendidikanDto[] pendidikanDto = JsonConvert.DeserializeObject<PendidikanDto[]>(jsonData);
            IMapper mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<PendidikanDto, Pendidikan>();
            }).CreateMapper();

            var pendidikans = mapper.Map<Pendidikan[]>(pendidikanDto);
            foreach (var pendidikan in pendidikans)
            {
                context.Pendidikan.Add(pendidikan);
            }
            await context.SaveChangesAsync();
            return;
        }
        public static async Task SeedPendidikan1(AppDbContext context)
        {

            if (context.Pendidikan1.Any()) return;
            string jsonFilePath = Path.Combine(Directory.GetCurrentDirectory(),
                "SeedFiles//Pendidikan1Seed.Json");
            string jsonData = File.ReadAllText(jsonFilePath);
            Pendidikan1Dto[] pendidikan1Dto = JsonConvert.DeserializeObject<Pendidikan1Dto[]>(jsonData);
            IMapper mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Pendidikan1Dto, Pendidikan1>();
            }).CreateMapper();

            var pendidikan1s = mapper.Map<Pendidikan1[]>(pendidikan1Dto);
            foreach (var pendidikan1 in pendidikan1s)
            {
                context.Pendidikan1.Add(pendidikan1);
            }
            await context.SaveChangesAsync();
            return;
        }
        public static async Task SeedPendidikan2(AppDbContext context)
        {
            if (context.Pendidikan2.Any()) return;
            string jsonFilePath = Path.Combine(Directory.GetCurrentDirectory(),
                "SeedFiles//Pendidikan2Seed.Json");
            string jsonData = File.ReadAllText(jsonFilePath);
            Pendidikan2Dto[] pendidikan2Dto = JsonConvert.DeserializeObject<Pendidikan2Dto[]>(jsonData);
            IMapper mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Pendidikan2Dto, Pendidikan2>();
            }).CreateMapper();

            var nPendidikan1 = context.Pendidikan1.Count();
            Random rnd = new Random();
            var pendidikan2s = mapper.Map<Pendidikan2[]>(pendidikan2Dto);
            foreach (var pendidikan2 in pendidikan2s)
            {
                pendidikan2.ParentId = context.Pendidikan1
                    .Skip(rnd.Next(1, nPendidikan1))
                    .FirstOrDefault().Id;
                context.Pendidikan2.Add(pendidikan2);
            }
            await context.SaveChangesAsync();
            return;
        }
        public static async Task SeedPendidikan3(AppDbContext context)
        {

            if (context.Pendidikan3.Any()) return;
            string jsonFilePath = Path.Combine(Directory.GetCurrentDirectory(),
                "SeedFiles//Pendidikan3Seed.Json");
            string jsonData = File.ReadAllText(jsonFilePath);
            Pendidikan3Dto[] pendidikan3Dto = JsonConvert.DeserializeObject<Pendidikan3Dto[]>(jsonData);
            IMapper mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Pendidikan3Dto, Pendidikan3>();
            }).CreateMapper();
            var nPendidikan2 = context.Pendidikan2.Count();
            Random rnd = new Random();
            var pendidikan3s = mapper.Map<Pendidikan3[]>(pendidikan3Dto);
            foreach (var pendidikan3 in pendidikan3s)
            {
                pendidikan3.ParentId = context.Pendidikan2
                    .Skip(rnd.Next(1, nPendidikan2))
                    .FirstOrDefault().Id;
                context.Pendidikan3.Add(pendidikan3);
            }
            await context.SaveChangesAsync();
            return;
        }
        public static async Task SeedPerkawinan(AppDbContext context)
        {
            if (!context.Perkawinan.Any())
            {
                var lst = new List<Perkawinan>
                    {
                        new Perkawinan{Uraian="Kawin"},
                        new Perkawinan{Uraian="Tidak Kawin"},
                        new Perkawinan{Uraian="UnKnown"},
                        new Perkawinan{Uraian="---"}
                    };
                foreach (var row in lst)
                {
                    context.Perkawinan.Add(row);
                }
            }
            await context.SaveChangesAsync();
            return;
        }
        public static async Task SeedSuku(AppDbContext context)
        {
            if (!context.Suku.Any())
            {
                var lst = new List<Suku>
                    {
                        new Suku{Uraian="Batak"},
                        new Suku{Uraian="Jawa"},
                        new Suku{Uraian="Sunda"},
                        new Suku{Uraian="Manado"},
                        new Suku{Uraian="Minang"},
                        new Suku{Uraian="Aceh"},
                        new Suku{Uraian="---"}
                    };
                foreach (var row in lst)
                {
                    context.Suku.Add(row);
                }
            }
            await context.SaveChangesAsync();
            return;
        }
        public static async Task SeedPegawai(AppDbContext context)
        {
            if (!context.Pegawai.Any())
            {

                var nAgama = context.Agama.Count();
                var nBahasa = context.Bahasa.Count();
                var nGender = context.Gender.Count();
                var nGolongan = context.Golongan.Count();
                var nNegara = context.Negara.Count();
                var nJabatan = context.Jabatan.Count();
                var nPendidikan = context.Pendidikan.Count();
                var nPendidikan3 = context.Pendidikan3.Count();
                var nPerkawinan = context.Perkawinan.Count();
                var nSuku = context.Suku.Count();
                var nZone = context.Zone.Count();

                Random rnd = new Random();

                var lst = new List<Pegawai>();
                Pegawai pegawai = new Pegawai
                {
                    NIP = "196505081997031001",
                    Nama = "dr. Yushari Banjarnahor",
                    TmpLahir = rnd.Next(1,999)+"Medan",
                    TglLahir = DateTime.UtcNow,
                    Alamat = rnd.Next(1,999)+"JL.TONGKOL NO 8 SIBOLGA KELURAHAN PANCURAN GEROBAK KECAMATAN SIBOLGA KOTA",
                    Tlp = rnd.Next(1,999).ToString()+"223344",
                    TlgMasuk = DateTime.UtcNow,
                    LeaderId = Guid.NewGuid(),
                    AgamaId = context.Agama.Skip(rnd.Next(nAgama - 1)).FirstOrDefault().Id,
                    BahasaId = context.Bahasa.Skip(rnd.Next(nBahasa - 1)).FirstOrDefault().Id,
                    GenderId = context.Gender.Skip(rnd.Next(nGender - 1)).FirstOrDefault().Id,
                    GolonganId = context.Golongan.Skip(rnd.Next(nGolongan - 1)).FirstOrDefault().Id,
                    JabatanId = context.Jabatan.Skip(rnd.Next(nJabatan - 1)).FirstOrDefault().Id,
                    NegaraId = context.Negara.Skip(rnd.Next(nNegara - 1)).FirstOrDefault().Id,
                    PendidikanId = context.Pendidikan.Skip(rnd.Next(nPendidikan - 1)).FirstOrDefault().Id,
                    Pendidikan3Id = context.Pendidikan3.Skip(rnd.Next(nPendidikan3 - 1)).FirstOrDefault().Id,
                    PerkawinanId = context.Perkawinan.Skip(rnd.Next(nPerkawinan - 1)).FirstOrDefault().Id,
                    SukuId = context.Suku.Skip(rnd.Next(nSuku - 1)).FirstOrDefault().Id,
                    ZoneId = context.Zone.Skip(rnd.Next(nZone - 1)).FirstOrDefault().Id
                }; lst.Add(pegawai);
                pegawai = new Pegawai
                {
                    NIP = "196505081997031" + rnd.Next(1,100).ToString(),
                    Nama = "dr. Edward Sihite, Sp.OG",
                    TmpLahir = rnd.Next(1,999)+ "Medan",
                    TglLahir = DateTime.UtcNow.AddDays(rnd.Next(1,999)),
                    Alamat = rnd.Next(1,999)+"JL.TONGKOL NO 8 SIBOLGA KELURAHAN PANCURAN GEROBAK KECAMATAN SIBOLGA KOTA",
                    Tlp = rnd.Next(1,999).ToString()+ "223344",
                    TlgMasuk = DateTime.UtcNow.AddDays(rnd.Next(1,999)),
                    LeaderId = Guid.NewGuid(),
                    AgamaId = context.Agama.Skip(rnd.Next(nAgama - 1)).FirstOrDefault().Id,
                    BahasaId = context.Bahasa.Skip(rnd.Next(nBahasa - 1)).FirstOrDefault().Id,
                    GenderId = context.Gender.Skip(rnd.Next(nGender - 1)).FirstOrDefault().Id,
                    GolonganId = context.Golongan.Skip(rnd.Next(nGolongan - 1)).FirstOrDefault().Id,
                    JabatanId = context.Jabatan.Skip(rnd.Next(nJabatan - 1)).FirstOrDefault().Id,
                    NegaraId = context.Negara.Skip(rnd.Next(nNegara - 1)).FirstOrDefault().Id,
                    PendidikanId = context.Pendidikan.Skip(rnd.Next(nPendidikan - 1)).FirstOrDefault().Id,
                    Pendidikan3Id = context.Pendidikan3.Skip(rnd.Next(nPendidikan3 - 1)).FirstOrDefault().Id,
                    PerkawinanId = context.Perkawinan.Skip(rnd.Next(nPerkawinan - 1)).FirstOrDefault().Id,
                    SukuId = context.Suku.Skip(rnd.Next(nSuku - 1)).FirstOrDefault().Id,
                    ZoneId = context.Zone.Skip(rnd.Next(nZone - 1)).FirstOrDefault().Id
                }; lst.Add(pegawai);
                pegawai = new Pegawai
                {
                    NIP = "196505081997031" + rnd.Next(1,100).ToString(),
                    Nama = "dr. Rama Vivera Situmorang, Sp.P",
                    TmpLahir = rnd.Next(1,999)+ "Medan",
                    TglLahir = DateTime.UtcNow.AddDays(rnd.Next(1,999)),
                    Alamat = rnd.Next(1,999)+"JL.TONGKOL NO 8 SIBOLGA KELURAHAN PANCURAN GEROBAK KECAMATAN SIBOLGA KOTA",
                    Tlp = rnd.Next(1,999).ToString()+ "223344",
                    TlgMasuk = DateTime.UtcNow.AddDays(rnd.Next(1,999)),
                    LeaderId = Guid.NewGuid(),
                    AgamaId = context.Agama.Skip(rnd.Next(nAgama - 1)).FirstOrDefault().Id,
                    BahasaId = context.Bahasa.Skip(rnd.Next(nBahasa - 1)).FirstOrDefault().Id,
                    GenderId = context.Gender.Skip(rnd.Next(nGender - 1)).FirstOrDefault().Id,
                    GolonganId = context.Golongan.Skip(rnd.Next(nGolongan - 1)).FirstOrDefault().Id,
                    JabatanId = context.Jabatan.Skip(rnd.Next(nJabatan - 1)).FirstOrDefault().Id,
                    NegaraId = context.Negara.Skip(rnd.Next(nNegara - 1)).FirstOrDefault().Id,
                    PendidikanId = context.Pendidikan.Skip(rnd.Next(nPendidikan - 1)).FirstOrDefault().Id,
                    Pendidikan3Id = context.Pendidikan3.Skip(rnd.Next(nPendidikan3 - 1)).FirstOrDefault().Id,
                    PerkawinanId = context.Perkawinan.Skip(rnd.Next(nPerkawinan - 1)).FirstOrDefault().Id,
                    SukuId = context.Suku.Skip(rnd.Next(nSuku - 1)).FirstOrDefault().Id,
                    ZoneId = context.Zone.Skip(rnd.Next(nZone - 1)).FirstOrDefault().Id
                }; lst.Add(pegawai);
                pegawai = new Pegawai
                {
                    NIP = "196505081997031" + rnd.Next(1,100).ToString(),
                    Nama = "dr. Rama Vivera Situmorang, Sp.P",
                    TmpLahir = rnd.Next(1,999)+ "Medan",
                    TglLahir = DateTime.UtcNow.AddDays(rnd.Next(1,999)),
                    Alamat = rnd.Next(1,999)+"JL.TONGKOL NO 8 SIBOLGA KELURAHAN PANCURAN GEROBAK KECAMATAN SIBOLGA KOTA",
                    Tlp = rnd.Next(1,999).ToString()+ "223344",
                    TlgMasuk = DateTime.UtcNow.AddDays(rnd.Next(1,999)),
                    LeaderId = Guid.NewGuid(),
                    AgamaId = context.Agama.Skip(rnd.Next(nAgama - 1)).FirstOrDefault().Id,
                    BahasaId = context.Bahasa.Skip(rnd.Next(nBahasa - 1)).FirstOrDefault().Id,
                    GenderId = context.Gender.Skip(rnd.Next(nGender - 1)).FirstOrDefault().Id,
                    GolonganId = context.Golongan.Skip(rnd.Next(nGolongan - 1)).FirstOrDefault().Id,
                    JabatanId = context.Jabatan.Skip(rnd.Next(nJabatan - 1)).FirstOrDefault().Id,
                    NegaraId = context.Negara.Skip(rnd.Next(nNegara - 1)).FirstOrDefault().Id,
                    PendidikanId = context.Pendidikan.Skip(rnd.Next(nPendidikan - 1)).FirstOrDefault().Id,
                    Pendidikan3Id = context.Pendidikan3.Skip(rnd.Next(nPendidikan3 - 1)).FirstOrDefault().Id,
                    PerkawinanId = context.Perkawinan.Skip(rnd.Next(nPerkawinan - 1)).FirstOrDefault().Id,
                    SukuId = context.Suku.Skip(rnd.Next(nSuku - 1)).FirstOrDefault().Id,
                    ZoneId = context.Zone.Skip(rnd.Next(nZone - 1)).FirstOrDefault().Id
                }; lst.Add(pegawai);
                pegawai = new Pegawai
                {
                    NIP = "196505081997031" + rnd.Next(1,100).ToString(),
                    Nama = "dr. Gloria B.L. Pakpahan",
                    TmpLahir = rnd.Next(1,999)+ "Medan",
                    TglLahir = DateTime.UtcNow.AddDays(rnd.Next(1,999)),
                    Alamat = rnd.Next(1,999)+"JL.TONGKOL NO 8 SIBOLGA KELURAHAN PANCURAN GEROBAK KECAMATAN SIBOLGA KOTA",
                    Tlp = rnd.Next(1,999).ToString()+ "223344",
                    TlgMasuk = DateTime.UtcNow.AddDays(rnd.Next(1,999)),
                    LeaderId = Guid.NewGuid(),
                    AgamaId = context.Agama.Skip(rnd.Next(nAgama - 1)).FirstOrDefault().Id,
                    BahasaId = context.Bahasa.Skip(rnd.Next(nBahasa - 1)).FirstOrDefault().Id,
                    GenderId = context.Gender.Skip(rnd.Next(nGender - 1)).FirstOrDefault().Id,
                    GolonganId = context.Golongan.Skip(rnd.Next(nGolongan - 1)).FirstOrDefault().Id,
                    JabatanId = context.Jabatan.Skip(rnd.Next(nJabatan - 1)).FirstOrDefault().Id,
                    NegaraId = context.Negara.Skip(rnd.Next(nNegara - 1)).FirstOrDefault().Id,
                    PendidikanId = context.Pendidikan.Skip(rnd.Next(nPendidikan - 1)).FirstOrDefault().Id,
                    Pendidikan3Id = context.Pendidikan3.Skip(rnd.Next(nPendidikan3 - 1)).FirstOrDefault().Id,
                    PerkawinanId = context.Perkawinan.Skip(rnd.Next(nPerkawinan - 1)).FirstOrDefault().Id,
                    SukuId = context.Suku.Skip(rnd.Next(nSuku - 1)).FirstOrDefault().Id,
                    ZoneId = context.Zone.Skip(rnd.Next(nZone - 1)).FirstOrDefault().Id
                }; lst.Add(pegawai);
                pegawai = new Pegawai
                {
                    NIP = "196505081997031" + rnd.Next(1,100).ToString(),
                    Nama = "drg. Lisbet Masniati Sitinjak",
                    TmpLahir = rnd.Next(1,999)+ "Medan",
                    TglLahir = DateTime.UtcNow.AddDays(rnd.Next(1,999)),
                    Alamat = rnd.Next(1,999)+"JL.TONGKOL NO 8 SIBOLGA KELURAHAN PANCURAN GEROBAK KECAMATAN SIBOLGA KOTA",
                    Tlp = rnd.Next(1,999).ToString()+ "223344",
                    TlgMasuk = DateTime.UtcNow.AddDays(rnd.Next(1,999)),
                    LeaderId = Guid.NewGuid(),
                    AgamaId = context.Agama.Skip(rnd.Next(nAgama - 1)).FirstOrDefault().Id,
                    BahasaId = context.Bahasa.Skip(rnd.Next(nBahasa - 1)).FirstOrDefault().Id,
                    GenderId = context.Gender.Skip(rnd.Next(nGender - 1)).FirstOrDefault().Id,
                    GolonganId = context.Golongan.Skip(rnd.Next(nGolongan - 1)).FirstOrDefault().Id,
                    JabatanId = context.Jabatan.Skip(rnd.Next(nJabatan - 1)).FirstOrDefault().Id,
                    NegaraId = context.Negara.Skip(rnd.Next(nNegara - 1)).FirstOrDefault().Id,
                    PendidikanId = context.Pendidikan.Skip(rnd.Next(nPendidikan - 1)).FirstOrDefault().Id,
                    Pendidikan3Id = context.Pendidikan3.Skip(rnd.Next(nPendidikan3 - 1)).FirstOrDefault().Id,
                    PerkawinanId = context.Perkawinan.Skip(rnd.Next(nPerkawinan - 1)).FirstOrDefault().Id,
                    SukuId = context.Suku.Skip(rnd.Next(nSuku - 1)).FirstOrDefault().Id,
                    ZoneId = context.Zone.Skip(rnd.Next(nZone - 1)).FirstOrDefault().Id
                }; lst.Add(pegawai);
                pegawai = new Pegawai
                {
                    NIP = "196505081997031" + rnd.Next(1,100).ToString(),
                    Nama = "dr. Suryani Margono, Sp. A",
                    TmpLahir = rnd.Next(1,999)+ "Medan",
                    TglLahir = DateTime.UtcNow.AddDays(rnd.Next(1,999)),
                    Alamat = rnd.Next(1,999)+"JL.TONGKOL NO 8 SIBOLGA KELURAHAN PANCURAN GEROBAK KECAMATAN SIBOLGA KOTA",
                    Tlp = rnd.Next(1,999).ToString()+ "223344",
                    TlgMasuk = DateTime.UtcNow.AddDays(rnd.Next(1,999)),
                    LeaderId = Guid.NewGuid(),
                    AgamaId = context.Agama.Skip(rnd.Next(nAgama - 1)).FirstOrDefault().Id,
                    BahasaId = context.Bahasa.Skip(rnd.Next(nBahasa - 1)).FirstOrDefault().Id,
                    GenderId = context.Gender.Skip(rnd.Next(nGender - 1)).FirstOrDefault().Id,
                    GolonganId = context.Golongan.Skip(rnd.Next(nGolongan - 1)).FirstOrDefault().Id,
                    JabatanId = context.Jabatan.Skip(rnd.Next(nJabatan - 1)).FirstOrDefault().Id,
                    NegaraId = context.Negara.Skip(rnd.Next(nNegara - 1)).FirstOrDefault().Id,
                    PendidikanId = context.Pendidikan.Skip(rnd.Next(nPendidikan - 1)).FirstOrDefault().Id,
                    Pendidikan3Id = context.Pendidikan3.Skip(rnd.Next(nPendidikan3 - 1)).FirstOrDefault().Id,
                    PerkawinanId = context.Perkawinan.Skip(rnd.Next(nPerkawinan - 1)).FirstOrDefault().Id,
                    SukuId = context.Suku.Skip(rnd.Next(nSuku - 1)).FirstOrDefault().Id,
                    ZoneId = context.Zone.Skip(rnd.Next(nZone - 1)).FirstOrDefault().Id
                }; lst.Add(pegawai);
                await context.Pegawai.AddRangeAsync(lst);
            }
            await context.SaveChangesAsync();
            return;
        }
    }
}