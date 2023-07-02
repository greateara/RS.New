using Application.AppValidator;
using Application.Core;
using AutoMapper;
using Domain;
using FluentValidation;
using MediatR;
using Persistence;

namespace Application.AppBahasa
{
    public class Edit
    {
        public class Command : IRequest<Result<Unit>>
        {
            public Bahasa Bahasa { get; set; }
        }
        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(a => a.Bahasa).SetValidator(new BahasaValidator());
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
                var r = await _context.Bahasa.FindAsync(request.Bahasa.Id);
                if (r == null) return null;
                
                _mapper.Map(request.Bahasa, r);
                _context.Bahasa.Update(r);
                var ret = await _context.SaveChangesAsync() > 0;
                if (!ret) return Result<Unit>.Failure("Fail to update organization");
                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}