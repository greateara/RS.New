using Domain;
using FluentValidation;
// using Domain;

namespace Application.AppPegawai
{
    public class PegawaiValidator : AbstractValidator<Pegawai>
    {
        public PegawaiValidator()
        {
            RuleFor( a => a.Nama).NotEmpty();
            RuleFor( a => a.Alamat).NotEmpty();
            // RuleFor( a => a.Deleted).NotEmpty();  // Karena Default Value adalah 0
            // RuleFor( a => a.).NotEmpty();
        }
    }
}