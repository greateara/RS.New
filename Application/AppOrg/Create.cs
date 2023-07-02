using Application.AppValidator;
using Application.Core;
using Application.Interfaces;
using Domain;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.AppOrg
{
    public class Create
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
            private readonly IUserAccessor _userAccessor;
            public Handler(AppDbContext context, IUserAccessor userAccessor)
            {
                _userAccessor = userAccessor;
                _context = context;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                // Pengujian untuk mendapatkan nama user yang mengakses
                var user = await _context.Users.FirstOrDefaultAsync
                    (a => a.UserName == _userAccessor.GetUsername());
                _context.Org.Add(request.Org);
                var ret = await _context.SaveChangesAsync() > 0;
                if (!ret) return Result<Unit>.Failure("Fail to create Organization Type");
                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}