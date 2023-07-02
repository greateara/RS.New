using Application.Core;
using MediatR;
using Persistence;

namespace Application.AppPegawai
{
    public class Delete
    {
        public class Command : IRequest<Result<Unit>>
        {
            public Guid Id { get; set; }
        }
        public class Handler : IRequestHandler<Command, Result<Unit>>
        {
            private readonly AppDbContext _context;
            public Handler(AppDbContext context)
            {
                _context = context;
            }

            public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var r = await _context.Pegawai.FindAsync(request.Id);
                if (r == null) return null;
                _context.Remove(r);
                var ret = await _context.SaveChangesAsync() > 0;
                if (!ret) return Result<Unit>.Failure("Fail to delete");
                return Result<Unit>.Success( Unit.Value);
            }
        }
    }
}