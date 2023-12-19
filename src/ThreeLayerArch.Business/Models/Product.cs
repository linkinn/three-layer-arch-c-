namespace ThreeLayerArch.Business.Models
{
	public class Product : Entity
	{
        public Guid SupplierId { get; set; }

		public string? Name { get; set; }

        public string? Description { get; set; }

        public decimal Price { get; set; }

        public DateTime RegistrationDate { get; set; }

        public bool Active { get; set; }

        public Supplier Supplier { get; set; }
    }
}

