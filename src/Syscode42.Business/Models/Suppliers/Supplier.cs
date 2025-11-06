using System.Collections.Generic;
using Syscode42.Business.Core.Models;
using Syscode42.Business.Models.Products;

namespace Syscode42.Business.Models.Suppliers
{
    public class Supplier : Entity
    {
        public string Name { get; set; } 
        public string Document { get; set; }
        public SupplierType supplierType { get; set; }
        public Address address { get; set; }
        public bool IsActive { get; set; }
        
        public ICollection<Product> Products { get; set; }
    }
}