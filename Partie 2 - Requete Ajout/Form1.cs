using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Partie_2___Requete_Ajout
{
    public partial class Form1 : Form
    {
        string action;
        int id_client;

        public Form1()
        {
            InitializeComponent();
            Width = 748;
            Height = 242;
            button4.Location = new System.Drawing.Point(645, 165);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FournisseurDAO filrouge = new FournisseurDAO();

            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.DataSource = filrouge.List();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            button5.Visible = true;
            button6.Visible = true;
            button7.Visible = true;

            dataGridView1.Enabled = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show
                   ("Souhaitez-vous quitter l'application ?", "EXIT", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (dr == DialogResult.Yes)
            {
                Application.Exit();

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.Enabled = true;
            DialogResult dr = MessageBox.Show
                  ("Souhaitez-vous annuler la saisie du nouveau fournisseur ?", "Ajout nouveau fournisseur", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (dr == DialogResult.Yes)
            {
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                groupBox1.Enabled = false;

                Width = 748;
                Height = 242;
                button4.Location = new System.Drawing.Point(645, 165);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            button4.Location = new System.Drawing.Point(645, 353);
            groupBox1.Enabled = true;
            Width = 748;
            Height = 427;

            action = "ajouter";

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();

            dataGridView1.Enabled = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            button4.Location = new System.Drawing.Point(645, 353);
            groupBox1.Enabled = true;
            Width = 748;
            Height = 427;

            dataGridView1.Enabled = false;

            action = "modifier";

            if (dataGridView1.SelectedRows.Count != -1)
            {
                textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                textBox3.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                id_client = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            button4.Location = new System.Drawing.Point(645, 353);
            groupBox1.Enabled = true;
            Width = 748;
            Height = 427;

            dataGridView1.Enabled = false;

            action = "supprimer";
            if (dataGridView1.SelectedRows.Count != -1)
            {
                textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                textBox3.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                id_client = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            }
        }
        
        //textBox2 : Nom Fournisseur
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            Regex re_NomFournisseur = new Regex(@"^[a-zA-Z 'éè&]{1,50}$");

            if (textBox2.Text.Length != 0)
            {
                if (re_NomFournisseur.IsMatch(textBox2.Text))
                {
                    textBox2.BackColor = Color.Green;
                }
                else
                {
                    textBox2.BackColor = Color.Red;

                }
            }
            else
            {
                textBox2.BackColor = SystemColors.Window;
            }
        }

        //textBox3 : Adresse Fournisseur
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            Regex re_AdresseFournisseur = new Regex(@"^[a-zA-Z -]{1,50}$");

            if (textBox3.Text.Length != 0)
            {
                if (re_AdresseFournisseur.IsMatch(textBox3.Text))
                {
                    textBox3.BackColor = Color.Green;
                }
                else
                {
                    textBox3.BackColor = Color.Red;

                }
            }
            else
            {
                textBox3.BackColor = SystemColors.Window;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Enabled = true;
            //-------------------------Ajout Nouveau Fournisseur
            if (action == "ajouter")
            {
                Fournisseur f = new Fournisseur();

                f.NomFournisseur = textBox2.Text;
                f.AdresseFournisseur = textBox3.Text;

                FournisseurDAO filrouge = new FournisseurDAO();

                DialogResult dr = MessageBox.Show
                   ("Souhaitez-vous ajouter ce nouveau client ?", "Ajout nouveau client", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (dr == DialogResult.Yes)
                {
                    filrouge.Insert(f);

                    //Refresh DataGriedView
                    filrouge = new FournisseurDAO();

                    dataGridView1.ReadOnly = true;
                    dataGridView1.RowHeadersVisible = false;
                    dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dataGridView1.DataSource = filrouge.List();
                    dataGridView1.Columns[0].Visible = false;
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    groupBox1.Enabled = false;

                    Width = 748;
                    Height = 242;
                    button4.Location = new System.Drawing.Point(645, 165);

                }

            }

            //-------------------------Modifier Fournisseur
            if (action == "modifier")
            {
                Fournisseur f = new Fournisseur();

                f.NomFournisseur = textBox2.Text;
                f.AdresseFournisseur = textBox3.Text;
                f.IDFournisseur = id_client;


                FournisseurDAO filrouge = new FournisseurDAO();

                DialogResult dr = MessageBox.Show
                   ("Souhaitez-vous modifier le fournisseur existant ?", "Modifier fournisseur existant", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (dr == DialogResult.Yes)
                {
                    filrouge.Update(f);

                    //Refresh DataGriedView
                    filrouge = new FournisseurDAO();

                    dataGridView1.ReadOnly = true;
                    dataGridView1.RowHeadersVisible = false;
                    dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dataGridView1.DataSource = filrouge.List();
                    dataGridView1.Columns[0].Visible = false;
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    groupBox1.Enabled = false;

                    Width = 748;
                    Height = 242;
                    button4.Location = new System.Drawing.Point(645, 165);

                }
            }

            //-------------------------Supprimer Fournisseur
            if (action == "supprimer")
            {
                Fournisseur f = new Fournisseur();

                f.NomFournisseur = textBox2.Text;
                f.AdresseFournisseur = textBox3.Text;
                f.IDFournisseur = id_client;


                FournisseurDAO filrouge = new FournisseurDAO();

                DialogResult dr = MessageBox.Show
                   ("Souhaitez-vous supprimer le fournisseur existant ?", "Supprimer fournisseur existant", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (dr == DialogResult.Yes)
                {
                    filrouge.Delete(f);

                    //Refresh DataGriedView
                    filrouge = new FournisseurDAO();

                    dataGridView1.ReadOnly = true;
                    dataGridView1.RowHeadersVisible = false;
                    dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dataGridView1.DataSource = filrouge.List();
                    dataGridView1.Columns[0].Visible = false;
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    groupBox1.Enabled = false;

                    Width = 748;
                    Height = 242;
                    button4.Location = new System.Drawing.Point(645, 165);

                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
