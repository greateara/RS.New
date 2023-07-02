using Application.Core;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using DomainDto;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.AppBahasa
{
    public class Details
    {
        public class Query : IRequest<Result<BahasaDto>>
        {
            public Guid Id { get; set; }
        }
        public class Handler : IRequestHandler<Query, Result<BahasaDto>>
        {
            private readonly AppDbContext _context;
            private readonly IMapper _mapper;
            public Handler(AppDbContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;
            }

            public async Task<Result<BahasaDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var ret = await _context.Bahasa
                    // .Include(a => a.OrgType)
                    .ProjectTo<BahasaDto>(_mapper.ConfigurationProvider)
                    .FirstOrDefaultAsync( a => a.Id == request.Id) ;
                return Result<BahasaDto>.Success(ret);

            }
        }
    }
}