using Application.Core;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain;
using Domain.DomainDto;
using DomainDto;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.AppPegawai
{
    public class Details
    {
        public class Query : IRequest<Result<PegawaiDto>>
        {
            public Guid Id { get; set; }
        }
        public class Handler : IRequestHandler<Query, Result<PegawaiDto>>
        {
            private readonly AppDbContext _context;
            private readonly IMapper _mapper;
            public Handler(AppDbContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;
            }

            public async Task<Result<PegawaiDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var ret = await _context.Pegawai
                    .Include(a => a.PegawaiAgama)
                    .ProjectTo<PegawaiDto>(_mapper.ConfigurationProvider)
                    .FirstOrDefaultAsync( a => a.Id == request.Id) ;

                return Result<PegawaiDto>.Success(ret);

            }
        }
    }
}