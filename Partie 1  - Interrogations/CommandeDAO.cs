using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Partie_1____Interrogations
{
    class CommandeDAO
    {
        SqlConnection con;

        //Ouverture de la connexion au serveur SQL Hotel2
        public CommandeDAO()
        {
            con = new SqlConnection("data source=.; initial catalog=filrouge; Trusted_Connection=true");
        }

        public List<Commande> ListByClient() //int IdClient
        {
            List<Commande> liste = new List<Commande>();

            con.Open();

            SqlCommand requete = new SqlCommand();
            requete.CommandText = "select * from fr.commande ";
            requete.Connection = con;

            SqlDataReader resultat = requete.ExecuteReader();

            while (resultat.Read())
            {
                Commande c = new Commande();
                c.RefClient = Convert.ToInt32(resultat["RefClient"]);

                liste.Add(c);
            }
            resultat.Close();
            con.Close();
            return liste;
        }


    }
}
