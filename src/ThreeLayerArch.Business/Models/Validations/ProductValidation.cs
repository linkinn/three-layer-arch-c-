using FluentValidation;

namespace ThreeLayerArch.Business.Models.Validations
{
	public class ProductValidation : AbstractValidator<Product>
	{
		public ProductValidation()
		{
			RuleFor(c => c.Name)
				.NotEmpty().WithMessage("The {PropertyName} field needs to be provided!")
				.Length(2,200).WithMessage("The {PropertyName} field needs to be between {MinLength} and {MaxLength} character long!");

            RuleFor(c => c.Description)
                .NotEmpty().WithMessage("The {PropertyName} field needs to be provided!")
                .Length(2, 1000).WithMessage("The {PropertyName} field needs to be between {MinLength} and {MaxLength} character long!");

            RuleFor(c => c.Price)
                .GreaterThan(0).WithMessage("The {PropertyName} field needs to be larger than {ComparisonValue}!");
        }
	}
}

