using BankGR.Entidades;
using BankGR.Repositorios;

namespace BankGR.Servicos;

public class BankGRServicos
{
    Repositorio<ContaCorrenteModel> repositorio = new();
    public void Excluir()
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

            Console.WriteLine("Informe a agencia da Conta: ");
            string agenciaDaConta = Console.ReadLine() ?? "";
            ContaCorrenteModel? conta = null;

            foreach (var item in repositorio.ObterTodos())
            {
                if (item.Agencia.Equals(agenciaDaConta))
                {
                    conta = item;
                }
            }
            if (conta != null)
            {
                repositorio.Excluir(conta);
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
    public void Cadastrar()
    {
        bool executar = false;
        do
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

            Console.WriteLine("Deseja Adicionar uma nova conta? Y ou N: ");
            string opcao = Console.ReadLine()!.ToLower() ?? "n";
            if (opcao == "y")
            {
                executar = true;
            }
            else if (opcao == "n")
            {
                executar = false;
            }
        } while (executar == true);

    }
    public void Listar()
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
        Console.ReadKey();
    }
    /*public void PesquisarCpf()
    {
        Console.Clear();
        Console.WriteLine("============================");
        Console.WriteLine("=== Pesquisa de Contas ===");
        Console.WriteLine("============================");
        Console.Write("Digite o CPF da conta: ");

        string cpf = Console.ReadLine() ?? string.Empty;

        ContaCorrenteModel? contaEncontrada = repositorio.ObterPorId(new ContaCorrenteModel{ Cpf = cpf});
        
        if (contaEncontrada?.Cpf != null )
        {
            Console.WriteLine("Conta encontrada:");
            Console.WriteLine(contaEncontrada.ToString());
            Console.ReadKey();
        }
        else
        {
            Console.WriteLine("...  Nenhuma Conta foi encontrada  ...");
        }
        Console.WriteLine("Pressione qualquer tecla para voltar ao menu...");
        Console.ReadKey();
    }*/
    public void PesquisarCpf()
    {
        Console.Clear();
        Console.WriteLine("============================");
        Console.WriteLine("=== Pesquisa de Contas ===");
        Console.WriteLine("============================");
        Console.Write("Digite o CPF da conta: ");

        string cpf = Console.ReadLine() ?? string.Empty;

        ContaCorrenteModel? contaEncontrada = repositorio.ObterPorId(conta => conta.Cpf == cpf);

        if (contaEncontrada != null)
        {
            Console.WriteLine("Conta encontrada:");
            Console.WriteLine(contaEncontrada.ToString());
        }
        else
        {
            Console.WriteLine("...  Nenhuma Conta foi encontrada  ...");
        }

        Console.WriteLine("Pressione qualquer tecla para voltar ao menu...");
        Console.ReadKey();
    }
    public void Pesquisar()
    {
        Console.Clear();
        Console.WriteLine("============================");
        Console.WriteLine("===                      ===");
        Console.WriteLine("===  Pesquisa de Contas  ===");
        Console.WriteLine("===                      ===");
        Console.WriteLine("============================");
        Console.WriteLine("\n(1) CPF (2) AGENCIA (3) Nome\n");

        Console.Write("Qual opção Deseja?: ");
        int opcao = int.Parse(Console.ReadLine()!);
        switch(opcao)
        {
            case 1:
                PesquisarCpf();
                break;
        }
    }

    internal void Sair()
    {
        Console.Clear();
        Console.WriteLine("...  Obrigado por utilizar o BankGR  ...");
        Environment.Exit(0);
    }
}

