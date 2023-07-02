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

namespace Application.AppGolongan
{
    public class List
    {
        public class Query : IRequest<Result<List<GolonganDto>>> { }

        public class Handler : IRequestHandler<Query, Result<List<GolonganDto>>>
        {
            private readonly AppDbContext _context;
            private readonly IMapper _mapper;
            public Handler(AppDbContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;
            }

            public async Task<Result<List<GolonganDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var r = await _context.Golongan
                    // .Include(a => a.OrgType)
                    .ProjectTo<GolonganDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken);
                return Result<List<GolonganDto>>.Success(r);

            }
        }
    }
}