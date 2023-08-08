using BankGR.Menu;
using BankGR.Servicos;

BankGRServicos servicos = new BankGRServicos();

bool executa = true;
while (executa)
{
    int opcao = Menu.Exibir();

    switch(opcao)
    {
        case 0:
            break;
        
        case 1:
            break;

        case 5:
            Console.Clear();
            Console.WriteLine("...  Obrigado por utilizar o BankGR  ...");
            Environment.Exit(0);
            executa = false;
            break;
    }
}


