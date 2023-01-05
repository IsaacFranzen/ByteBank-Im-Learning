using System;

namespace byteBankProject
{
    public class Program
    {
        static void MenuOptions()
        {
            Console.WriteLine("1 - Adicionar um novo usuário");
            Console.WriteLine("2 - Deletar um usuário");
            Console.WriteLine("3 - Mostrar todas as contas registradas");
            Console.WriteLine("4 - Mostrar detalhes de um usuário");
            Console.WriteLine("5 - Quantia armazenada no banco");
            Console.WriteLine("6 - Sacar uma quantia");
            Console.WriteLine("7 - Depositar uma quantia");
            Console.WriteLine("8 - Transferir uma quantia");
            Console.WriteLine("0 - Sair do programa");
            Console.Write("Digite uma opção: ");
        }

        static void RegistrarUsuario(List<string> cpfs, List<string> nomes, List<string> senhas, List<double> saldos)
        {
            Console.WriteLine("Primeiramente, digite seu cpf:");
            cpfs.Add(Console.ReadLine());
            Console.WriteLine("Digite seu nome completo:");
            nomes.Add(Console.ReadLine());
            Console.WriteLine("Crie uma senha para acesso:");
            senhas.Add(Console.ReadLine());
            saldos.Add(0.0);

        }

        static void MostrarUsuario(List<string> cpfs, List<string> nomes, List<double> saldos)
        {
            Console.WriteLine("Digite o cpf da conta para mais detalhes:");
            string cpfDigitado = Console.ReadLine();
            int indexParaMostrar = cpfs.FindIndex(cpf => cpf == cpfDigitado);

            MostrarConta(indexParaMostrar, cpfs, nomes, saldos);
        }

        static void MostrarConta(int i, List<string> cpfs, List<string> nomes, List<double> saldos)
        {
            Console.WriteLine($"CPF = {cpfs[i]} | Nome = {nomes[i]} | Saldo = R${saldos[i]:F2}");
        }
        public static void Main(string[] args)
        {
            Console.WriteLine("Iniciando os recursos... ");
            Console.WriteLine("Recursos iniciados, por favor escolha uma opção.");

            List<string> cpfs = new List<string>();
            List<string> nomes = new List<string>();
            List<string> senhas = new List<string>();
            List<double> saldos = new List<double>();
            

            int option;

            do
            {
                MenuOptions();
                option = int.Parse(Console.ReadLine());

                Console.WriteLine(".....................");

                // testando o Do/While e o Switch/Case

                switch (option)
                {
                    case 0:
                        Console.WriteLine("Estou encerrando o programa...");
                        break;
                    case 1:
                        RegistrarUsuario(cpfs, nomes, senhas, saldos);
                        break;
                    case 2:
                        Console.WriteLine("testando, escolheu 2");                        
                            break;
                    case 3:
                        Console.WriteLine("testando, escolheu 3");
                        break;
                    case 4:
                        MostrarUsuario(cpfs, nomes, saldos);
                        break;
                    case 5:
                        Console.WriteLine("testando, escolheu 5");
                        break;
                    case 6:
                        Console.WriteLine("testando, escolheu 6");
                        break;
                    case 7:
                        Console.WriteLine("testando, escolheu 7");
                        break;
                    case 8:
                        Console.WriteLine("testando, escolheu 8");
                        break;
                }

                Console.WriteLine(".....................");

            } while (option != 0);


        }
    }
}