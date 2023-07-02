using Application.AppValidator;
using Application.Core;
using AutoMapper;
using Domain;
using FluentValidation;
using MediatR;
using Persistence;

namespace Application.AppGender
{
    public class Edit
    {
        public class Command : IRequest<Result<Unit>>
        {
            public Gender Gender { get; set; }
        }
        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(a => a.Gender).SetValidator(new GenderValidator());
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
                var r = await _context.Gender.FindAsync(request.Gender.Id);
                if (r == null) return null;
                
                _mapper.Map(request.Gender, r);
                _context.Gender.Update(r);
                var ret = await _context.SaveChangesAsync() > 0;
                if (!ret) return Result<Unit>.Failure("Fail to update organization");
                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}