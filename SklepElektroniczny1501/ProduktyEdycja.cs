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

namespace SklepElektroniczny1501
{
    public partial class ProduktyEdycja : Form
    {
        int row_id = 0;
        string connectionString = @"Data SOURCE=(localdb)\MSSQLLocalDB;Initial Catalog=Space_Technology;Integrated Security=True";
        public ProduktyEdycja(int rowId)
        {
            InitializeComponent();
            row_id = rowId;
            if (rowId != -1)
            {
                row_id = rowId + 1;
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string query = "SELECT* FROM( SELECT *, ROW_NUMBER() OVER(ORDER BY id) " +
                        "AS row_num FROM produkt) t " +
                        "WHERE t.row_num =" + row_id + ";";

                    using (SqlCommand command = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                textBox1.Text = reader.GetString(1);
                                textBox2.Text = reader.GetString(2);
                                richTextBox1.Text = reader.GetString(3);
                                textBox3.Text = Convert.ToString(reader.GetInt32(4));
                                textBox4.Text = Convert.ToString(reader.GetDecimal(5));
                            }
                        }
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                //update
                string query = string.Empty;
                if (row_id != -1)
                {
                     query = "UPDATE produkt SET nazwa = @nazwa, model = @model, opis = @opis, ilosc_dostepna = @ilosc, cena = @cena  WHERE id = " +
                        "(SELECT TOP 1 id FROM (SELECT id, ROW_NUMBER() OVER (ORDER BY id) AS row_num FROM produkt) t WHERE t.row_num = @rowNum)";
                }
                else
                {
                    query = "INSERT INTO produkt (nazwa, model, opis, ilosc_dostepna, cena) " +
                        "VALUES (@nazwa, @model, @opis, @ilosc, @cena)";
                }
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    try
                    {
                        command.Parameters.AddWithValue("@nazwa", textBox1.Text);
                        command.Parameters.AddWithValue("@model", textBox2.Text);
                        command.Parameters.AddWithValue("@opis",  richTextBox1.Text);
                        command.Parameters.AddWithValue("@ilosc", Convert.ToInt32(textBox3.Text));
                        command.Parameters.Add("@cena", Convert.ToDecimal(textBox4.Text));
                        command.Parameters.AddWithValue("@rowNum",row_id);
                        command.ExecuteNonQuery();
                        Produkty produkty = new Produkty();
                        produkty.Show();
                        this.Hide();
                    }catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Produkty produkty = new Produkty();
            produkty.Show();
            this.Hide();
        }
    }
}
