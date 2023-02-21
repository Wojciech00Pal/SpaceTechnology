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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SklepElektroniczny1501
{
    public partial class ZamowieniePozycjeEdycja : Form
    {
        private readonly int prodId;
        private readonly int zamId;
        bool dataZaladowana = false;
        string connectionString = @"Data SOURCE=(localdb)\MSSQLLocalDB;Initial Catalog=Space_Technology;Integrated Security=True";

        public ZamowieniePozycjeEdycja(int _prodId, int _zamId)
        {
            InitializeComponent();
            
            prodId = _prodId;
            zamId = _zamId;
            LoadAmount();
        }

        private void LoadAmount()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT ilosc, cena FROM zamowienie_produkt WHERE id_produkt=@prodID and id_zamowienie=@zamID ";
                
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("prodID", prodId);
                    command.Parameters.AddWithValue("zamID", zamId);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            textBox1.Text = Convert.ToString(reader.GetValue(0));
                            textBox2.Text = Convert.ToString(reader.GetValue(1));

                            if (textBox1.Text != null && double.TryParse(textBox1.Text, out double ilosc) && 
                                textBox2.Text != null && double.TryParse(textBox2.Text, out double cena))
                            {
                                textBox3.Text = Convert.ToString( ilosc * cena );
                            }
                            dataZaladowana = true;
                        }
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ZamowieniaEdycja zamowieniaEdycja = new ZamowieniaEdycja(zamId);
            zamowieniaEdycja.Show();
            this.Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void Check(int ilosc)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query =  "SELECT ilosc FROM zamowienie_produkt WHERE id_zamowienie=@zamID and id_produkt=@prodID ";              
                string query2 = "SELECT ilosc_dostepna, cena FROM produkt WHERE id=@prodID";
                int pobrana_ilosc = 0;

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("zamID", zamId);
                    cmd.Parameters.AddWithValue("prodID", prodId);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (reader.GetValue(0) != null && int.TryParse(textBox1.Text, out int ilosc_pobrana))
                            {
                                pobrana_ilosc = ilosc_pobrana;
                            }
                        }
                    }
                }
                
                using (SqlCommand command = new SqlCommand(query2, conn))
                {
                    command.Parameters.AddWithValue("prodID", prodId);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int ilosc_dostepna = Convert.ToInt32(reader.GetValue(0));
                            Double cena = Convert.ToDouble(reader.GetValue(1));

                            if (ilosc_dostepna > ilosc - pobrana_ilosc ) //odejmij juz wprowadzona ilosc produktu
                            {
                                textBox3.Text = Convert.ToString(Convert.ToDouble(ilosc) * cena);

                                //odejmij dostepne produkty
                                //dodaj do zamowiena ilosc
                            }
                            else
                            {
                                MessageBox.Show("Ilosc dostepnych produktow jest niewystarczajaca");
                            }
                        }
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != null && int.TryParse(textBox1.Text, out int ilosc) && dataZaladowana)
            {
                Check(ilosc);//ilosc wprowadzona do zamowienia dla danego produktu
            }
        }
    }
}
