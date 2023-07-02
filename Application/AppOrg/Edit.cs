using Application.AppValidator;
using Application.Core;
using AutoMapper;
using Domain;
using FluentValidation;
using MediatR;
using Persistence;

namespace Application.AppOrg
{
    public class Edit
    {
        public class Command : IRequest<Result<Unit>>
        {
            public Org Org { get; set; }
        }
        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(a => a.Org).SetValidator(new OrgValidator());
            }
        }
        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly AppDbContext _context;
            private readonly IMapper _mapper;
            public Handler(AppDbContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var r = await _context.Org.FindAsync(request.Org.Id);
                if (r == null) return null;
                // r.Definition = request.ROrgType.Definition ?? r.Definition;
                
                _mapper.Map(request.Org, r);
                _context.Org.Update(r);
                var ret = await _context.SaveChangesAsync() > 0;
                if (!ret) return Result<Unit>.Failure("Fail to update organization");
                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}