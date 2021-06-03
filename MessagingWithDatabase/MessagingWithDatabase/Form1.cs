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

namespace MessagingWithDatabase
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlCommand komut;
        SqlConnection baglanti = new SqlConnection("Data Source=FURKAN;Initial Catalog=dbMessage;Integrated Security=True");

        private void btnGirisYap_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            komut = new SqlCommand("Select * From tblKisiler where NUMARA=@P1 and SIFRE=@P2", baglanti);
            komut.Parameters.AddWithValue("@P1", maskedTextBox1.Text);
            komut.Parameters.AddWithValue("@P2", maskedTextBox2.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                Form2 form2 = new Form2();
                form2.numara = maskedTextBox1.Text;
                form2.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı Giriş!");
            }
            baglanti.Close();

        }
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void lblKayit_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
            this.Hide();
        }
    }
}
