using Application.Core;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.DomainDto;
using DomainDto;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.AppGender
{
    public class Details
    {
        public class Query : IRequest<Result<GenderDto>>
        {
            public Guid Id { get; set; }
        }
        public class Handler : IRequestHandler<Query, Result<GenderDto>>
        {
            private readonly AppDbContext _context;
            private readonly IMapper _mapper;
            public Handler(AppDbContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;
            }

            public async Task<Result<GenderDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var ret = await _context.Gender
                    // .Include(a => a.OrgType)
                    .ProjectTo<GenderDto>(_mapper.ConfigurationProvider)
                    .FirstOrDefaultAsync( a => a.Id == request.Id) ;
                return Result<GenderDto>.Success(ret);

            }
        }
    }
}