using BankGR.Menu;
using BankGR.Servicos;

BankGRServicos servicos = new BankGRServicos();

bool executa = true;
while (executa)
{
    int opcao = Menu.Exibir();

    switch(opcao)
    {
        case 1:
            servicos.Cadastrar();
            break;
        case 2:
            servicos.Listar();
            break;
        case 3:
            servicos.Pesquisar();
            break;
        case 4:
            servicos.Excluir();
            break;
        case 5:
            servicos.Sair();
            executa = false;
            break;
    }
}


