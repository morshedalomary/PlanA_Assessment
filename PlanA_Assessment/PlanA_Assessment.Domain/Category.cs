using System;
using System.Collections.Generic;

namespace PlanA_Assessment.Domain
{
    public class Category {
		public Guid ID { get; set; }
		public string  Name { get; set; }
		public ICollection<Product> products{ get; set; }



	}
}
