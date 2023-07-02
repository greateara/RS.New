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

namespace Application.AppAgama
{
    public class List
    {
        public class Query : IRequest<Result<List<AgamaDto>>> { }

        public class Handler : IRequestHandler<Query, Result<List<AgamaDto>>>
        {
            private readonly AppDbContext _context;
            private readonly IMapper _mapper;
            public Handler(AppDbContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;
            }

            public async Task<Result<List<AgamaDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var r = await _context.Agama
                    .Where( c => c.Deleted ==0)
                    // .Include(a => a.OrgType)
                    .ProjectTo<AgamaDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken);

                // var result = _mapper.Map<List<Agama>, List<AgamaDto>>(r);
                return Result<List<AgamaDto>>.Success(r);

            }
        }
    }
}