using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA_Fournisseurs
{
    public class FourComDAO
    {
        SqlConnection con;

        /// <summary>
        /// Ouverture de la connexion au serveur SQL Hotel2
        /// </summary>
        public FourComDAO()
        {
            con = new SqlConnection("data source=.; initial catalog=filrouge; Trusted_Connection=true");
        }

        /// <summary>
        /// Affichage des fournisseurs pour le combobox
        /// </summary>
        /// <returns></returns>
        public List<FourCom> List()
        {
            List<FourCom> liste = new List<FourCom>();

            con.Open();

            SqlCommand requete = new SqlCommand();
            requete.CommandText = "select * from fr.fournisseurs ";
            requete.Connection = con;

            SqlDataReader resultat = requete.ExecuteReader();

            FourCom f2 = new FourCom();
            f2.IDFournisseur = 0;
            f2.NomFournisseur = "Tous";
            liste.Add(f2);

            while (resultat.Read())
            {
                FourCom f = new FourCom();
                f.IDFournisseur = Convert.ToInt32(resultat["IDFournisseur"]);
                f.NomFournisseur = Convert.ToString(resultat["NomFournisseur"]);


                liste.Add(f);
            }
            resultat.Close();
            con.Close();
            return liste;
        }

        /// <summary>
        /// Affichage des commandes par fournisseurs dans le datagriedview1
        /// </summary>
        /// <returns></returns>
        public List<FourCom> ListFourCom(int IDFournisseur)
        {
            List<FourCom> liste = new List<FourCom>();

            if (IDFournisseur != 0)
            {
                con.Open();

                SqlCommand requete = new SqlCommand();
                requete.CommandText = "exec GetFourCom1 @p1";
                //PROCEDURE STOCKEE :        
                //@"select distinct fr.fournisseurs.IDFournisseur, fr.fournisseurs.NomFournisseur, fr.commande.TotalTTCCommande, fr.commande.NumCommande 
                //                    FROM fr.fournisseurs JOIN fr.article ON fr.fournisseurs.IDFournisseur = fr.article.IDFournisseur 
                //                                         JOIN fr.secomposede ON fr.secomposede.RefArticle = fr.article.RefArticle 
                //                                         JOIN fr.commande ON fr.commande.NumCommande = fr.secomposede.NumCommande
                //                                         WHERE fr.fournisseurs.IDFournisseur = @p1";



                requete.Connection = con;
                requete.Parameters.AddWithValue("@p1", IDFournisseur);

                SqlDataReader resultat = requete.ExecuteReader();

                while (resultat.Read())
                {
                    FourCom f = new FourCom();
                    f.IDFournisseur = Convert.ToInt32(resultat["IDFournisseur"]);
                    f.NomFournisseur = Convert.ToString(resultat["NomFournisseur"]);
                    f.TotalTTCCommande = Convert.ToString(resultat["TotalTTCCommande"]);
                    f.NumCommande = Convert.ToString(resultat["NumCommande"]);


                    liste.Add(f);
                }
                resultat.Close();
                con.Close();
            }
            else
            {
                con.Open();

                SqlCommand requete = new SqlCommand();
                requete.CommandText = "exec GetFourCom";


                requete.Connection = con;

                SqlDataReader resultat = requete.ExecuteReader();

                while (resultat.Read())
                {
                    FourCom f = new FourCom();
                    f.IDFournisseur = Convert.ToInt32(resultat["IDFournisseur"]);
                    f.NomFournisseur = Convert.ToString(resultat["NomFournisseur"]);
                    f.TotalTTCCommande = Convert.ToString(resultat["TotalTTCCommande"]);
                    f.NumCommande = Convert.ToString(resultat["NumCommande"]);


                    liste.Add(f);
                }
                resultat.Close();
                con.Close();
            }

            return liste;
        }

        /// <summary>
        /// Afficher le CA Cumulé dans le textbox1
        /// </summary>
        /// <param name="IDFournisseur"></param>
        /// <returns></returns>
        public Double CATotal(int IDFournisseur)
        {
            Double CA = new Double();

            if (IDFournisseur != 0)
            {
                con.Open();

                SqlCommand requete = new SqlCommand();
                requete.CommandText = "exec CATotalF @p1";

                requete.Connection = con;
                requete.Parameters.AddWithValue("@p1", IDFournisseur);

                SqlDataReader resultat = requete.ExecuteReader();

                while (resultat.Read())
                {
                    
                    CA = Convert.ToDouble(resultat["TotalTTCCommande"]);
                }

                resultat.Close();
                con.Close();
            }
            else
            {
                con.Open();

                SqlCommand requete = new SqlCommand();
                requete.CommandText = "exec CATotal";


                requete.Connection = con;

                SqlDataReader resultat = requete.ExecuteReader();

                while (resultat.Read())
                {
                    CA = Convert.ToDouble(resultat["TotalTTCCommande"]);
                }

                resultat.Close();
                con.Close();
            }

            return CA;
        }


    }
}
