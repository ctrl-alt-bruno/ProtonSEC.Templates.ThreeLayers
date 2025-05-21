using FluentValidation;

namespace ProtonSEC.Templates.ThreeLayers.Business.Models.Validation;

public class FornecedorValidation : AbstractValidator<Fornecedor>
{
	public FornecedorValidation()
	{
		RuleFor(c => c.Nome)
			.NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido.")
			.Length(2, 100).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres.");

		When(x => x.TipoFornecedor == TiposFornecedores.PessoaFisica, () =>
		{
			RuleFor(x => x.Documento.Length).Equal(11)
				.WithMessage("O campo Documento precisa ter {ComparisonValue} caracteres e foi fornecido {PropertyValue}.");
		});

		When(x => x.TipoFornecedor == TiposFornecedores.PessoaJuridica, () =>
		{

		});
	}
}
