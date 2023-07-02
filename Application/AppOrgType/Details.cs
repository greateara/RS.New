using Application.Core;
using Domain;
using MediatR;
using Persistence;

namespace Application.AppOrgType
{
    public class Details
    {
        public class Query : IRequest<Result<OrgType>>
        {
            public Guid Id { get; set; }
        }
        public class Handler : IRequestHandler<Query, Result<OrgType>>
        {
            private readonly AppDbContext _context;
            public Handler(AppDbContext context)
            {
                _context = context;
            }

            public async Task<Result<OrgType>> Handle(Query request, CancellationToken cancellationToken)
            {
                var ret = await _context.OrgType.FindAsync(request.Id);
                return Result<OrgType>.Success(ret);
                // if (ret == null) return NotFound(); 
                // return ret;

            }
        }
    }
}