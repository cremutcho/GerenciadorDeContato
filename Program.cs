using System;

namespace GerenciadorContatosApp
{
    class Program
    {
        static void Main(string[] args)
        {
            GerenciadorDeContatos gerenciador = new GerenciadorDeContatos();
            int opcao;

            do
            {
                Console.WriteLine("\n--- Gerenciador de Contatos ---");
                Console.WriteLine("1. Adicionar Contato");
                Console.WriteLine("2. Listar Contatos");
                Console.WriteLine("3. Remover Contato");
                Console.WriteLine("4. Buscar Contato");
                Console.WriteLine("5. Sair");
                Console.Write("Escolha uma opção: ");
                
                if (!int.TryParse(Console.ReadLine(), out opcao))
                {
                    Console.WriteLine("Opção inválida. Digite um número.");
                    continue;
                }

                switch (opcao)
                {
                    case 1:
                        Console.Write("Nome: ");
                        string nome = Console.ReadLine();
                        Console.Write("Email: ");
                        string email = Console.ReadLine();
                        Console.Write("Telefone: ");
                        string telefone = Console.ReadLine();

                        Contato novoContato = new Contato(nome, email, telefone);
                        gerenciador.AdicionarContato(novoContato);
                        break;

                    case 2:
                        gerenciador.ListarContatos();
                        break;

                    case 3:
                        Console.Write("Digite o nome do contato que deseja remover: ");
                        string nomeRemover = Console.ReadLine();
                        gerenciador.RemoverContato(nomeRemover);
                        break;

                    case 4:
                        Console.Write("Digite o nome ou parte do nome para buscar: ");
                        string nomeBuscar = Console.ReadLine();
                        gerenciador.BuscarContato(nomeBuscar);
                        break;

                    case 5:
                        Console.WriteLine("Saindo...");
                        break;

                    default:
                        Console.WriteLine("Opção inválida.");
                        break;
                }
            } while (opcao != 5);
        }
    }
}
