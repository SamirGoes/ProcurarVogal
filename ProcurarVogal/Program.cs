using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcurarVogal
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "khjkfeejhdfgiihuk";
            IStream myStream = new MyStream(input.ToString());

            char value = ValidarPrimeiroCaractere.FirstChar(myStream);

            if (value.EhNull())
                Console.WriteLine("Não foi localizado nenhum caractere!");
            else
                Console.WriteLine(value);

            Console.ReadKey();
        }
    }

    public static class ValidarPrimeiroCaractere
    {
        public struct InputValue
        {
            private readonly string value;

            public InputValue(string value)
            {
                this.value = value;
            }

            public bool ContemVogais()
            {
                int quantidade = 0;
                foreach (char value in this.value.ToCharArray())
                {
                    if (value.EhVogal())
                        quantidade++;
                }

                return quantidade > 0;
            }

            public int QuantidadeCaractereNaString(char caractere)
            {
                int quantidade = 0;
                unsafe
                {
                    fixed (char* caracteres = value)
                    {
                        for (int i = 0; i < value.Length; i++)
                        {
                            if (caracteres[i] == caractere)
                                quantidade++;
                        }
                    }
                }

                return quantidade;
            }

            public static implicit operator InputValue(string value) => new InputValue(value);
        }

        public static char FirstChar(IStream input)
        {
            char previous = '\0';
            char current = '\0';
            bool condicaoAtendida = false;

            InputValue inputValue = input.ToString();

            if (inputValue.ToString() == null)
                return current;

            if (!inputValue.ContemVogais())
                return current;

            while (input.hasNext())
            {
                current = input.getNext();

                if (current.EhVogal())
                {
                    if (previous.EhConsoante())
                    {
                        if (inputValue.QuantidadeCaractereNaString(current) == 1)
                        {
                            condicaoAtendida = true;
                            break;
                        }
                    }
                }

                previous = current;
            }

            return condicaoAtendida ? current : '\0';
        }
    }

    public static class CharExtension
    {
        public static bool EhVogal(this char caractere)
        {
            bool ehVogal = false;
            unsafe
            {
                char* vogais = stackalloc char[10] { 'A', 'a', 'E', 'e', 'I', 'i', 'O', 'o', 'U', 'u' };

                for (int i = 0; i < 10; i++)
                {
                    if (caractere == vogais[i])
                    {
                        ehVogal = true;
                        break;
                    }
                }
            }

            return ehVogal;
        }

        public static bool EhConsoante(this char caractere)
        {
            return !caractere.EhVogal() && !caractere.EhNull();
        }

        public static bool EhNull(this char caractere)
            => caractere == '\0';
    }

}
