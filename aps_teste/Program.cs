using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace aps_teste
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            float[] encript, key2, descript;  // --> vetores para receber valores de criptografia e descriptografia
            encript = new float[1000];  // --> declarar os pesos dos vetores
            descript = new float[1000];// --> declarar os pesos dos vetores
            key2 = new float[36];  // --> declarar os pesos dos vetores, key2, criptografar cequencia de texto
            char[] palav = new char[1000]; // --> Recebe o texto digitado pelo usuário
            char cond; // --> definido para condição de sim ou não, criptografar ou não criptografar
            int i, n = 0; // --> i definido para condições de repetições, n definido para contagem de 
                          // caracteres do vetor palav

            Console.WriteLine("\t\t\t---------- Criptografia ----------");

            Console.WriteLine("\nDigite um texto: ");

            for (i = 0; i < 1000; ++i)
            {
                palav[i] = Convert.ToChar(Console.ReadKey().KeyChar); //         >>> Ler o Texto digitado <<<
                n += 1;                                               //  le cada caracter digitado individualmente
                if (palav[i] == '\n')                                 //  e armazena no vetor palav, enquanto faz a  
                {                                                     //  contagem do ciclo que cerá utilizado como
                    i = 1000;                                         //  quantidade de letras no array palav, "n"
                }
            }
            n -= 1;  // n -1 pois o ultimo caracter da palav '\n' será ignorada na contagem

            encript = algc(palav,n); // Recebimento do metodo algc para o vetor encript, algoritmo de criptografia
            key2 = keys(); // Recebimento do metodo Keys para o vetor Key2, cujo o valor é definido para esconder a
                               // sequência do texto Digitado pelo usuário

            Console.WriteLine("\nTexto criptografado ....  ");
            Console.WriteLine("\n");
            for (i = 0; i < n; ++i)   //   >>> Repetição para escrever na tela <<<
            {                                                       
                Console.Write(Convert.ToChar(Convert.ToInt32(encript[i])));  
                Console.Write(Convert.ToChar(Convert.ToInt32(key2[i]))); // Utilizado para complementar o texto criptografado
            }
            if (n < 8)   // Condição para textos pequenos
            {
                for (i = 0; i < 36; ++i)
                {
                    Console.Write(Convert.ToChar(Convert.ToInt32(key2[i] += n))); // O texto anterior será complementado
                }                                                                 // com o Key2 somado pelo numero de 
                for (i = 0; i < 36; ++i){                                         // caracteres presentes no texto
                    key2[i] -= n; // empedir erro para se caso o texto ser menor que 8 caracteres
                }
            }
            Console.WriteLine("\n===============================================");

            Console.WriteLine("\nDeseja descriptografar? ... "); 
            Console.WriteLine("Se sim (s), se não (n)");
            cond = Convert.ToChar(Console.ReadLine());
            Console.WriteLine("\n");

            if (cond == 's')        // >>> Condição para descriptografar <<<
            {
                descript = algd(encript, n, key2); // Recebimento do metodo algd, algoritmo de descriptografia

                for (i = 0; i < n; ++i){
                    Console.Write(Convert.ToChar(Convert.ToInt32(descript[i])));   // escrever o resultado na tela
                }
            }

            Console.WriteLine("\n====================================");

            Console.ReadKey();
        }

        private static float[] ASC(char[] palava, int n) // ** METODO DE CONVERSÃO E DEFINIÇÃO DA TABELA ASCII **
        {
            int i, s=0; // Utilizado para condição
            int[] ASCII = new int[256]; // Array que irá receber os valores da tabela ASCII
            float[] conver = new float[n];


            for (i = 0; i <= 255; ++i)  //       ## Ciclo de repetição ##
            {                           //  Repetição para que o vetor receba todos
                ASCII[i] = i;           //  os valores da tabela ASCII de 0 à 255
            }

            for (i = 0; i < n; ++i)                             //      ## Ciclo para conversão ##
            {                                                   //  Converte o texto recebido em float
                for (int h = 0; h < 255; ++h)                   //  para ser devolvido e convertido para
                {                                               //  inteiro em reconhecimento da tabela ASCII
                    if (palava[i] == Convert.ToChar(ASCII[h]))
                    {
                        conver[s] = ASCII[h];
                        ++s;
                    }
                }
            }

            return conver;   // Retorna o vetor Conver(palavra convertida para float) para o método Main
        }

        private static float[] algc(char[] palava, int n) // ** ALGORITMO DE CRIPTOGRAFIA **
        {
            int i;  // --> Para Condições
            float[] lo, lo2;  // --> Irá receber os valores de Main e do Key2
            lo = new float[1000];  // --> Peso do vetor, limite máximo de texto 1000 caracteres
            lo2 = new float[36];  // --> Peso para o vetor da palavra key2

            lo = ASC(palava, n);  // lo irá receber a palavra digitada pelo usuário convertida pelo método
            lo2 = keys(); // lo2 irá receber a palavra da key2, que internamente foi convertida pelo método ASC

            float[] result = new float[n];  // Vetor resultante, receberá o resultado final
                                            // do algorítmo criptográfico
            for (i = 0; i < n ; ++i)
            {
                result[i] = ((lo[i] - 4 )*lo2[i])/n; // Ciclo para efetuar o calculo para cada caracter da palavra
            }
            return result; // Returna para o metodo Main o resultado final do cálculo
        }

        private static float[] algd(float[] encript, int n, float[] key2){ // ** ALGORITMO DE DESCRIPTOGRAFIA **

            float[] descript = new float[n];  // --> Vetor que receberá o resultado da descriptografia

            for (int i = 0; i < n; ++i)
            {
                descript[i] = ((encript[i] * n) / key2[i]) + 4; // Ciclo para descriptografar cada caracter
            }

            return descript;  // Retorna para o método Main o resultado da descriptografia

        }

        private static float[] keys(){ // ** CHAVE QUE COBRE A REPETIÇÃO DO TEXTO CRIPTOGRAFADO **

            int x=0; // Contador dos caractere do vetor key
            char[] key = new char[] { 'k',',','s','i','d','j','w','k','g',
                                      'p','i','e','b','c','k','i','e','3',
                                      '4','2','2','3','j','b','d','k','#',
                                      '4','$','8','3','j','a','k','.',','};
            x = key.Length; // X recebera a quantidade de caracteres presentes no Key

            float[] lo2 = new float[x]; // --> Declara o vetor que voltará com a chave secundária

            lo2 = ASC(key, x); // lo2 receberá a conversão do texto key sobre o método ASC

            return lo2; // Retorna para o método Main em float a chave secundária key2
        }
    }
}
