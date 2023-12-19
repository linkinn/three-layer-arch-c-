using FluentValidation;

namespace ThreeLayerArch.Business.Models.Validations
{
	public class SupplierValidation : AbstractValidator<Supplier>
    {
		public SupplierValidation()
		{
			RuleFor(s => s.Name)
                .NotEmpty().WithMessage("The {PropertyName} field needs to be provided!")
                .Length(2, 200).WithMessage("The {PropertyName} field needs to be between {MinLength} and {MaxLength} character long!");
		}
	}
}

