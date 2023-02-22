using LinqToDB;
using SklepElektroniczny1501;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SklepElektroniczny
{
    public partial class Zamowienia : Form
    {
        string connectionString = @"Data SOURCE=(localdb)\MSSQLLocalDB;Initial Catalog=Space_Technology;Integrated Security=True";

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


        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {

                if (e.RowIndex == dataGridView1.Rows.Count - 1)
                {
                    String query = "INSERT INTO zamowienie (numer_zamowienia, data_zamowienia) VALUES (@nr_zam, @data)";
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {

                            cmd.Parameters.AddWithValue("nr_zam", string.Format("{0:000}", e.RowIndex + 1));
                            var date = DateTime.Now;
                            cmd.Parameters.AddWithValue("data", date.ToString("yyyy-MM-dd HH:mm.ss") + '0');
                            cmd.ExecuteNonQuery();
                        }

                        ZamowieniaEdycja zamowieniaEdy = new ZamowieniaEdycja(e.RowIndex + 1, true);
                        zamowieniaEdy.Show();
                        this.Hide();
                        return;
                    }
                }

                    ZamowieniaEdycja zamowieniaEdycja = new ZamowieniaEdycja(Convert.ToInt32(dataGridView1[1, e.RowIndex].Value));
                    zamowieniaEdycja.Show();
                    this.Hide();
            }
        }
    }
}
