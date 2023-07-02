using Domain;
using FluentValidation;
// using Domain;

namespace Application.AppOrgType
{
    public class OrgTypeValidator : AbstractValidator<OrgType>
    {
        public OrgTypeValidator()
        {
            RuleFor( a => a.Code).NotEmpty();
            RuleFor( a => a.Definition).NotEmpty();
            // RuleFor( a => a.Deleted).NotEmpty();  // Karena Default Value adalah 0
            RuleFor( a => a.Display).NotEmpty();
        }
    }
}