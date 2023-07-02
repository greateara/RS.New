using Application.Core;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
using AutoMapper.QueryableExtensions;
// using Domain.DomainDto;
using DomainDto;
using Domain.DomainDto;

namespace Application.AppGender
{
    public class List
    {
        public class Query : IRequest<Result<List<GenderDto>>> { }

        public class Handler : IRequestHandler<Query, Result<List<GenderDto>>>
        {
            private readonly AppDbContext _context;
            private readonly IMapper _mapper;
            public Handler(AppDbContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;
            }

            public async Task<Result<List<GenderDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var r = await _context.Gender
                    // .Include(a => a.OrgType)
                    .ProjectTo<GenderDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken);

                // var result = _mapper.Map<List<Agama>, List<AgamaDto>>(r);
                return Result<List<GenderDto>>.Success(r);

            }
        }
    }
}