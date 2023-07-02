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

namespace Application.AppOrg
{
    public class List
    {
        public class Query : IRequest<Result<List<OrgDto>>> { }

        public class Handler : IRequestHandler<Query, Result<List<OrgDto>>>
        {
            private readonly AppDbContext _context;
            private readonly IMapper _mapper;
            public Handler(AppDbContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;
            }

            public async Task<Result<List<OrgDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var r = await _context.Org
                    .Include(a => a.OrgType)
                    .ProjectTo<OrgDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken);

                // var result = _mapper.Map<List<Org>, List<OrgDto>>(r);
                return Result<List<OrgDto>>.Success(r);

            }
        }
    }
}