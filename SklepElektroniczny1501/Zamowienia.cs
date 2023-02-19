using SklepElektroniczny1501;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SklepElektroniczny
{
    public partial class Zamowienia : Form
    {
        public Zamowienia()
        {
            InitializeComponent();
        }

        private void Zamowienia_Load(object sender, EventArgs e)
        {
            // TODO: Ten wiersz kodu wczytuje dane do tabeli 'space_TechnologyDataSet.zamowienie' . Możesz go przenieść lub usunąć.
            this.zamowienieTableAdapter.Fill(this.space_TechnologyDataSet.zamowienie);

        }

        private void Do_Sklepu_Click(object sender, EventArgs e)
        {
            Sklep sklep = new Sklep();
            sklep.Show();
            Hide();
        }
    }
}
