using System;
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
            if (e.RowIndex != -1)
            {
                ProduktyEdycja producktEdycja = new ProduktyEdycja(e.RowIndex);
                producktEdycja.Show();
                Hide();
            }
        }

        private void Do_Sklepu_Click(object sender, EventArgs e)
        {
            Sklep sklep = new Sklep();
            sklep.Show();
            Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ProduktyEdycja producktEdycja = new ProduktyEdycja(-1);
            producktEdycja.Show();
            Hide();

        }
    }
}
