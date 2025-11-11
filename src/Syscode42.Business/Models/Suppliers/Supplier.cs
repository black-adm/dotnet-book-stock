using System.Collections.Generic;
using Syscode42.Business.Core.Models;
using Syscode42.Business.Models.Products;

namespace Syscode42.Business.Models.Suppliers
{
    public class Supplier : Entity
    {
        public string Name { get; set; } 
        public string Document { get; set; }
        public SupplierType SupplierType { get; set; }
        public Address Address { get; set; }
        public bool IsActive { get; set; }
        
        public ICollection<Product> Products { get; set; }
    }
}