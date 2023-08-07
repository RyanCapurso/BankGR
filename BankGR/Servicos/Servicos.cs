using BankGR.Entidades;
using BankGR.Telas;


namespace BankGR.Servicos;

public class BankGRServicos
{
    Menu menu = new Menu();
    List<ContaCorrente> _listaDeContas = new();
    public void CadastrarContaCorrente()
    {

        Console.WriteLine("Digite as Seguintes Informações");
        ContaCorrente conta = new ContaCorrente("",0,0,0);
        Console.Write("Nome: ");
        string _nome = Console.ReadLine() ?? "0";
        conta.Nome = _nome;


        Console.Write("Agencia: ");
        int _agencia = int.Parse(Console.ReadLine()!);
        conta.Agencia = _agencia;

        Console.Write("CPF: ");
        int _cpf = int.Parse(Console.ReadLine()!);
        conta.Cpf = _cpf;


        Console.Write("Saldo Inicial: ");
        int _saldo = int.Parse(Console.ReadLine()!);
        conta.Saldo = _saldo;

        _listaDeContas.Add(conta);

        Console.WriteLine($"Total De contas: {_listaDeContas.Count}");

        foreach (ContaCorrente item in _listaDeContas)
        {
            Console.WriteLine(item);
        }
        // Nesse trecho _listaDeContas tem 1 conta Corrente Cadastrada
        Console.WriteLine("... Conta Cadastrada com Sucesso ...");
        Thread.Sleep(1000);
        Console.Clear();
        menu.ExibirMenu();

    }
    public void ListarContaCorrente()
    {
        // Nesse trecho _listaDeContas não tem nenhuma conta Cadastrada e cai no if
        if (_listaDeContas.Count == 0)
        {
            Console.WriteLine("... No momento o sistema não possui contas ...");
            Console.ReadKey();
            return;
        }
        foreach (ContaCorrente item in _listaDeContas)
        {
            Console.WriteLine(item.ToString());
            Console.ReadKey();
        }
        // menu.ExibirMenu();
    }
}
