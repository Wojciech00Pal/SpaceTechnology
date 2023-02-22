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

       

        private void Check(int ilosc)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query =  "SELECT ilosc FROM zamowienie_produkt WHERE id_zamowienie=@zamID and id_produkt=@prodID ";              
                string query2 = "SELECT ilosc_dostepna, cena FROM produkt WHERE id=@prodID";
                int pobrana_ilosc = 0; // przypisana juz wczesniej liczba produktow do danego zamowienia

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("zamID", zamId);
                    cmd.Parameters.AddWithValue("prodID", prodId);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            try {
                                var ilosc_pobrana_wczesniej = reader.GetInt32(0);
                                pobrana_ilosc = ilosc - ilosc_pobrana_wczesniej;//juz dodana do zamowienia wczesniej i odjeta od liczby produktow dostepnych
                            }catch(Exception ex)
                            {
                                MessageBox.Show(ex.Message);
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
                            int dodane_produkty_do_zam = pobrana_ilosc;//liczba produktow ktora nie jest jeszcze zarejestorwana i trzeba ja 
                            //odjac od liczby dostepnych produktow

                            if (dodane_produkty_do_zam > 0 && ilosc_dostepna >= dodane_produkty_do_zam ) //odejmij juz wprowadzona ilosc produktu
                            {
                                textBox3.Text = Convert.ToString(Convert.ToDouble(ilosc) * cena);

                                //odejmij dostepne produkty
                                //dodaj do zamowiena ilosc
                                UpdateOrder(dodane_produkty_do_zam);
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

        private void UpdateOrder(int dodane_produkty_do_zam )
        {

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query1 = "UPDATE produkt SET ilosc_dostepna = ilosc_dostepna-@dodane_prod WHERE id=@prod_ID"; //ODJECIE produktow od ich stanu dostepnego
                string query2 = "UPDATE zamowienie_produkt SET ilosc = ilosc + @dodane_prod WHERE id_produkt = @prod_ID AND id_zamowienie = @zam_ID";

                using (SqlCommand cmd = new SqlCommand(query1, conn))
                {
                    cmd.Parameters.AddWithValue("prod_ID", prodId);
                    cmd.Parameters.AddWithValue("dodane_prod", dodane_produkty_do_zam);
                    cmd.ExecuteNonQuery();
                    
                }

                using (SqlCommand cmd2 = new SqlCommand(query2, conn))
                {
                    cmd2.Parameters.AddWithValue("dodane_prod", dodane_produkty_do_zam);
                    cmd2.Parameters.AddWithValue("prod_ID", prodId);
                    cmd2.Parameters.AddWithValue("zam_ID", zamId);
                    cmd2.ExecuteNonQuery();
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != null && int.TryParse(textBox1.Text, out int ilosc) && dataZaladowana)
            {
                Check(ilosc);//ilosc wprowadzona do zamowienia dla danego produktu
            }

            ZamowieniaEdycja zam = new ZamowieniaEdycja(zamId);
            zam.Show();
            this.Hide();

        }
    }
}
