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
    public class ListFilter
    {
        public class Query : IRequest<Result<List<ProvinsiDto>>>
        {
            public string SearchText { get; set; } = " ";
        }

        public class Handler : IRequestHandler<Query, Result<List<ProvinsiDto>>>
        {
            private readonly AppDbContext _context;
            private readonly IMapper _mapper;
            public Handler(AppDbContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;
            }

            public async Task<Result<List<ProvinsiDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var r = new List<ProvinsiDto>();
                if (request.SearchText != "~")
                {
                    r = await _context.Provinsi
                       .Where(c => c.Deleted == 0)
                       .Where(c => c.Uraian.ToUpper().Contains(request.SearchText.ToUpper()))
                       //ASUMSI MAX 500
                       .Take(500)
                       .OrderBy(c => c.Uraian)
                       // .Include(a => a.OrgType)
                       .ProjectTo<ProvinsiDto>(_mapper.ConfigurationProvider)
                       .ToListAsync(cancellationToken);
                }
                else
                {
                    r = await _context.Provinsi
                        .Where(c => c.Deleted == 0)
                        // .Where(c => c.Uraian.ToUpper().Contains(request.SearchText.ToUpcper()) || request.SearchText == "")
                        //ASSUMSI 500
                        .Take(500)
                        .OrderBy(c => c.Uraian)
                        // .Include(a => a.OrgType)
                        .ProjectTo<ProvinsiDto>(_mapper.ConfigurationProvider)
                        .ToListAsync(cancellationToken);
                }
                // var result = _mapper.Map<List<Agama>, List<AgamaDto>>(r);
                return Result<List<ProvinsiDto>>.Success(r);

            }
        }
    }
}