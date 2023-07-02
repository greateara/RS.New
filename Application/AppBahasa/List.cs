using System.Text.Json;
using System.Text.Json.Serialization;
using Application.Core;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
using AutoMapper.QueryableExtensions;
// using Domain.DomainDto;
using DomainDto;

namespace Application.AppBahasa
{
    public class List
    {
        public class Query : IRequest<Result<List<BahasaDto>>> { }

        public class Handler : IRequestHandler<Query, Result<List<BahasaDto>>>
        {
            private readonly AppDbContext _context;
            private readonly IMapper _mapper;
            public Handler(AppDbContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;
            }

            public async Task<Result<List<BahasaDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var r = await _context.Bahasa
                    // .Include(a => a.OrgType)
                    .ProjectTo<BahasaDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken);

                // var result = _mapper.Map<List<Agama>, List<AgamaDto>>(r);
                return Result<List<BahasaDto>>.Success(r);

            }
        }
    }
}