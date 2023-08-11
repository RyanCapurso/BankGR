using BankGR.Entidades;
using BankGR.Repositorios;
using BankGR.ValidacoesLibrary;


namespace BankGR.Servicos
{
    
    public class BankGRServicos
    {
        Repositorio<ContaCorrenteModel> repositorio = new Repositorio<ContaCorrenteModel>();

        public void Excluir()
        {
            bool executar = true;
            do
            {
                Console.Clear();
                Console.WriteLine("=============================");
                Console.WriteLine("===                       ===");
                Console.WriteLine("===     Excluir Contas    ===");
                Console.WriteLine("===                       ===");
                Console.WriteLine("=============================");

                Console.Write("Informe o N° da Conta: ");
                string numeroDaConta = Console.ReadLine() ?? "";
                try
                {
                    ContaCorrenteModel? conta = repositorio.ObterPorItem(c => c.NumeroConta.Equals(numeroDaConta));
                    if (conta != null)
                    {
                        Console.WriteLine(conta.ToString()); 
                        Console.Write("  Deseja realmente excluir está conta? Y ou N: ");
                        string escolha = Console.ReadLine()?.ToLower() ?? "n";
                        if (escolha == "y")
                        {
                            repositorio.Excluir(conta);
                            Console.WriteLine("\n...  conta removida!  ...");
                        }
                        else
                        {
                            Console.WriteLine("...  Operação Cancelada  ...");
                            Thread.Sleep(1000);
                            return;
                        }
                    }
                    else
                    {
                        Console.WriteLine("...  Conta para remoção não encontrada  ...");
                    }
                }
                catch (InvalidOperationException)
                {
                    Console.WriteLine("Erro ao excluir conta: Conta não encontrada.");
                }
                catch (Exception e)
                {
                    Console.WriteLine("Erro ao excluir conta: " + e.Message);
                }
                Console.WriteLine("\nDeseja Excluir mais alguma conta? Y ou N: ");
                string opcao = Console.ReadLine()?.ToLower() ?? "n";
                executar = opcao == "y";
            } while (executar);
        }
        public void Cadastrar()
        {
            bool executar = true;
            do
            {
                try
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
                    conta.Nome = Console.ReadLine() ?? "0";

                    Console.Write("Agencia: ");
                    conta.Agencia = Console.ReadLine() ?? "0000-X";

                    Random numRandom = new Random();
                    conta.NumeroConta = numRandom.Next(100000, 999999).ToString();
                    Console.WriteLine($"Número da conta [NOVA] : {conta.NumeroConta}");

                    Console.Write("CPF: ");
                    try
                    {
                        string? _cpf = Console.ReadLine() ?? "00000000000";

                        if (Validacoes.ValidaCPF(_cpf))
                        {
                            conta.Cpf = _cpf;
                        }
                        else
                        {
                            Console.WriteLine("...  CPF INVALIDO  ...");
                            return;
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Erro: " + e.Message);
                    }
                   
                    Console.Write("Saldo Inicial: ");
                    double saldo;
                    if (double.TryParse(Console.ReadLine(), out saldo))
                    {
                        conta.Saldo = saldo;
                    }
                    else
                    {
                        Console.WriteLine("Valor de saldo inválido. O saldo será definido como 0.");
                        conta.Saldo = 0;
                    }
                    Console.WriteLine("\n... Conta Cadastrada com Sucesso ...\n");
                    repositorio.Adicionar(conta);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Erro ao cadastrar conta: Valor de saldo inválido.");
                }
                catch (Exception e)
                {
                    Console.WriteLine("Erro ao cadastrar conta: " + e.Message);
                }
                Console.WriteLine("Deseja Adicionar uma nova conta? Y ou N: ");
                string opcao = Console.ReadLine()?.ToLower() ?? "n";
                executar = opcao == "y";
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
        public void PesquisarCpf()
        {
            Console.Write("Digite o CPF da conta: ");
            try
            {
                string cpf = Console.ReadLine() ?? string.Empty;
                ContaCorrenteModel? contaEncontrada = repositorio.ObterPorItem(conta => conta.Cpf == cpf);

                if (contaEncontrada != null)
                {
                    Console.WriteLine("Conta encontrada:");
                    Console.WriteLine(contaEncontrada.ToString());
                }
                else
                {
                    Console.WriteLine("...  Nenhuma Conta foi encontrada  ...");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro: " + e);
            }
            Console.WriteLine("Pressione qualquer tecla para voltar ao menu...");
            Console.ReadKey();
        }
        public void PesquisarAgencia()
        {
            Console.Write("Digite a agencia da conta: ");
            try
            {
                string agencia = Console.ReadLine() ?? string.Empty;
                ContaCorrenteModel? contaEncontrada = repositorio.ObterPorItem(conta => conta.Agencia == agencia);

                if (contaEncontrada != null)
                {
                    Console.WriteLine("Conta encontrada:");
                    Console.WriteLine(contaEncontrada.ToString());
                }
                else
                {
                    Console.WriteLine("...  Nenhuma Conta foi encontrada  ...");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro: " + e);
            }
            Console.WriteLine("Pressione qualquer tecla para voltar ao menu...");
            Console.ReadKey();
        }
        public void PesquisarNumeroConta()
        {
            Console.Write("Digite o N° da conta: ");
            try
            {
                Console.WriteLine();
                string numeroConta = Console.ReadLine() ?? string.Empty;
                ContaCorrenteModel? contaEncontrada = repositorio.ObterPorItem(conta => conta.NumeroConta == numeroConta);
                if (contaEncontrada != null)
                {
                    Console.WriteLine("Conta encontrada:");
                    Console.WriteLine(contaEncontrada.ToString());
                }
                else
                {
                    Console.WriteLine("...  Nenhuma Conta foi encontrada  ...");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro: " + e);
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
            Console.WriteLine("\n(1) CPF (2) AGENCIA (3) CONTA\n");
            Console.Write("Qual opção Deseja?: ");
            int opcao = 0;

            int.TryParse(Console.ReadLine(), out opcao);

            switch (opcao)
            {
                case 1:
                    PesquisarCpf();
                    break;
                case 2:
                    PesquisarAgencia();
                    break;
                case 3:
                    PesquisarNumeroConta();
                    break;
                default:
                    Console.WriteLine("Digite uma opção válida");
                    break;
            }
        }
        public void Alterar()
        {
            Console.Clear();
            Console.WriteLine("=============================");
            Console.WriteLine("===                       ===");
            Console.WriteLine("===   Alterar Dados       ===");
            Console.WriteLine("===                       ===");
            Console.WriteLine("=============================");
            Console.Write("Informe o N° da Conta: ");
            string numeroDaConta = Console.ReadLine() ?? "";
            try
            {
                var conta = repositorio.ObterPorItem(c => c.NumeroConta.Equals(numeroDaConta));
                if (conta != null)
                {
                    Console.WriteLine("Conta encontrada:");
                    Console.WriteLine(conta.ToString());

                    Console.WriteLine("\nEscolha o campo a ser alterado:");
                    Console.WriteLine("1 - Nome");
                    Console.WriteLine("2 - Agência");
                    Console.WriteLine("3 - CPF");
                    Console.WriteLine("4 - Saldo");
                    Console.Write("Opção: ");
                    int opcaoCampo = int.Parse(Console.ReadLine() ?? "0");
                    switch (opcaoCampo)
                    {
                        case 1:
                            Console.Write("Novo Nome: ");
                            conta.Nome = Console.ReadLine() ?? "";
                            break;
                        case 2:
                            Console.Write("Nova Agência: ");
                            conta.Agencia = Console.ReadLine() ?? "";
                            break;
                        case 3:
                            Console.Write("Novo CPF: ");
                            conta.Cpf = Console.ReadLine() ?? "";
                            break;
                        case 4:
                            Console.Write("Novo Saldo: ");
                            if (double.TryParse(Console.ReadLine(), out double novoSaldo))
                            {
                                conta.Saldo = novoSaldo;
                            }
                            else
                            {
                                Console.WriteLine("Valor de saldo inválido. O saldo não será alterado.");
                            }
                            break;
                        default:
                            Console.WriteLine("Opção inválida.");
                            break;
                    }
                    Console.WriteLine("\nAlterações realizadas:");
                    Console.WriteLine(conta.ToString());
                }
                else
                {
                    Console.WriteLine("... Conta não encontrada ...");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro ao alterar conta: " + e.Message);
            }
            Console.WriteLine("\nPressione qualquer tecla para voltar ao menu...");
            Console.ReadKey();
        }
        internal void Sair()
        {
            Console.Clear();
            Console.WriteLine("...  Obrigado por utilizar o BankGR  ...");
            Environment.Exit(0);
        }
        internal void Destruir()
        {
            repositorio.DeletarLista();
        }
    }
}