using Application.Core;
using AutoMapper;
using Domain;
using FluentValidation;
using MediatR;
using Persistence;

namespace Application.AppPegawai
{
    public class Edit
    {
        public class Command : IRequest<Result<Unit>>
        {
            public Pegawai Pegawai { get; set; }
        }
        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(a => a.Pegawai).SetValidator(new PegawaiValidator());
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
                var r = await _context.Pegawai.FindAsync(request.Pegawai.Id);
                if (r == null) return null;
                // r.Definition = request.RPegawaiType.Definition ?? r.Definition;
                
                _mapper.Map(request.Pegawai, r);
                _context.Pegawai.Update(r);
                var ret = await _context.SaveChangesAsync() > 0;
                if (!ret) return Result<Unit>.Failure("Fail to update ");
                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}