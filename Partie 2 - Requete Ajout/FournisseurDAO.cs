using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Partie_2___Requete_Ajout
{
    public class FournisseurDAO
    {
        SqlConnection con;

        //Ouverture de la connexion au serveur SQL Fil Rouge
        public FournisseurDAO()
        {
            con = new SqlConnection("data source=.; initial catalog=filrouge; Trusted_Connection=true");
        }

        //Affichage de la liste des fournisseurs
        public List<Fournisseur> List()
        {
            List<Fournisseur> liste = new List<Fournisseur>();

            con.Open();

            SqlCommand requete = new SqlCommand();
            requete.CommandText = "select * from fr.fournisseurs";
            requete.Connection = con;

            SqlDataReader resultat = requete.ExecuteReader();

            while (resultat.Read())
            {
                Fournisseur f = new Fournisseur();

                f.IDFournisseur = Convert.ToInt32(resultat["IDFournisseur"]);
                f.NomFournisseur = Convert.ToString(resultat["NomFournisseur"]);
                f.AdresseFournisseur = Convert.ToString(resultat["AdresseFournisseur"]);
                

                liste.Add(f);
            }

            resultat.Close();

            con.Close();

            return liste;
        }

        //Insertion de nouveaux fournisseurs
        public void Insert(Fournisseur fou)
        {

            con.Open();

            SqlCommand requete = new SqlCommand();
            requete.CommandText = "INSERT into fr.fournisseurs (NomFournisseur, AdresseFournisseur) values (@p1, @p2)";
            requete.Connection = con;
            requete.Parameters.AddWithValue("@p1", fou.NomFournisseur);
            requete.Parameters.AddWithValue("@p2", fou.AdresseFournisseur);
            
            requete.ExecuteNonQuery();
            con.Close();
        }

        //Modification fournisseur déjà existant
        public void Update(Fournisseur fou)
        {
            con.Open();

            SqlCommand requete = new SqlCommand();
            requete.CommandText = "UPDATE fr.fournisseurs SET NomFournisseur = @p1, AdresseFournisseur = @p2 where IDFournisseur = @p0 ";
            requete.Connection = con;
            requete.Parameters.AddWithValue("@p0", fou.IDFournisseur);
            requete.Parameters.AddWithValue("@p1", fou.NomFournisseur);
            requete.Parameters.AddWithValue("@p2", fou.AdresseFournisseur);


            requete.ExecuteNonQuery();
            con.Close();
        }

        //Suppression fournisseur déjà existant
        public void Delete(Fournisseur fou)
        {
            con.Open();

            SqlCommand requete = new SqlCommand();
            requete.CommandText = "DELETE FROM fr.fournisseurs where IDFournisseur = @p0 ";
            requete.Connection = con;
            requete.Parameters.AddWithValue("@p0", fou.IDFournisseur);


            requete.ExecuteNonQuery();
            con.Close();
        }
    }
        
}
