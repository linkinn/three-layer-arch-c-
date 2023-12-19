using System;
using System.ComponentModel.DataAnnotations;

namespace ThreeLayerArch.API.ViewModels
{
	public class AddressViewModel
	{
        public Guid Id { get; set; }

        [Required(ErrorMessage = "The filed {0} is required!")]
        [StringLength(200, ErrorMessage = "The field {0} needs to have between {2} and {1} characters!", MinimumLength = 2)]
        public string? PublicPlace { get; set; }

        [Required(ErrorMessage = "The filed {0} is required!")]
        [StringLength(50, ErrorMessage = "The field {0} needs to have between {2} and {1} characters!", MinimumLength = 2)]
        public string? Number { get; set; }

        [Required(ErrorMessage = "The filed {0} is required!")]
        [StringLength(8, ErrorMessage = "The field {0} needs to have between {2} and {1} characters!", MinimumLength = 8)]
        public string? ZipCode { get; set; }

        public string? Complement { get; set; }

        [Required(ErrorMessage = "The filed {0} is required!")]
        [StringLength(200, ErrorMessage = "The field {0} needs to have between {2} and {1} characters!", MinimumLength = 2)]
        public string? Neighborhood { get; set; }

        [Required(ErrorMessage = "The filed {0} is required!")]
        [StringLength(100, ErrorMessage = "The field {0} needs to have between {2} and {1} characters!", MinimumLength = 2)]
        public string? City { get; set; }

        [Required(ErrorMessage = "The filed {0} is required!")]
        [StringLength(50, ErrorMessage = "The field {0} needs to have between {2} and {1} characters!", MinimumLength = 2)]
        public string? State { get; set; }

        public Guid SupplierId { get; set; }
    }
}

