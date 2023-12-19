using System;
using System.ComponentModel.DataAnnotations;

namespace ThreeLayerArch.API.ViewModels
{
	public class SupplierViewModel
	{
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "The filed {0} is required!")]
        [StringLength(100, ErrorMessage = "The field {0} needs to have between {2} and {1} characters!", MinimumLength = 2)]
        public string? Name { get; set; }

        [Required(ErrorMessage = "The filed {0} is required!")]
        [StringLength(14, ErrorMessage = "The field {0} needs to have between {2} and {1} characters!", MinimumLength = 14)]
        public string? Document { get; set; }

        public int SupplierType { get; set; }

        public AddressViewModel Address { get; set; }

        public bool Active { get; set; }

        public IEnumerable<ProductViewModel> Products { get; set; }
    }
}

