using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Syscode42.AppMvc.ViewModels
{
	public class AddressViewModel
	{
		public AddressViewModel()
		{
			Id = Guid.NewGuid();
		}

		[Key]
		public Guid Id { get; set; }

		[DisplayName("Logradouro")]
		[Required(ErrorMessage = "O campo {0} é obrigatório.")]
		[StringLength(200, ErrorMessage = "O campo {0} precisar ter entre {2} e {1} caracteres", MinimumLength = 1)]
		public string Street { get; set; }

		[DisplayName("Número")]
		[Required(ErrorMessage = "O campo {0} é obrigatório.")]
		[StringLength(50, ErrorMessage = "O campo {0} precisar ter entre {2} e {1} caracteres", MinimumLength = 1)]
		public string AddressNumber { get; set; }

		[DisplayName("Complemento")]
		public string Complement { get; set; }

		[DisplayName("CEP")]
		[Required(ErrorMessage = "O campo {0} é obrigatório.")]
		[StringLength(8, ErrorMessage = "O campo {0} precisar ter entre {2} e {1} caracteres", MinimumLength = 8)]
		public string PostalCode { get; set; }

		[DisplayName("Bairro")]
		[Required(ErrorMessage = "O campo {0} é obrigatório.")]
		[StringLength(100, ErrorMessage = "O campo {0} precisar ter entre {2} e {1} caracteres", MinimumLength = 2)]
		public string Neighborhood { get; set; }

		[DisplayName("Cidade")]
		[Required(ErrorMessage = "O campo {0} é obrigatório.")]
		[StringLength(100, ErrorMessage = "O campo {0} precisar ter entre {2} e {1} caracteres", MinimumLength = 2)]
		public string City { get; set; }

		[DisplayName("Estado")]
		[Required(ErrorMessage = "O campo {0} é obrigatório.")]
		[StringLength(50, ErrorMessage = "O campo {0} precisar ter entre {2} e {1} caracteres", MinimumLength = 2)]
		public string State { get; set; }

		[HiddenInput]
		public Guid SupplierId { get; set; }
	}
}