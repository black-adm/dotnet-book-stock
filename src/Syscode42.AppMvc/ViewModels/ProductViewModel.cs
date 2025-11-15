using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace Syscode42.AppMvc.ViewModels
{
    public class ProductViewModel
    {
        public ProductViewModel()
        {
            Id = Guid.NewGuid();
		}

        [Key]
		public Guid Id { get; set; }

		[DisplayName("Fornecedor")]
		[Required(ErrorMessage = "O campo {0} é obrigatório.")]
		public Guid SupplierId { get; set; }

		[DisplayName("Nome")]
		[Required(ErrorMessage = "O campo {0} é obrigatório.")]
		[StringLength(200, ErrorMessage = "O campo {0} precisar ter entre {2} e {1} caracteres", MinimumLength = 2)]
		public string Name { get; set; }

		[DisplayName("Descrição")]
		[Required(ErrorMessage = "O campo {0} é obrigatório.")]
		[StringLength(1000, ErrorMessage = "O campo {0} precisar ter entre {2} e {1} caracteres", MinimumLength = 2)]
		public string Description { get; set; }

		[DisplayName("Imagem do Produto")]
		public HttpPostedFileBase Image { get; set; }

		[DisplayName("Valor")]
		[Required(ErrorMessage = "O campo {0} é obrigatório.")]
		public decimal Value { get; set; }

		[ScaffoldColumn(false)]
		public DateTime RegistrationDate { get; set; }
		
		[DisplayName("Ativo?")]
		public bool IsActive { get; set; }

		public SupplierViewModel Supplier { get; set; }

		public IEnumerable<SupplierViewModel> Suppliers { get; set; }
	}
}