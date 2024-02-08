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

namespace Test_Travel
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=TestPassengerTicket;Integrated Security=True");

        void seferlistesi()
        {
            SqlDataAdapter da = new SqlDataAdapter("Select * from TBLSEFERBILGI",connection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource= dt;
        }
        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("insert into TBLYOLCUBILGI (AD,SOYAD,TELEFON,TC,CINSIYET,MAIL) values (@p1,@p2,@p3,@p4,@p5,@p6) ", connection);
            command.Parameters.AddWithValue("@p1", TxtYolcuAd.Text);
            command.Parameters.AddWithValue("@p2", TxtYolcuSoyad.Text);
            command.Parameters.AddWithValue("@p3", mskYolcuTelefon.Text);
            command.Parameters.AddWithValue("@p4", mskTC.Text);
            command.Parameters.AddWithValue("@p5", comboBox1.Text);
            command.Parameters.AddWithValue("@p6", TxtYolcuMail.Text);
            command.ExecuteNonQuery();

            connection.Close();
            MessageBox.Show("Yolcu Bilgisi Eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnKaptanKaydet_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("insert into TBLKAPTAN (kaptanno,adsoyad,telefon) values (@p1,@p2,@p3)", connection);
            command.Parameters.AddWithValue("@p1", TxtKaptanNo.Text);
            command.Parameters.AddWithValue("@p2", TxtKaptanAdSoyad.Text);
            command.Parameters.AddWithValue("@p3", mskKaptanTel.Text);
            command.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Kaptan Bilgisi Eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }

        private void BtnSeferOlustur_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("insert into TBLSEFERBILGI (KALKIS,VARIS,TARIH,SAAT,KAPTAN,FİYAT) values (@p1,@p2,@p3,@p4,@p5,@p6)", connection);
            command.Parameters.AddWithValue("@p1", TxtKalkis.Text);
            command.Parameters.AddWithValue("@p2", TxtVaris.Text);
            command.Parameters.AddWithValue("@p3", mskTarih.Text);
            command.Parameters.AddWithValue("@p4", mskSaat.Text);
            command.Parameters.AddWithValue("@p5", mskKaptan.Text);
            command.Parameters.AddWithValue("@p6", TxtFiyat.Text);
            command.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Sefer Bilgisi Eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            seferlistesi();


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            seferlistesi();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            TxtSeferNumara.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();

        }

        private void Btn1_Click(object sender, EventArgs e)
        {
            TxtKoltukNo.Text = "1";
        }

        private void Btn2_Click(object sender, EventArgs e)
        {
            TxtKoltukNo.Text = "2";

        }

        private void Btn3_Click(object sender, EventArgs e)
        {
            TxtKoltukNo.Text = "3";

        }

        private void Btn4_Click(object sender, EventArgs e)
        {
            TxtKoltukNo.Text = "4";

        }

        private void Btn5_Click(object sender, EventArgs e)
        {
            TxtKoltukNo.Text = "5";

        }

        private void Btn6_Click(object sender, EventArgs e)
        {
            TxtKoltukNo.Text = "6";

        }

        private void Btn7_Click(object sender, EventArgs e)
        {
            TxtKoltukNo.Text = "7";

        }

        private void Btn8_Click(object sender, EventArgs e)
        {
            TxtKoltukNo.Text = "8";

        }

        private void Btn9_Click(object sender, EventArgs e)
        {
            TxtKoltukNo.Text = "9";

        }

        private void BtnRezervasyonYap_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("insert into TBLSEFERDETAY (SEFERNO,YOLCUTC,KOLTUK) values (@p1,@p2,@p3)",connection);
            command.Parameters.AddWithValue("@p1", TxtSeferNumara.Text);
            command.Parameters.AddWithValue("@p2", mskYolcuTC.Text);
            command.Parameters.AddWithValue("@p3", TxtKoltukNo.Text);
            command.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Sefer  Detay Bilgisi Eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
    }
}