using Application.Core;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.DomainDto;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.AppJabatan
{
    public class Details
    {
        public class Query : IRequest<Result<JabatanDto>>
        {
            public Guid Id { get; set; }
        }
        public class Handler : IRequestHandler<Query, Result<JabatanDto>>
        {
            private readonly AppDbContext _context;
            private readonly IMapper _mapper;
            public Handler(AppDbContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;
            }

            public async Task<Result<JabatanDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var ret = await _context.Jabatan
                    // .Include(a => a.OrgType)
                    .ProjectTo<JabatanDto>(_mapper.ConfigurationProvider)
                    .FirstOrDefaultAsync( a => a.Id == request.Id) ;
                return Result<JabatanDto>.Success(ret);

            }
        }
    }
}