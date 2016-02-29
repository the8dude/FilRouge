using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdresseMail
{
    class Program
    {
        public static void Main(string[] args)
        {
            string saisie;

            
            Regex email = new Regex(@"[a-z0-9._-]{2,}@[a-z0-9._-]{2,}\.[a-z]{2,4}$");
            
            Console.WriteLine("Entrez votre adresse mail :");
            saisie = Console.ReadLine();
            Match match = email.Match(saisie);

            try
            {
                if (match.Success)
                {
                    Console.WriteLine("Chaine vide");
                }
            }
            catch(Exception er)
            {
                Console.WriteLine(er.Message);
            }
            Console.ReadKey();

        }

       
    }
}
