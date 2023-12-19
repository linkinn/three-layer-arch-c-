using FluentValidation;

namespace ThreeLayerArch.Business.Models.Validations
{
	public class AddressValidation : AbstractValidator<Address>
    {
		public AddressValidation()
		{
            RuleFor(c => c.PublicPlace)
                .NotEmpty().WithMessage("The {PropertyName} field needs to be provided!")
                .Length(2, 200).WithMessage("The {PropertyName} field needs to be between {MinLength} and {MaxLength} character long!");

            RuleFor(c => c.Neighborhood)
                .NotEmpty().WithMessage("The {PropertyName} field needs to be provided!")
                .Length(2, 100).WithMessage("The {PropertyName} field needs to be between {MinLength} and {MaxLength} character long!");

            RuleFor(c => c.ZipCode)
                .NotEmpty().WithMessage("The {PropertyName} field needs to be provided!")
                .Length(8).WithMessage("The {PropertyName} field needs to be {MaxLength} character long!");

            RuleFor(c => c.City)
                .NotEmpty().WithMessage("The {PropertyName} field needs to be provided!")
                .Length(2, 100).WithMessage("The {PropertyName} field needs to be between {MinLength} and {MaxLength} character long!");

            RuleFor(c => c.State)
                .NotEmpty().WithMessage("The {PropertyName} field needs to be provided!")
                .Length(2, 50).WithMessage("The {PropertyName} field needs to be between {MinLength} and {MaxLength} character long!");

            RuleFor(c => c.Number)
                .NotEmpty().WithMessage("The {PropertyName} field needs to be provided!")
                .Length(1, 50).WithMessage("The {PropertyName} field needs to be between {MinLength} and {MaxLength} character long!");
        }
	}
}

