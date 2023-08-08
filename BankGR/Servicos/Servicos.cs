using BankGR.Entidades;
using BankGR.Repositorios;

namespace BankGR.Servicos;

public class BankGRServicos
{
    private void Excluir()
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
    }

    List<ContaCorrenteModel> _listaDeContas = new() { new ContaCorrenteModel(0,"Ryan","874","7777",5000),
        new ContaCorrenteModel(1,"Luiz", "789", "99999999", 50068),
        new ContaCorrenteModel()
        {
            Nome = "Osiel",
            Saldo = 90.0,
            DataCadastro = DateTime.Now,
            Cpf = "11111111111",
            Agencia = "8765"
        }};
    public ContaCorrenteModel CadastrarContaCorrente()
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

        return conta;
    }
    public void ListarContaCorrente()
    {
        Console.Clear();
        Console.WriteLine("============================");
        Console.WriteLine("===                      ===");
        Console.WriteLine("===  Listagem de Contas  ===");
        Console.WriteLine("===                      ===");
        Console.WriteLine("============================");

        if (_listaDeContas.Count == 0)
        {
            Console.WriteLine("... No momento o sistema não possui contas ...");
            Console.ReadKey();
            return;
        }
        foreach (ContaCorrenteModel item in _listaDeContas)
        {
            Console.WriteLine(item.ToString());
            Console.ReadKey();
        }
    }



}
