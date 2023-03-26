using System;
using System.Threading.Channels;

namespace ArraysFuncoes.ConsoleApp
{
    internal class Program
    {
        static int[] array = { -5, 3, 4, 5, 9, -6, 10, -2, 11, 1, 2, 6, 7, 8, 0, -9 };

        static int maiorValor, menorValor, mediaValores, primeiroMaior, segundoMaior, terceiroMaior, valoresNegativos, escolha, valorParaRemover;
        
        static void MostrarMenu()
        {
            Console.Clear();
            Console.WriteLine("Escolha a ação que deseja.");
            Console.WriteLine();
            Console.WriteLine("1- Encontrar o maior valor da sequência; \r\n2- Encontrar o menor valor da sequência; \r\n3- Encontrar a média dos valores da sequência; \r\n4- Encontrar os 3 maiores valores da sequência; \r\n5- Encontrar os valores negativos da sequência; \r\n6- Mostrar na tela os todos os valores da sequência; \r\n7- Remover um item da sequência. \r\n");
            escolha = Convert.ToInt32(Console.ReadLine());
        }
        static void MostrarMensagemEscolhaInvalida()
        {
            Console.WriteLine();
            Console.WriteLine("Escolha inválida. Digite um número entre 1 e 7.");
            Console.WriteLine();
        }
        static void EncontrarMaiorValor()
        {
            Console.WriteLine();
            maiorValor = -1000;
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] > maiorValor)
                    maiorValor = array[i];
            }
            Console.WriteLine("O maior valor da sequência é: " + maiorValor);
            Console.WriteLine();
        }
        static void EncontrarMenorValor()
        {
            Console.WriteLine();
            menorValor = 1000;
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] < menorValor)
                    menorValor = array[i];
            }
            Console.WriteLine("O menor valor da sequência é: " + menorValor);
            Console.WriteLine();
        }
        static void EncontrarMediaDosValores()
        {
            Console.WriteLine();
            int numeros = 0;
            for (int i = 0; i < array.Length; i++)
            {
                numeros += array[i];
            }
            mediaValores = numeros / array.Length;

            Console.WriteLine("Média dos valores da sequência é: " + mediaValores);
            Console.WriteLine();
        }
        static void EncontrarOsTresMaioresValores()
        {
            Console.WriteLine();
            primeiroMaior = int.MinValue;
            segundoMaior = int.MinValue;
            terceiroMaior = int.MinValue;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > primeiroMaior)
                {
                    terceiroMaior = segundoMaior;
                    segundoMaior = primeiroMaior;
                    primeiroMaior = array[i];
                }
                else if (array[i] > segundoMaior)
                {
                    terceiroMaior = segundoMaior;
                    segundoMaior = array[i];
                }
                else if (array[i] > terceiroMaior)
                {
                    terceiroMaior = array[i];
                }
            }
            Console.WriteLine("Os três maiores valores da sequência são: " + primeiroMaior + ", " + segundoMaior + ", " + terceiroMaior+".");
            Console.WriteLine();
        }
        static void EncontrarValoresNegativos()
        {
            Console.WriteLine();
            int[] negativos = new int[array.Length];
            valoresNegativos = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] < 0)
                {
                    negativos[valoresNegativos] = array[i];
                    valoresNegativos++;
                }
            }
            Console.Write("Os valores negativos da sequência são: ");
            for (int i = 0; i < valoresNegativos; i++)
            {
                Console.Write(negativos[i] + " ");
            }
            Console.WriteLine();
            Console.WriteLine();
        }
        static void ImprimirValoresDaSequencia()
        {
            Console.WriteLine();
            Console.Write("Todos os valores da sequência são: ");
            for (int i = 0; i < array.Length; i++)
            {
                if (i == array.Length - 1)
                {
                    Console.Write(array[i] + ". ");
                }
                else
                {

                    Console.Write(array[i] + ", ");
                }
            }
            Console.WriteLine(); 
            Console.WriteLine();
        }
        static void RemoverUmValor()
        {
            Console.WriteLine();
            Console.WriteLine("Está é a sequência original:");
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }
            Console.WriteLine();
            Console.WriteLine();

            Console.Write("Digite o valor que deseja remover da sequência: ");
            if (int.TryParse(Console.ReadLine(), out valorParaRemover))//o tryParse puxa o convert to 32
            {
                int posicao = -1;
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] == valorParaRemover)
                    {
                        posicao = i;
                        break;
                    }
                }
                if (posicao != -1)
                {
                    Array.Copy(array, posicao + 1, array, posicao, array.Length - posicao - 1);// remove o valor 
                    Array.Resize(ref array, array.Length - 1);
                    Console.WriteLine();
                    Console.WriteLine("O valor {0} foi removido da sequência.", valorParaRemover);
                    Console.WriteLine();
                    Console.WriteLine("Sequência atualizada:");
                    for (int i = 0; i < array.Length; i++)
                    {
                        Console.Write(array[i] + " ");
                    }
                    Console.WriteLine();
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("Valor não encontrado na sequência.");
                }
            }
            else
            {
                Console.WriteLine("Valor inválido.");
            }
        }
        static bool PerguntarSeDesejaContinuar()
        {
            bool continuar;
            Console.WriteLine("Deseja realizar mais alguma ação? Caso deseje, digite \"sim\", caso contrário digite qualquer tecla para sair.");
            Console.WriteLine();
            string resposta = Console.ReadLine();
            continuar = resposta.ToLower() == "sim";
            Console.WriteLine();
            return continuar;
        }
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Atividade sobre Arrays, Funções e Programação Estruturada.");
            Console.WriteLine();
            bool continuar = true;

            do
            {
                MostrarMenu();

                if (escolha >= 1 && escolha <= 7)
                {
                    switch (escolha)
                    {
                        case 1:
                            EncontrarMaiorValor();
                            break;
                        case 2:
                            EncontrarMenorValor();
                            break;
                        case 3:
                            EncontrarMediaDosValores();
                            break;
                        case 4:
                            EncontrarOsTresMaioresValores();
                            break;
                        case 5:
                            EncontrarValoresNegativos();
                            break;
                        case 6:
                            ImprimirValoresDaSequencia();
                            break;
                        case 7:
                            RemoverUmValor();
                            break;
                    }
                }
                else
                    MostrarMensagemEscolhaInvalida();

                continuar = PerguntarSeDesejaContinuar();
            } while (continuar);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}