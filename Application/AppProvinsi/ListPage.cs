using Application.Core;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
using AutoMapper.QueryableExtensions;
// using Domain.DomainDto;
using DomainDto;

namespace Application.AppProvinsi
{
    public class ListPage
    {
        public class Query : IRequest<Result<List<AgamaDto>>>
        {
            public string SearchText { get; set; } = " ";
            public int Count { get; set; }
            public int Skip { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<List<AgamaDto>>>
        {
            private readonly AppDbContext _context;
            private readonly IMapper _mapper;
            public Handler(AppDbContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;
            }

            public async Task<Result<List<AgamaDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var r = new List<AgamaDto>();
                if (request.SearchText != "~")
                {
                    r = await _context.Agama
                       .Where(c => c.Deleted == 0)
                       .Where(c => c.Uraian.ToUpper().Contains(request.SearchText.ToUpper()))
                       .Skip(request.Skip)
                       .Take(request.Count)
                       .OrderBy(c => c.Uraian)
                       // .Include(a => a.OrgType)
                       .ProjectTo<AgamaDto>(_mapper.ConfigurationProvider)
                       .ToListAsync(cancellationToken);
                }
                else
                {
                    r = await _context.Agama
                        .Where(c => c.Deleted == 0)
                        // .Where(c => c.Uraian.ToUpper().Contains(request.SearchText.ToUpcper()) || request.SearchText == "")
                        .Skip(request.Skip)
                        .Take(request.Count)
                        .OrderBy(c => c.Uraian)
                        // .Include(a => a.OrgType)
                        .ProjectTo<AgamaDto>(_mapper.ConfigurationProvider)
                        .ToListAsync(cancellationToken);
                }
                // var result = _mapper.Map<List<Agama>, List<AgamaDto>>(r);
                return Result<List<AgamaDto>>.Success(r);

            }
        }
    }
}