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
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Affichage liste des clients dans combobox
            CommandeDAO filrouge = new CommandeDAO();

            comboBox1.Items.Add("Sélectionnez un client");
            comboBox1.DisplayMember = "RefClient";
            comboBox1.DataSource = filrouge.ListByClient();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
