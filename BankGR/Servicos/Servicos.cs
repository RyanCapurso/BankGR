using BankGR.Entidades;
using BankGR.Repositorios;

namespace BankGR.Servicos;

public class BankGRServicos
{
    Repositorio<ContaCorrenteModel> repositorio = new();

    private void ExcluirContaCorrente()
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
            int cpfDaConta = int.Parse(Console.ReadLine() ?? "");
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
        ExibirMenu();
    }

    private void PesquisarContaCorrente()
    {
        Console.Clear();
        Console.WriteLine("============================");
        Console.WriteLine("===                      ===");
        Console.WriteLine("===  Pesquisa de Contas  ===");
        Console.WriteLine("===                      ===");
        Console.WriteLine("============================\n");
        Console.WriteLine("1 -- CPF      2 -- NOME      3 -- AGENCIA");
        Console.Write("Deseja qual método de Pesquisa? ");

        int opcao = int.Parse(Console.ReadLine() ?? "0");

        switch (opcao)
        {
            case 1:
                Console.Write("Digite o CPF: ");
                string? cpfDaConta = Console.ReadLine() ?? "";

                if (cpfDaConta != null)
                {
                    var obj = _listaDeContas.Where(i => i.Cpf.Equals(cpfDaConta)).FirstOrDefault();

                    if (obj is not null)
                        Console.WriteLine(obj);
                    else
                        Console.WriteLine("Nao encontrado");
                }

                foreach (var obj in _listaDeContas.Where(i => i.Cpf.Equals(cpfDaConta)))
                {
                    Console.WriteLine(obj);
                }

                //PesquisarContaCorrentePorCPF(cpfDaConta);
                break; 
            case 2:
                break; 
            case 3:
                break;
            default:
                break;
        }
    }

    /*private ContaCorrente PesquisarContaCorrentePorCPF(int cpfDaContaCorrente)
    {
        return _listaDeContas.Where(Cpf => cpf.Cpf == cpfDaContaCorrente);
    }*/

    List<ContaCorrenteModel> _listaDeContas = new() { new ContaCorrenteModel(0,"Ryan",458,"7777",5000), 
        new ContaCorrenteModel(1,"Luiz", 789, "99999999", 50068),
        new ContaCorrenteModel()
        {
            Nome = "Osiel",
            Saldo = 90.0,
            DataCadastro = DateTime.Now,
            Cpf = "11111111111",
            Agencia = 8765
        }};
    public void CadastrarContaCorrente()
    {
        bool Validador = false;
        do
        {
            Console.Clear();
            Console.WriteLine("============================");
            Console.WriteLine("===                      ===");
            Console.WriteLine("===  Cadastro de Contas  ===");
            Console.WriteLine("===                      ===");
            Console.WriteLine("============================");
            Console.WriteLine("\nDigite as Seguintes Informações\n");
            ContaCorrenteModel conta = new ContaCorrente("", 0, 0, 0);
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

            repositorio.Adicionar(conta);
            _listaDeContas.Add(conta);
            Thread.Sleep(1000);
            Console.WriteLine("\n... Conta Cadastrada com Sucesso ...\n");

            Console.Write("Deseja Cadastrar outra conta? Y ou N : ");

            string opcao = Console.ReadLine() ?? "N";
            if (opcao == "y") 
            {
                Validador = true; 
            }
            else if (opcao == "n")
            {
                
                Validador = false;
            }
        } while (Validador == true);
        ExibirMenu();
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
        ExibirMenu();
    }



}
