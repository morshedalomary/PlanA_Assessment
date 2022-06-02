using System;


namespace PlanA_Assessment.Domain
{
    public  class Product
	{
		public Guid ID { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }

		public double Price { get; set; }
		public string Image { get; set; }

		public int Number_of_Views { get; set; }


		public string Dietary_flags { get; set; }
		public Category Category { get; set; }

		public Guid CategoryId { get; set; }

	}
}
