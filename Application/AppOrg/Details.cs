using Application.Core;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain;
using Domain.DomainDto;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.AppOrg
{
    public class Details
    {
        public class Query : IRequest<Result<OrgDto>>
        {
            public Guid Id { get; set; }
        }
        public class Handler : IRequestHandler<Query, Result<OrgDto>>
        {
            private readonly AppDbContext _context;
            private readonly IMapper _mapper;
            public Handler(AppDbContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;
            }

            public async Task<Result<OrgDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var ret = await _context.Org
                    .Include(a => a.OrgType)
                    .ProjectTo<OrgDto>(_mapper.ConfigurationProvider)
                    .FirstOrDefaultAsync( a => a.Id == request.Id) ;

                // var r = await _context.Org
                //     .Include(a => a.OrgType)
                //     .ProjectTo<OrgDto>(_mapper.ConfigurationProvider)
                //     .ToListAsync(cancellationToken);

                return Result<OrgDto>.Success(ret);
                // if (ret == null) return NotFound(); 
                // return ret;

            }
        }
    }
}