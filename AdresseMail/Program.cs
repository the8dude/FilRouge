using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdresseMail
{
    public class Program
    {
        public static void Main(string[] args)
        {
        }

        public static string CheckMail (string email)
        {
            //VARIABLES
            string resultat = "";
            string saisie;
            string rep1;
            string rep2;
            string rep3;
            string rep4;


            //Regex e1 = new Regex(@"[a-z0-9._-]{2,}@[a-z0-9._-]{2,}\.[a-z]{2,4}$");
            Regex e1 = new Regex(@"^[a-z0-9._-]{2,}$");
            Regex e2 = new Regex(@"^[a-z]{2,4}$");
           
            //Saisie utilisateur
            Console.WriteLine("Entrez votre adresse mail :");
            saisie = Console.ReadLine();

            int pos_arobase = saisie.IndexOf("@");
            int pos_point = saisie.IndexOf(".");
            
            //Gestion du '@' et du '.'
            if (pos_point == -1)
            {
                Console.WriteLine("Il n'y a pas de '.'");
            }
            else
            {
                if (pos_arobase == -1)
                {
                    Console.WriteLine("Il n'y a pas de '@'");
                }
                else
                {
                    //Gestion du nombre de caractères pour chaque partie (minimum 2)
                    if (pos_arobase < 2)
                    {
                        Console.WriteLine("Il y a moins de 2 caractères avant le '@'");
                    }
                    else
                    {
                        if (pos_point - pos_arobase <= 2)
                        {
                            Console.WriteLine("Il y a moins de 2 caractères entre le '@' et le '.'");
                        }
                        else
                        {
                            if (saisie.Length - pos_point <= 2)
                            {
                                Console.WriteLine("Il y a moins de 2 caractères après le '.' ");
                            }
                            else
                            {
                                //// Gestion de validité des regex pour les différentes parties de l'email ////


                                //Utilisation de la fonction STRTOK pour déterminer différentes parties
                                rep1 = strtok(saisie, '@', 0);
                                rep2 = strtok(saisie, '@', 1);
                                rep3 = strtok(rep2, '.', 0);
                                rep4 = strtok(saisie, '.', 1);

                                //Gestion du matching des regex avec la fonction STRTOK
                                Match match1 = e1.Match(rep1);
                                Match match2 = e1.Match(rep3);
                                Match match3 = e2.Match(rep4);

                                if (e1.IsMatch(rep1) == false)
                                {
                                    Console.WriteLine("La partie avant '@' ne convient pas !");
                                }
                                else if (e1.IsMatch(rep3) == false)
                                {
                                    Console.WriteLine("La partie entre '@' et '.' ne convient pas !");
                                }
                                else if (e2.IsMatch(rep4) == false)
                                {
                                    Console.WriteLine("La partie après '.' ne convient pas !");
                                }
                                else
                                    Console.WriteLine("OK");
                            }

                        }
                    }
                }

            }

            return resultat;

            Console.ReadKey();
          }

        //fonction STRTOK permettant de définir les différentes parties de l'adesse email (0@1/0.1)
        static public string strtok(string str1, char str2, int n)
        {
            string resultat = "";
            int compteur = 0;

            foreach (char c in str1)
            {
                if (c == str2)
                {
                    compteur++;
                }

                else {
                    if (compteur == n)
                    {
                        resultat += c;
                    }
                }
            }
            return resultat;
        }



    }
}
