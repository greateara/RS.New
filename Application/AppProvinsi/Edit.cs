using Application.AppValidator;
using Application.Core;
using AutoMapper;
using Domain;
using DomainDto;
using FluentValidation;
using MediatR;
using Persistence;

namespace Application.AppProvinsi
{
    public class Edit
    {
        public class Command : IRequest<Result<Unit>>
        {
            public Provinsi Provinsi { get; set; }
        }
        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(a => a.Provinsi).SetValidator(new ProvinsiValidator());
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
                var r = await _context.Provinsi.FindAsync(request.Provinsi.Id);
                if (r == null) return null;
                if (r.TimeStamp != request.Provinsi.TimeStamp) return null;
                request.Provinsi.TimeStamp = DateTime.UtcNow;
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<Provinsi, Provinsi>();
                });
                var mapper = new Mapper(config);

                // // Melakukan pemetaan nilai properti
                mapper.Map(request.Provinsi, r);
                _context.Provinsi.Update(r);

                var ret = await _context.SaveChangesAsync() > 0;
                if (!ret) return Result<Unit>.Failure("Fail to update organization");
                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}