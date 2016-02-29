using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Partie_1____Interrogations
{
    public class ClientDAO
    {
        SqlConnection con;
        

        //Ouverture de la connexion au serveur SQL Hotel2
        public ClientDAO()
        {
            con = new SqlConnection("data source=.; initial catalog=filrouge; Trusted_Connection=true");
        }

        // Affichage de la liste des clients (pour le combobox)
        public List<Client> List()
        {
            List<Client> liste = new List<Client>();

            con.Open();

            SqlCommand requete = new SqlCommand();
            requete.CommandText = "select * from fr.client";
            requete.Connection = con;


            SqlDataReader resultat = requete.ExecuteReader();

            while (resultat.Read())
            {
                Client c = new Client();

                c.RefClient = Convert.ToInt32(resultat["RefClient"]);
                c.NomClient = Convert.ToString(resultat["NomClient"]);

                liste.Add(c);
            }
            resultat.Close();
            con.Close();
            return liste;
        }


    }
}
