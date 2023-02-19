using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SklepElektroniczny1501
{
    public partial class Produkty : Form
    {
        public Produkty()
        {
            InitializeComponent();
        }

        private void Produkty_Load(object sender, EventArgs e)
        {
            // TODO: Ten wiersz kodu wczytuje dane do tabeli 'space_TechnologyDataSet.produkt' . Możesz go przenieść lub usunąć.
            dataGridView1.Columns[1].Width = 210;
            dataGridView1.Columns[2].Width = 180;
            dataGridView1.Columns[3].Width = 180;
            this.produktTableAdapter.Fill(this.space_TechnologyDataSet.produkt);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Do_Sklepu_Click(object sender, EventArgs e)
        {
            Sklep sklep = new Sklep();
            sklep.Show();
            Hide();
        }
    }
}
