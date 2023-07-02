using Application.AppValidator;
using Application.Core;
using AutoMapper;
using Domain;
using FluentValidation;
using MediatR;
using Persistence;

namespace Application.AppGolongan
{
    public class Edit
    {
        public class Command : IRequest<Result<Unit>>
        {
            public Golongan Golongan { get; set; }
        }
        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(a => a.Golongan).SetValidator(new GolonganValidator());
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
                var r = await _context.Golongan.FindAsync(request.Golongan.Id);
                if (r == null) return null;

                _mapper.Map(request.Golongan, r);
                _context.Golongan.Update(r);
                var ret = await _context.SaveChangesAsync() > 0;
                if (!ret) return Result<Unit>.Failure("Fail to update golongan");
                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}