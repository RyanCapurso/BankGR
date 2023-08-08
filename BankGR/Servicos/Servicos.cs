using BankGR.Entidades;
using BankGR.Repositorios;
using System.ComponentModel;

namespace BankGR.Servicos;

public class BankGRServicos
{
    Repositorio<ContaCorrenteModel> repositorio = new();
    /*private void Excluir()
    {

        bool validador = false;
        do
        {
            Console.Clear();
            Console.WriteLine("=============================");
            Console.WriteLine("===                       ===");
            Console.WriteLine("===     Excluir Contas    ===");
            Console.WriteLine("===                       ===");
            Console.WriteLine("=============================");

            Console.WriteLine("Informe o CPF da Conta: ");
            string cpfDaConta = Console.ReadLine() ?? "000000000000";
            ContaCorrenteModel? conta = null;

            foreach (var item in _listaDeContas)
            {
                if (item.Cpf.Equals(cpfDaConta))
                {
                    conta = item;
                }
            }
            if (conta != null)
            {
                _listaDeContas.Remove(conta);
                Console.WriteLine("...  Conta Removida!  ...");
            }
            else
            {
                Console.WriteLine("...  Conta para remoção não encontrada  ...");
            }

            Thread.Sleep(1000);
            Console.WriteLine("Deseja Excluir mais alguma conta? Y ou N: ");
            string opcao = Console.ReadLine()?.ToLower() ?? "n";
            if (opcao == "y")
            {
                validador = true;
            }
            else if (opcao == "n")
            {
                validador = false;
            }
        } while (validador == true);
    }*/
    public void CadastrarContaCorrente()
    {

        Console.Clear();
        Console.WriteLine("============================");
        Console.WriteLine("===                      ===");
        Console.WriteLine("===  Cadastro de Contas  ===");
        Console.WriteLine("===                      ===");
        Console.WriteLine("============================");
        Console.WriteLine("\nDigite as Seguintes Informações\n");

        ContaCorrenteModel conta = new ContaCorrenteModel();
        Console.Write("Nome: ");
        string nome = Console.ReadLine() ?? "0";
        conta.Nome = nome;

        Console.Write("Agencia: ");
        string agencia = Console.ReadLine() ?? "0000-X";
        conta.Agencia = agencia;

        Console.Write("CPF: ");
        string cpf = Console.ReadLine() ?? "00000000000";
        conta.Cpf = cpf;

        Console.Write("Saldo Inicial: ");
        double saldo = double.Parse(Console.ReadLine() ?? "0.00");
        conta.Saldo = saldo;

        Thread.Sleep(1000);
        Console.WriteLine("\n... Conta Cadastrada com Sucesso ...\n");

        repositorio.Adicionar(conta);

    }
    
    public void ListarContaCorrente()
    {
        Console.Clear();
        Console.WriteLine("============================");
        Console.WriteLine("===                      ===");
        Console.WriteLine("===  Listagem de Contas  ===");
        Console.WriteLine("===                      ===");
        Console.WriteLine("============================");

        
        
        foreach (ContaCorrenteModel item in repositorio.ObterTodos())
        {
            Console.WriteLine(item.ToString());
        }

        Console.WriteLine("Pressione qualquer tecla para voltar ao menu...");
        Console.ReadKey(); // Aguarda uma tecla ser pressionada antes de voltar ao menu
    }




}
