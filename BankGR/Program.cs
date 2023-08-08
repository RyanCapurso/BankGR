using BankGR.Entidades;
using BankGR.Menu;
using BankGR.Repositorios;
using BankGR.Servicos;

Repositorio<ContaCorrenteModel> repositorio = new();
BankGRServicos servicos = new BankGRServicos();

bool executa = true;
while (executa)
{
    int opcao = Menu.Exibir();

    switch(opcao)
    {
        case 1:
            repositorio.Adicionar(servicos.CadastrarContaCorrente());
            break;
        
        case 2:
            repositorio.ObterTodos();
            break;

        case 5:
            Console.Clear();
            Console.WriteLine("...  Obrigado por utilizar o BankGR  ...");
            Environment.Exit(0);
            executa = false;
            break;
    }
}


