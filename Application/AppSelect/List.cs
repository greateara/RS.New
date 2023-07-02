using System.Text.Json;
using System.Text.Json.Serialization;
using Application.Core;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
using AutoMapper.QueryableExtensions;
using Domain.DomainDto;
using DomainDto;

namespace Application.AppSelect
{
    public class List
    {
        public class Query : IRequest<Result<List<SelectDto>>>
        {
            public string Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<List<SelectDto>>>
        {
            private readonly AppDbContext _context;
            private readonly IMapper _mapper;
            public Handler(AppDbContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;
            }

            public async Task<Result<List<SelectDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                List<SelectDto> r = new List<SelectDto>();
                switch (request.Id.ToLower())
                {
                    case "agama":
                        r = await _context.Agama
                            .Select(a => new SelectDto(a.Id, a.Uraian))
                            .OrderBy( a => a.Uraian)
                            .ToListAsync(cancellationToken);
                        break;
                    case "bahasa":
                        r = await _context.Bahasa
                            .Select(a => new SelectDto(a.Id, a.Uraian))
                            .OrderBy( a => a.Uraian)
                            .ToListAsync(cancellationToken);
                        break;
                    case "gender":
                        r = await _context.Gender
                            .Select(a => new SelectDto(a.Id, a.Uraian))
                            .OrderBy( a => a.Uraian)
                            .ToListAsync(cancellationToken);
                        break;
                    case "golongan":
                        r = await _context.Golongan
                            .Select(a => new SelectDto(a.Id, a.UraianGolongan + " "+ a.UraianGolongan))
                            .OrderBy( a => a.Uraian)
                            .ToListAsync(cancellationToken);
                        break;
                    case "jabatan":
                        r = await _context.Jabatan
                            .Select(a => new SelectDto(a.Id, a.Uraian))
                            .OrderBy( a => a.Uraian)
                            .ToListAsync(cancellationToken);
                        break;
                    case "location":
                        r = await _context.Location
                            .Select(a => new SelectDto(a.Id, a.Name))
                            .OrderBy( a => a.Uraian)
                            .ToListAsync(cancellationToken);
                        break;
                    case "negara":
                        r = await _context.Negara
                            .Select(a => new SelectDto(a.Id, a.Uraian))
                            .OrderBy( a => a.Uraian)
                            .ToListAsync(cancellationToken);
                        break;
                    case "pendidikan":
                        r = await _context.Pendidikan
                            .Select(a => new SelectDto(a.Id, a.Uraian))
                            .OrderBy( a => a.Uraian)
                            .ToListAsync(cancellationToken);
                        break;
                    case "suku":
                        r = await _context.Suku
                            .Select(a => new SelectDto(a.Id, a.Uraian))
                            .OrderBy( a => a.Uraian)
                            .ToListAsync(cancellationToken);
                        break;
                    case "zone":
                        r = await _context.Zone
                            .Select(a => new SelectDto(a.Id, a.Definition))
                            .ToListAsync(cancellationToken);
                        break;
                    default:
                        // code block
                        break;
                }

                // var result = _mapper.Map<List<SelectDto>, List<SelectDto>>(r);
                return Result<List<SelectDto>>.Success(r);

            }
        }
    }
}
