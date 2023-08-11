using BankGR.Entidades;
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
        case 5:
            ContaCorrenteModel contaEncontrada;
            int opcao1 = MenuConta.Exibir(contaEncontrada = servicos.Entrar());
            switch (opcao1)
            {
                case 1:
                    servicos.Depositar(contaEncontrada);
                    break;
                case 2:
                    servicos.Sacar();
                    break; 
                case 3:
                    servicos.Alterar();
                    break;
                case 4:
                    servicos.Excluir();
                    break;
                case 8:
                    break;
                default:
                    Console.WriteLine("Opção Invalido");
                    Thread.Sleep(500);
                    break;
            }
            break;
        case 8:
            servicos.Sair();
            executa = false;
            break;
        case 9:
            servicos.Destruir();
            break;
        default:
            Console.WriteLine("Opção Invalido");
            Thread.Sleep(500);
            break;
    }
}


