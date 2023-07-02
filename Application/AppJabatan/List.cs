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
using Domain.DomainDto;

namespace Application.AppJabatan
{
    public class List
    {
        public class Query : IRequest<Result<List<JabatanDto>>> { }

        public class Handler : IRequestHandler<Query, Result<List<JabatanDto>>>
        {
            private readonly AppDbContext _context;
            private readonly IMapper _mapper;
            public Handler(AppDbContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;
            }

            public async Task<Result<List<JabatanDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var r = await _context.Jabatan
                    // .Include(a => a.OrgType)
                    .ProjectTo<JabatanDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken);

                // var result = _mapper.Map<List<Agama>, List<AgamaDto>>(r);
                return Result<List<JabatanDto>>.Success(r);

            }
        }
    }
}