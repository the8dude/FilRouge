using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Partie_1____Interrogations
{
    public class CommandeDAO
    {
        SqlConnection con;
        

        //Ouverture de la connexion au serveur SQL Hotel2
        public CommandeDAO()
        {
            con = new SqlConnection("data source=.; initial catalog=filrouge; Trusted_Connection=true");
        }

        // Affichage de la liste des clients (pour le combobox)
        public List<Commande> ListByClient(int RefClient)
        {
            List<Commande> liste = new List<Commande>();

            con.Open();

            SqlCommand requete = new SqlCommand();
            requete.CommandText = "select * from fr.commande where RefClient = @ref";
            requete.Connection = con;
            requete.Parameters.AddWithValue("@ref", RefClient);


            SqlDataReader resultat = requete.ExecuteReader();

            while (resultat.Read())
            {
                Commande c = new Commande();

                c.NumCommande = Convert.ToInt32(resultat["NumCommande"]);
                c.DateCommande = Convert.ToDateTime(resultat["DateCommande"]);
                c.TotalTTCCommande = Convert.ToDouble(resultat["TotalTTCCommande"]);
                c.DateReglement = Convert.ToDateTime(resultat["DateReglement"]);
                c.EtatCommande = Convert.ToInt32(resultat["EtatCommande"]);
                c.BonDeCommande = Convert.ToString(resultat["BonDeCommande"]);
                c.TotalHT = Convert.ToDouble(resultat["TotalHT"]);
                c.Reduction = Convert.ToDouble(resultat["Reduction"]);
                c.Facture = Convert.ToString(resultat["Facture"]);
                c.DateFacture = Convert.ToDateTime(resultat["DateFacture"]);
                c.RefClient = Convert.ToInt32(resultat["RefClient"]);

                liste.Add(c);
            }
            resultat.Close();
            con.Close();
            return liste;
        }


    }
}
