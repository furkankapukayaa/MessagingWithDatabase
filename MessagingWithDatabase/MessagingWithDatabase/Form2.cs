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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        
        SqlConnection baglanti = new SqlConnection("Data Source=FURKAN;Initial Catalog=dbMessage;Integrated Security=True");
        SqlCommand komut;

        public string numara;
        private void Form2_Load(object sender, EventArgs e)
        {
            lblNumara.Text = numara;
            baglanti.Open();
            komut = new SqlCommand("Select AD,SOYAD From tblKisiler Where NUMARA=" + numara, baglanti);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                lblAdSoyad.Text = dr[0] + " " + dr[1];
            }
            baglanti.Close();
            gelenKutusu();
            gidenKutusu();
        }

        void gelenKutusu()
        {
            SqlDataAdapter da1 = new SqlDataAdapter("Select * From tblMesajlar Where ALICI =" + numara, baglanti);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            dataGridView1.DataSource = dt1;
        }

        void gidenKutusu()
        {
            SqlDataAdapter da2 = new SqlDataAdapter("Select * From tblMesajlar Where GONDEREN =" + numara, baglanti);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            dataGridView2.DataSource = dt2;
        }

        private void btnGonder_Click(object sender, EventArgs e)
        {
            komut = new SqlCommand("Insert Into tblMesajlar (GONDEREN,ALICI,KONU,MESAJ) Values (@P1,@P2,@P3,@P4)", baglanti);
            komut.Parameters.AddWithValue("@P1", numara);
            komut.Parameters.AddWithValue("@P2", maskedTextBox1.Text);
            komut.Parameters.AddWithValue("@P3", textBox1.Text);
            komut.Parameters.AddWithValue("@P4", richTextBox1.Text);
            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
            }
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Mesajınız Gönderildi!");
            maskedTextBox1.Clear();
            textBox1.Clear();
            richTextBox1.Clear();
            gidenKutusu();
        }

        private void btnCikisYap_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
