using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolyalphabeticCipher
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PolyalphabeticCipher();
        }

        private static void PolyalphabeticCipher()
        {
            char[] alphabet = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
            Console.WriteLine("Introduceti textul pentru criptare:");
            string plainText=Console.ReadLine();
            Console.WriteLine("Introduceti un numar n:");
            int n=int.Parse(Console.ReadLine());
            char[,] x = new char[n, 26];
            Console.Write("  ");
            Write(alphabet);
            Console.WriteLine();
            x = polyalphabeticCipher(x,n);
            string cipherText=PolyalphabeticEncrypt(plainText,x,n);
            Console.WriteLine($"Encrypted:{cipherText}");
            string decryptedText=PolyalphabeticDecrypt(cipherText,x,n);
            Console.WriteLine($"Decrypted:{decryptedText}");
            Console.ReadKey();

        }

        private static string PolyalphabeticEncrypt(string plainText, char[,] x,int n)
        {
            string cipherText = "";
            string a = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            int aux = 0;
            foreach(char c in plainText)
            {
                if(char.IsLetter(c))
                {
                    char upperC=char.ToUpper(c);    
                    for(int i=0;i<26;i++)
                    {
                        if (upperC == a[i])
                        {
                            int indxOfJ = a.IndexOf((char)upperC);
                            upperC = x[aux, indxOfJ];
                            break;
                        }
                    }
                    cipherText += upperC;
                }
                else
                {
                    cipherText += c;
                }
                aux++;
                if(aux==n)
                {
                    aux = 0;
                }
            }
            return cipherText;
        }

        private static string PolyalphabeticDecrypt(string cipherText, char[,] x,int n)
        {
            string decryptedText = "";
            string a = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            int aux = 0;
            foreach (char c in cipherText)
            {
                if (char.IsLetter(c))
                {
                    char upperC = char.ToUpper(c);
                    for (int i = 0; i < 26; i++)
                    {
                        if (upperC == x[aux,i])
                        {
                            string p = "";
                            for (int z = 0; z < 26; z++)
                            {
                                p += x[aux, z];
                            }
                            int indxOfJ =p.IndexOf((char)x[aux,i]);
                            upperC = a[indxOfJ];
                            break;
                        }
                    }
                    decryptedText += upperC;
                }
                else
                {
                    decryptedText += c;
                }
                aux++;
                if (aux == n)
                {
                    aux = 0;
                }
            }
            return decryptedText;
        }

        private static char[,] polyalphabeticCipher(char[,] x,int n)
        {
            string a = "ABCDEFGHIJKLMNOPKRSTUVWXYZ";
            char[] rnd_alphabet = new char[26];
            rnd_alphabet=a.ToCharArray();
            for (int i = 0; i < n; i++)
            {
                Console.Write($"{i + 1}:");
                rnd_alphabet = RandomizeArray(rnd_alphabet);
                int j = 0;
                foreach (char c in rnd_alphabet)
                {
                    x[i, j] = c;
                    Console.Write(x[i, j] + " ");
                    j++;
                }
                Console.WriteLine();
            }
            return x;
        }

        private static void Write(char[] array)
        {
            for (int i = 0; i < array.Length; i++)
                Console.Write(array[i] + " ");
            Console.WriteLine();
        }
        private static char[] RandomizeArray(char[] rnd_alphabet)
        {
            //shuffling the array using "Fisher–Yates shuffle Algorithm"
            char[] array = rnd_alphabet;
            Random rnd = new Random();
            for (int i = rnd_alphabet.Length - 1; i > 0; i--)
            {
                int j = rnd.Next(0, i + 1);
                char temp = array[i];
                array[i] = array[j];
                array[j] = temp;
            }
            return array;
        }
    }
}
