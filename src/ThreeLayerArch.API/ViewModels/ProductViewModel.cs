using System;
using System.ComponentModel.DataAnnotations;

namespace ThreeLayerArch.API.ViewModels
{
	public class ProductViewModel
	{
		public Guid Id { get; set; }

		[Required(ErrorMessage = "The filed {0} is required!")]
		public Guid SupplierId { get; set; }

        [Required(ErrorMessage = "The filed {0} is required!")]
		[StringLength(200, ErrorMessage = "The field {0} needs to have between {2} and {1} characters!", MinimumLength = 2)]
        public string? Name { get; set; }

        [Required(ErrorMessage = "The filed {0} is required!")]
        [StringLength(1000, ErrorMessage = "The field {0} needs to have between {2} and {1} characters!", MinimumLength = 2)]
        public string? Description { get; set; }

        [Required(ErrorMessage = "The filed {0} is required!")]
        public decimal Price { get; set; }

        public DateTime RegistrationDate { get; set; }

        public bool Active { get; set; }

        public string? NameSupplier { get; set; }
    }
}

