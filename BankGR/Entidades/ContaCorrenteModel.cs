
namespace BankGR.Entidades;

public class ContaCorrenteModel
{
    public ContaCorrenteModel() { }

    public ContaCorrenteModel(int id, string? nome, string agencia, string cpf, double saldo)
    {
        Id = id;
        Nome = nome;
        Agencia = agencia;
        Cpf = cpf;
        Saldo = saldo;
        DataCadastro = DateTime.Now;
    }

    public int Id { get; set; } = 0;
    public string? Nome { get; set; } = string.Empty;
    public string Agencia { get; set; } = string.Empty;
    public string Cpf { get; set; } = string.Empty;
    public double Saldo { get; set; } = 0.00;
    public DateTime DataCadastro { get; set; }

    public override string ToString()
    {
        return $"\n    Número da Agência:   {this.Agencia} \n" +
               $"    Saldo da Conta:      {this.Saldo}       \n" +
               $"    Titular da Conta:    {this.Nome}      \n" +
               $"    CPF do Titular:      {this.Cpf}       \n" +
               $"<=====================================>";
    }
}
