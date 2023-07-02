using Application.Core;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using DomainDto;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.AppAgama
{
    public class Details
    {
        public class Query : IRequest<Result<AgamaDto>>
        {
            public Guid Id { get; set; }
        }
        public class Handler : IRequestHandler<Query, Result<AgamaDto>>
        {
            private readonly AppDbContext _context;
            private readonly IMapper _mapper;
            public Handler(AppDbContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;
            }

            public async Task<Result<AgamaDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var ret = await _context.Agama
                    // .Include(a => a.OrgType)
                    .ProjectTo<AgamaDto>(_mapper.ConfigurationProvider)
                    .FirstOrDefaultAsync( a => a.Id == request.Id) ;

                // var r = await _context.Org
                //     .Include(a => a.OrgType)
                //     .ProjectTo<OrgDto>(_mapper.ConfigurationProvider)
                //     .ToListAsync(cancellationToken);

                return Result<AgamaDto>.Success(ret);
                // if (ret == null) return NotFound(); 
                // return ret;

            }
        }
    }
}