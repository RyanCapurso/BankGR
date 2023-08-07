using BankGR.Entidades;
using BankGR.Servicos;

namespace BankGR.Telas;

public class Menu
{
    public void ExibirMenu()
    {
        Console.WriteLine("===================================");
        Console.WriteLine("===                             ===");
        Console.WriteLine("===  Seja Bem vindo ao BancoGR  ===");
        Console.WriteLine("===  Selecione uma opção        ===");
        Console.WriteLine("===                             ===");
        Console.WriteLine("===  1 - Cadastrar Conta        ===");
        Console.WriteLine("===  2 - Listar Contas          ===");
        Console.WriteLine("===  3 - Pesquisar Contas       ===");
        Console.WriteLine("===  4 - Excluir Conta          ===");
        Console.WriteLine("===  5 - Sair                   ===");
        Console.WriteLine("===                             ===");
        Console.WriteLine("===================================");

        Console.Write("Opção Escolhida: ");

        int opcao = int.Parse(Console.ReadLine() ?? "0"); //  "??" Estudar
        BankGRServicos servicos = new BankGRServicos();
        switch (opcao)
        {
            case 1:
                Console.WriteLine("Cadastrar Conta");
                servicos.CadastrarContaCorrente();
                break;
            case 2:
                Console.WriteLine("Listar Contas");
                servicos.ListarContaCorrente();

                break;
            case 3:
                Console.WriteLine("Pesquisar Contas");
                break;
            case 4:
                Console.WriteLine("Excluir Conta");
                break;
            case 5:
                Console.WriteLine("Sair");
                break;
            default:
                Console.WriteLine("Opção Invalida");
                break;
        }
    }
}
