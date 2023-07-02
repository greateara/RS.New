using AutoMapper;
using Domain;
using Domain.DomainDto;
using DomainDto;

namespace Application.Core
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Agama, AgamaDto>();
            CreateMap<Bahasa, BahasaDto>();
            CreateMap<Gender, GenderDto>();
            CreateMap<Golongan, GolonganDto>();
            CreateMap<Jabatan, JabatanDto>();
            CreateMap<OrgType, OrgType>();
            CreateMap<Org, OrgDto>()
                .ForMember(dest => dest.OrgType,
                    opt => opt.MapFrom(src => src.OrgType))
                    .MaxDepth(1);
            CreateMap<OrgType, OrgTypeDto>()
                .MaxDepth(1);
            CreateMap<Pegawai, Pegawai>()
           .MaxDepth(1);
            CreateMap<Pegawai, PegawaiDto>()
                .ForMember(dest => dest.PegawaiAgama,
                    opt => opt.MapFrom(src => src.PegawaiAgama))
                .ForMember(dest => dest.PegawaiBahasa,
                    opt => opt.MapFrom(src => src.PegawaiBahasa))
                .ForMember(dest => dest.PegawaiGolongan,
                    opt => opt.MapFrom(src => src.PegawaiGolongan))
                .ForMember(dest => dest.PegawaiJabatan,
                    opt => opt.MapFrom(src => src.PegawaiJabatan))
                .ForMember(dest => dest.PegawaiNegara,
                    opt => opt.MapFrom(src => src.PegawaiNegara))
                .ForMember(dest => dest.PegawaiPendidikan,
                    opt => opt.MapFrom(src => src.PegawaiPendidikan))
                .ForMember(dest => dest.PegawaiPerkawinan,
                    opt => opt.MapFrom(src => src.PegawaiPerkawinan))
                .ForMember(dest => dest.PegawaiPerkawinan,
                    opt => opt.MapFrom(src => src.PegawaiPerkawinan))
                .ForMember(dest => dest.PegawaiSuku,
                    opt => opt.MapFrom(src => src.PegawaiSuku))
                .ForMember(dest => dest.PegawaiZone,
                    opt => opt.MapFrom(src => src.PegawaiZone))
                    .MaxDepth(1);

        }
    }
}