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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=FURKAN;Initial Catalog=dbMessage;Integrated Security=True");
        SqlCommand komut;
        private void btnKayitOl_Click(object sender, EventArgs e)
        {
            komut = new SqlCommand("Insert Into tblKisiler (AD,SOYAD,NUMARA,SIFRE) Values (@P1,@P2,@P3,@P4)", baglanti);
            komut.Parameters.AddWithValue("@P1", textBox1.Text);
            komut.Parameters.AddWithValue("@P2", textBox2.Text);
            komut.Parameters.AddWithValue("@P3", maskedTextBox1.Text);
            komut.Parameters.AddWithValue("@P4", maskedTextBox2.Text);
            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
            }
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kayıt İşlemi Başarılı!");
            textBox1.Clear();
            textBox2.Clear();
            maskedTextBox1.Clear();
            maskedTextBox2.Clear();
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void lblGirisYap_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void Form3_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
