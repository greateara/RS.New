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
using DomainDto;

namespace Application.AppPegawai
{
    public class List
    {
        public class Query : IRequest<Result<List<PegawaiDto>>> { }

        public class Handler : IRequestHandler<Query, Result<List<PegawaiDto>>>
        {
            private readonly AppDbContext _context;
            private readonly IMapper _mapper;
            public Handler(AppDbContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;
            }

            public async Task<Result<List<PegawaiDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var r = await _context.Pegawai
                    .Include(a => a.PegawaiAgama)
                    .ProjectTo<PegawaiDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken);

                // var result = _mapper.Map<List<Pegawai>, List<PegawaiDto>>(r);
                return Result<List<PegawaiDto>>.Success(r);

            }
        }
    }
}