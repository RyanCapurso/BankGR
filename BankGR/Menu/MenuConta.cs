using BankGR.Entidades;

namespace BankGR.Menu;

internal class MenuConta
{
    
    public static int Exibir(ContaCorrenteModel cliente)
    {
        if (cliente == null) return 8;
        Console.Clear();
        Console.WriteLine("====================================");
        Console.WriteLine("===                              ===");
        Console.WriteLine($"=== Seja Bem vindo ===");
        Console.WriteLine("===  Selecione uma opção         ===");
        Console.WriteLine("===                              ===");             
        Console.WriteLine("===  1 - Depositos               ===");
        Console.WriteLine("===  2 - Saques                  ===");
        Console.WriteLine("===  x - Transferir              ===");
        Console.WriteLine("===                              ===");
        Console.WriteLine("===  3 - Alterar Dados           ===");
        Console.WriteLine("===  4 - Excluir Conta           ===");
        Console.WriteLine("===                              ===");
        Console.WriteLine("===  8 - Voltar                  ===");
        Console.WriteLine("====================================");

        Console.Write("Opção Escolhida: ");
        if (int.TryParse(Console.ReadLine(), out int opcao))
        {
            return opcao;
        }
        else
        {
            Console.WriteLine("Opção inválida. Opção será definida como 0.");
            Console.ReadKey();
            return 0;
        }
    }
}

