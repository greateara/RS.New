using Application.Core;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using DomainDto;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.AppGolongan
{
    public class Details
    {
        public class Query : IRequest<Result<GolonganDto>>
        {
            public Guid Id { get; set; }
        }
        public class Handler : IRequestHandler<Query, Result<GolonganDto>>
        {
            private readonly AppDbContext _context;
            private readonly IMapper _mapper;
            public Handler(AppDbContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;
            }

            public async Task<Result<GolonganDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var ret = await _context.Golongan
                    // .Include(a => a.OrgType)
                    .ProjectTo<GolonganDto>(_mapper.ConfigurationProvider)
                    .FirstOrDefaultAsync( a => a.Id == request.Id) ;
                return Result<GolonganDto>.Success(ret);

            }
        }
    }
}