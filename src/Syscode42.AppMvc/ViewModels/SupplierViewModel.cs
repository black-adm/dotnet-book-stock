using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Syscode42.AppMvc.ViewModels
{
	public class SupplierViewModel
	{
		public SupplierViewModel()
		{
			Id = Guid.NewGuid();
		}

		[Key]
		public Guid Id { get; set; }

		[DisplayName("Nome")]
		[Required(ErrorMessage = "O campo {0} é obrigatório.")]
		[StringLength(100, ErrorMessage = "O campo {0} precisar ter entre {2} e {1} caracteres", MinimumLength = 2)]
		public string Name { get; set; }

		[DisplayName("Documento")]
		[Required(ErrorMessage = "O campo {0} é obrigatório.")]
		[StringLength(14, ErrorMessage = "O campo {0} precisar ter entre {2} e {1} caracteres", MinimumLength = 11)]
		public string Documento { get; set; }

		[DisplayName("Tipo")]
		public int SupplierType { get; set; }

		public AddressViewModel Address { get; set; }

		[DisplayName("Ativo?")]
		public bool IsActive { get; set; }

		public IEnumerable<ProductViewModel> Products { get; set; }
	}
}