using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Partie_1____Interrogations
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Width = 340;
            Height = 148;

            

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            

            //Affichage liste des clients dans combobox
            ClientDAO filrouge = new ClientDAO();

            comboBox1.DisplayMember = "NomClient";
            comboBox1.ValueMember = "RefClient";
            comboBox1.DataSource = filrouge.List();
            comboBox1.SelectedIndex = -1;
        }

        //Affichage des commandes dans datagridview
        private void button1_Click(object sender, EventArgs e)
        {

            if (comboBox1.SelectedIndex != -1)
            {
                Width = 1000;
                Height = 333;
            }

            CommandeDAO filrouge = new CommandeDAO();

            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.DataSource = filrouge.ListByClient(Convert.ToInt32(comboBox1.SelectedValue));
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            //Nommage des colonnes
            dataGridView1.Columns[0].HeaderText = "N° de commande";
            dataGridView1.Columns[1].HeaderText = "Date de commande";
            dataGridView1.Columns[2].HeaderText = "Total TTC";
            dataGridView1.Columns[3].HeaderText = "Date Règlement";
            dataGridView1.Columns[4].HeaderText = "Etat de la commande";
            dataGridView1.Columns[5].HeaderText = "N° Bon de commande";
            dataGridView1.Columns[6].HeaderText = "Total HT";
            dataGridView1.Columns[7].HeaderText = "Réduction";
            dataGridView1.Columns[8].HeaderText = "N° de facture";
            dataGridView1.Columns[9].HeaderText = "Date de facturation";
            dataGridView1.Columns[10].HeaderText = "Réf client";
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
