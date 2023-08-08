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
        Console.WriteLine("===  4 - Excluir Conta          ===");
        Console.WriteLine("===  5 - Sair                   ===");
        Console.WriteLine("===                             ===");
        Console.WriteLine("===================================");

        Console.Write("Opção Escolhida: ");

        return int.Parse(Console.ReadLine() ?? "0");
    }
}
