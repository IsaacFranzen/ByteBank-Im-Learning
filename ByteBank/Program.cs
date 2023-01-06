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
            Console.WriteLine("5 - Sacar uma quantia");
            Console.WriteLine("6 - Depositar uma quantia");
            Console.WriteLine("7 - Transferir uma quantia");
            Console.WriteLine("8 - Logar na conta");
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

        static void DeletarUsuario(List<string> cpfs, List<string> nomes, List<string> senhas, List<double> saldos)
        {
            Console.WriteLine("Digite o cpf da conta a ser deletada:");
            string cpfDigitado = Console.ReadLine();
            int indexParaDeletar = cpfs.FindIndex(cpf => cpf == cpfDigitado);
            Console.WriteLine($"Tem certeza que deseja excluir a conta com o cpf: {cpfDigitado}?");
            Console.WriteLine("Digite S para proseguir ou N para finalizar a operação e voltar para o menu:");
            string resposta = Console.ReadLine();

            if(resposta == "S" || resposta == "s") {
                cpfs.Remove(cpfDigitado);
                nomes.RemoveAt(indexParaDeletar);
                senhas.RemoveAt(indexParaDeletar);
                saldos.RemoveAt(indexParaDeletar);
                Console.WriteLine("Conta exlcuida com sucesso!");
            }
            else if(resposta == "N" || resposta == "n") { }
            {
                Console.WriteLine("Retornando para o menu.");
            }
        }

        static void fazerLogin(List<string> cpfs, List<string> senhas)
        {
            Console.WriteLine("Digite o seu cpf:");
            string cpfDigitado = Console.ReadLine();
            int conferirCpf = cpfs.FindIndex(cpf => cpf == cpfDigitado);
            Console.WriteLine("Digite a sua senha:");
            string senhaDigitada = Console.ReadLine();
            int conferirSenha = senhas.FindIndex(senha => senha == senhaDigitada);
            // Console.WriteLine($"{conferirSenha} --- senha digitada {senhaDigitada}");
            
            if(senhaDigitada == senhas[conferirSenha] & cpfDigitado == cpfs[conferirCpf])
            {
                Console.WriteLine("Login feito com sucesso!");
                
            }
            else
            {
                Console.WriteLine("Cpf ou senha incorretos, tentar novamente? 1 - sim  2 - não");
                int resposta = int.Parse(Console.ReadLine());
                
                if(resposta == 1)
                {
                    fazerLogin(cpfs, senhas);
                }else
                {
                    Console.WriteLine("Retornando para o menu.");
                }

            }
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

        static void MostrarTodasAsContas(List<string> cpfs, List<string> titulares, List<double> saldos)
        {
            for (int i = 0; i < cpfs.Count; i++)
            {
                MostrarConta(i, cpfs, titulares, saldos);
            }
        }

        static void Depositar(List<string> cpfs, List<string> titulares, List<double> saldos)
        {
         
                Console.WriteLine("Digite o cpf da conta para fazer o depósito:");
                string cpfDigitado = Console.ReadLine();
                int indexParaDepositar = cpfs.FindIndex(cpf => cpf == cpfDigitado);
                Console.WriteLine("Digite a quantia a ser depositada:");
                double quantiaAdepositar = double.Parse(Console.ReadLine());
                saldos[indexParaDepositar] = quantiaAdepositar;         

        }
        public static void Main(string[] args)
        {
            Console.WriteLine("Iniciando os recursos... ");
            Console.WriteLine("Recursos iniciados, por favor escolha uma opção.");

            List<string> cpfs = new List<string>();
            List<string> nomes = new List<string>();
            List<string> senhas = new List<string>();
            List<double> saldos = new List<double>();
            int verificaLogin = 0;
            

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
                        DeletarUsuario(cpfs, nomes, senhas, saldos);
                            break;
                    case 3:
                        MostrarTodasAsContas(cpfs, nomes, saldos);
                        break;
                    case 4:
                        MostrarUsuario(cpfs, nomes, saldos);
                        break;
                    case 5:
                        Console.WriteLine("testando, escolheu 6");
                        break;
                    case 6:
                        Depositar(cpfs, nomes, saldos);
                        break;
                    case 7:
                        Console.WriteLine("testando, escolheu 8");
                        break;
                    case 8:
                        fazerLogin(cpfs, senhas); break;
                }

                Console.WriteLine(".....................");

            } while (option != 0);


        }
    }
}