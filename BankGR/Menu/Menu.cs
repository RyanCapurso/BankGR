namespace BankGR.Menu;

internal class Menu
{
    public static int Exibir()
    {
        Console.Clear();
        Console.WriteLine("===================================");
        Console.WriteLine("===                             ===");
        Console.WriteLine("===  Seja Bem vindo ao BancoGR  ===");
        Console.WriteLine("===  Selecione uma opção        ===");
        Console.WriteLine("===                             ===");
        Console.WriteLine("===  1 - Cadastrar Conta        ===");
        Console.WriteLine("===  2 - Listar Contas          ===");
        Console.WriteLine("===  3 - Pesquisar Contas       ===");
        Console.WriteLine("===                             ===");
        Console.WriteLine("===  5 - Acessar Conta          ===");
        Console.WriteLine("===                             ===");
        Console.WriteLine("===  8 - Sair                   ===");
        Console.WriteLine("===  9 - Destruir Contas        ===");
        Console.WriteLine("===================================");

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
