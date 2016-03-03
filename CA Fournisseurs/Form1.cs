using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace CA_Fournisseurs
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            //Affichage liste des clients dans combobox
            FourComDAO filrouge = new FourComDAO();

            comboBox1.DisplayMember = "NomFournisseur";
            comboBox1.ValueMember = "IDFournisseur";
            comboBox1.DataSource = filrouge.List();
            comboBox1.SelectedIndex = -1;

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            FourComDAO filrouge = new FourComDAO();

            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.DataSource = filrouge.ListFourCom(Convert.ToInt32(comboBox1.SelectedValue));
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dataGridView1.Rows[0].Selected = false;

            //Nommage des colonnes
            dataGridView1.Columns[0].HeaderText = "ID Fournisseur";
            dataGridView1.Columns[1].HeaderText = "Nom Fournisseur";
            dataGridView1.Columns[2].HeaderText = "Total TTC Commande";
            dataGridView1.Columns[3].HeaderText = "Numéro Commande";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FourComDAO filrouge = new FourComDAO();

            textBox1.Text = (filrouge.CATotal(Convert.ToInt32(comboBox1.SelectedValue))).ToString();
        }
    }
}
