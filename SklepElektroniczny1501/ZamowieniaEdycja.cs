using System;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using LinqToDB;
using SklepElektroniczny1501.Space_TechnologyDataSetTableAdapters;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SklepElektroniczny1501
{
    public partial class ZamowieniaEdycja : Form
    {
        private readonly int id;
        int rowsCount = 0;
        string connectionString = @"Data SOURCE=(localdb)\MSSQLLocalDB;Initial Catalog=Space_Technology;Integrated Security=True";
        
        public ZamowieniaEdycja(int id)
        { 
            InitializeComponent();
            textBox1.Text = string.Format("{0:000}", id);
            this.id = id;
            

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = "SELECT* FROM zamowienie_produkt where id_zamowienie=@zam_id";


                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@zam_id", id);
                    DataTable dataTable = new DataTable();
                    dataTable.Load(command.ExecuteReader());
                    dataGridView1.DataSource = dataTable;
                }
                Sum(dataGridView1);
            }
        }

        private void Sum(DataGridView dataGrid)
        {
            double sum = 0;
            foreach(DataGridViewRow row in dataGrid.Rows)
            {
                object value = row.Cells[4].Value;
                object value2 = row.Cells[3].Value;
                if (value != null && double.TryParse(value.ToString(), out double amount) && double.TryParse(value2.ToString(),out double ilosc))
                {
                    sum += ilosc*amount;
                    rowsCount++;
                }
            }
            textBox2.Text = sum.ToString("N2", new CultureInfo("fr-FR"));
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == dataGridView1.Rows.Count - 2)
            {
                DataGridViewCell editedCell = dataGridView1.CurrentCell;
                var prodId = Convert.ToInt32(editedCell.Value);

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    bool product_exist_in_order = false;

                    string query1 = "SELECT COUNT(*) FROM zamowienie_produkt where id_produkt=@prod_id and id_zamowienie=@zam_id";
                    using (SqlCommand command = new SqlCommand(query1, conn))
                    {
                        command.Parameters.AddWithValue("@prod_id", prodId);
                        command.Parameters.AddWithValue("@zam_id", id);
                        var num = (int)command.ExecuteScalar();
                        if (num>0)
                        {
                            product_exist_in_order = true;
                        }
                    }

                    if (!product_exist_in_order)
                    {

                        string query2 = "INSERT INTO zamowienie_produkt (id_produkt, id_zamowienie, ilosc, cena) SELECT @prod_id, @id_zam, 0, cena from produkt where id=@prod_id";
                        try
                        {
                            using (SqlCommand command = new SqlCommand(query2, conn))
                            {
                                command.Parameters.AddWithValue("@id_zam", id);
                                command.Parameters.AddWithValue("@prod_id", prodId);
                                command.ExecuteNonQuery();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }

                        string query3 = "SELECT* FROM zamowienie_produkt where id_zamowienie=@zam_id";


                        using (SqlCommand command = new SqlCommand(query3, conn))
                        {
                            command.Parameters.AddWithValue("@zam_id", id);
                            DataTable dataTable = new DataTable();
                            dataTable.Load(command.ExecuteReader());
                            dataGridView1.DataSource = dataTable;
                        }
                        Sum(dataGridView1);
                    }
                    else
                    {
                        MessageBox.Show("produkt istnieje w zamowieniu zmien jego ilosc w istniejacym rekordzie");
                    }

                }

            }
        }
    }
}

