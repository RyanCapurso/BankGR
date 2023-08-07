
namespace BankGR.Entidades;

internal class ContaCorrente
{

    public ContaCorrente(string? nome, int agencia, int cpf, double saldo)
    {
        Nome = nome;
        Agencia = agencia;
        Cpf = cpf;
        Saldo = saldo;
    }

    public string ?Nome { get; set; }
    public int Agencia { get; set; }
    public int Cpf { get; set; }
    public double Saldo { get; set; }

    
    
    
    public override string ToString()
    {
        return $"===========================================\n" +
               $"===  Número da Agência : {this.Agencia} ===\n" +
               $"===  Saldo da Conta: {this.Saldo}       ===\n" +
               $"===  Titular da Conta: {this.Nome}      ===\n" +
               $"===  CPF do Titular  : {this.Cpf}       ===\n" +
               $"===========================================";
    }
}
