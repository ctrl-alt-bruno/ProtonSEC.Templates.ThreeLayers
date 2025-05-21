namespace ProtonSEC.Templates.ThreeLayers.Business.Models;

public class Fornecedor : Entity
{
	public string? Nome { get; set; }
	public string? Documento { get; set; }
	public TiposFornecedores TipoFornecedor { get; set; }
	public bool Ativo { get; set; }
}
