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
        NumeroConta = NumeroConta;

    }
    public int Id { get; set; } = 0;
    public string? Nome { get; set; } = string.Empty;
    public string Agencia { get; set; } = string.Empty;
    public string Cpf { get; set; } = string.Empty;
    public double Saldo { get; set; } = 0.00;
    public string NumeroConta { get; set; } = string.Empty;
    public string DataDeCriacao { get; set; } = DateTime.Now.ToString("dd/MM/yyyy");
    public override string ToString()
    {
        return $"\n    Agência:             {this.Agencia} \n" +
               $"    Número da Conta:     {this.NumeroConta}       \n" +
               $"    Titular da Conta:    {this.Nome}      \n" +
               $"    CPF do Titular:      {this.Cpf}       \n" +
               $"    Saldo da Conta:      {this.Saldo}       \n" +
               $"    Data de Criação:     {this.DataDeCriacao}       \n" +
               $"<=====================================>";
    }
}
