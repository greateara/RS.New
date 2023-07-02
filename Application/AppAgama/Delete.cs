using Application.Core;
using MediatR;
using Persistence;

namespace Application.AppAgama
{
    public class Delete
    {
        public class Command : IRequest<Result<Unit>>
        {
            public Guid Id { get; set; }
            public string TimeStamp { get; set; }
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
                var r = await _context.Agama.FindAsync(request.Id);
                // if (r == null) return null ; //<Unit>.Failure("Cannot found this record");
                if (r == null) return Result<Unit>.Failure("Cannot found this record");
                // if (r.TimeStamp.ToString("yyyy-MM-ddTHH:mm:ss.ffffff") != request.TimeStamp) return Result<Unit>.Failure("Data changed, abort!");
                if (r.TimeStamp != DateTime.Parse(request.TimeStamp)) return Result<Unit>.Failure("Data changed, abort!");
                r.Deleted = 1; //setting deleted state
                _context.Agama.Update(r);
                var ret = await _context.SaveChangesAsync() > 0;
                if (!ret) return Result<Unit>.Failure("Fail to delete!");
                return Result<Unit>.Success(Unit.Value);
            }
        }
    }
}