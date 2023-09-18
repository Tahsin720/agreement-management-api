using AgreementManagement.Dto;
using FluentValidation;

namespace AgreementManagement.Validation
{
    public class VendorAgreementValidator : AbstractValidator<VendorAgreementDto>
    {
        public VendorAgreementValidator()
        {
            RuleFor(x => x.vendor_id)
                .Cascade(CascadeMode.Stop)
                .NotNull().NotEmpty().WithMessage("Vendor id is required.");
            RuleFor(x => x.bl_code)
                .GreaterThanOrEqualTo(0).WithMessage("BL Code must be greater than or equal to 0.");

            RuleFor(x => x.document_code)
                .NotEmpty().WithMessage("Document code is required.");

            RuleFor(x => x.start)
                .NotNull().WithMessage("Start date is required.");

            RuleFor(x => x.expiry_date)
                .NotNull().WithMessage("Expiry date is required.")
                .GreaterThan(x => x.start).WithMessage("Expiry date must be greater than the start date.");

            RuleFor(x => x.File)
                .NotNull().WithMessage("File is required.")
                .Must(BeAValidFile).WithMessage("Invalid file format.");
        }

        private bool BeAValidFile(IFormFile file)
        {
            if (file != null)
            {
                var allowedExtensions = new[] { ".pdf", ".doc", ".docx" };
                var fileExtension = Path.GetExtension(file.FileName);
                return allowedExtensions.Contains(fileExtension.ToLower());
            }
            return false;
        }
    }
}
