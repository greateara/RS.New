using Domain;
using FluentValidation;
// using Domain;

namespace Application.AppValidator
{
    public class OrgValidator : AbstractValidator<Org>
    {
        public OrgValidator()
        {
            RuleFor(a => a.OrgName).NotEmpty();
            RuleFor(a => a.Parent).NotEmpty();
            // RuleFor( a => a.Deleted).NotEmpty();  // Karena Default Value adalah 0
            // RuleFor( a => a.).NotEmpty();
        }
    }

    public class AgamaValidator : AbstractValidator<Agama>
    {
        public AgamaValidator()
        {
            RuleFor(a => a.Uraian).NotEmpty().Length(1);
            RuleFor(a => a.TimeStamp).GreaterThan(DateTime.MinValue);
            RuleFor(a => a.Deleted).NotEmpty();
            RuleFor(a => a.Kode).NotEmpty();

            // RuleFor(a => a.Kode).NotEmpty();
            // RuleFor(a => a.Deleted).NotEmpty();
        }
    }
    public class BahasaValidator : AbstractValidator<Bahasa>
    {
        public BahasaValidator()
        {
            RuleFor(a => a.Uraian).NotEmpty();
            RuleFor(a => a.Kode).NotEmpty();
            RuleFor(a => a.Deleted).NotEmpty();
        }
    }
    public class GenderValidator : AbstractValidator<Gender>
    {
        public GenderValidator()
        {
            RuleFor(a => a.Uraian).NotEmpty();
            RuleFor(a => a.Kode).NotEmpty();
            RuleFor(a => a.Deleted).NotEmpty();
        }
    }
    public class GolonganValidator : AbstractValidator<Golongan>
    {
        public GolonganValidator()
        {
            RuleFor(a => a.UraianGolongan).NotEmpty();
            RuleFor(a => a.Kode).NotEmpty();
            RuleFor(a => a.Deleted).NotEmpty();
        }
    }
    public class JabatanValidator : AbstractValidator<Jabatan>
    {
        public JabatanValidator()
        {
            RuleFor(a => a.Uraian).NotEmpty();
            RuleFor(a => a.Kode).NotEmpty();
            RuleFor(a => a.Deleted).NotEmpty();
        }
    }
}