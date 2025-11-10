using Syscode42.Business.Core.Models;

namespace Syscode42.Business.Models.Suppliers
{
    public class Address : Entity
    {
        public string Street { get; set; }
        public string AddressNumber { get; set; }
        public string Complement { get; set; }
        public string PostalCode { get; set; }
        public string Neighborhood { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        
        public Supplier Supplier { get; set; }
    }
}