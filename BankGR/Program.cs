using BankGR.Entidades;
using BankGR.Menu;
using BankGR.Servicos;

BankGRServicos servicos = new BankGRServicos();

bool executa = true;
bool executa1 = true;
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
            do
            {
                switch (opcao1)
                {
                    case 1:
                        servicos.Depositar(contaEncontrada);
                        break;
                    case 2:
                        servicos.Sacar(contaEncontrada);
                        break;
                    case 3:
                        servicos.Alterar(contaEncontrada);
                        break;
                    case 4:
                        servicos.Excluir(contaEncontrada);
                        break;
                    case 8:
                        executa1 = false;
                        break;
                    default:
                        Console.WriteLine("Opção Invalido");
                        Thread.Sleep(500);
                        break;
                }
                if (executa1 != false) 
                {
                    opcao1 = MenuConta.Exibir(contaEncontrada);
                }
            }
            while (executa1);
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


