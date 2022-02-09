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

namespace OtobusUygulamasi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
       
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-P1SH4NN\SQL;Initial Catalog=Otobusuygulamasi;Integrated Security=True");
        void Seferlistesi()
        {
            SqlDataAdapter da= new SqlDataAdapter("Select * from Tbl_SeferBilgi",baglanti);
            DataTable dt= new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

        }
        void Yolculistesi()
        {
            SqlDataAdapter da2 = new SqlDataAdapter("Select * from Tbl_YolcuBilgi", baglanti);
            DataTable dt2= new DataTable();
            da2.Fill(dt2);
            dataGridView2.DataSource = dt2;
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand kaydet = new SqlCommand("insert into Tbl_YolcuBilgi (Ad,Soyad,Telefon,Tc,Mail,Cinsiyet) values (@p1,@p2,@p3,@p4,@p5,@p6)", baglanti);
            kaydet.Parameters.AddWithValue("@p1", txtAd.Text);
            kaydet.Parameters.AddWithValue("@p2", txtSoyad.Text);
            kaydet.Parameters.AddWithValue("@p3", mskTelefon.Text);
            kaydet.Parameters.AddWithValue("@p4", mskTc.Text);
            kaydet.Parameters.AddWithValue("@p5", txtMail.Text);
            kaydet.Parameters.AddWithValue("@p6", cmbCinsiyet.Text);
            kaydet.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Yolcu Kaydedildi.","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
            Yolculistesi();

        }

        private void btnKaptan_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand kaptan = new SqlCommand("insert into Tbl_Kaptan (KaptanNo,AdSoyad,Telefon)values (@p1,@p2,@p3)", baglanti);
            kaptan.Parameters.AddWithValue("@p1", txtKAptanNo.Text);
            kaptan.Parameters.AddWithValue("@p2", txtKadSoyad.Text);
            kaptan.Parameters.AddWithValue("@p3", mskKaptan.Text);
            kaptan.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kaptan Eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void btnKayıt_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into  Tbl_SeferBilgi (Kalkis,varis,Tarih,Saat,Fiyat,Kaptan) values (@p1,@p2,@p3,@p4,@p5,@p6)", baglanti);
            komut.Parameters.AddWithValue("@p1",txtKalkıs.Text);
            komut.Parameters.AddWithValue("@p2",txtVarıs.Text);
            komut.Parameters.AddWithValue("@p3",mskTarih.Text);
            komut.Parameters.AddWithValue("@p4",mskSaat.Text);
            komut.Parameters.AddWithValue("@p5",txtFiyat.Text);
            komut.Parameters.AddWithValue("@p6", mskKaptan.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Sefer Olusturuldu.","Uyarı",MessageBoxButtons.OK, MessageBoxIcon.Warning);
            Seferlistesi();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Seferlistesi();
            Yolculistesi();

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen= dataGridView1.SelectedCells[0].RowIndex;
            txtSefer.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();

        }

        private void btn1_Click(object sender, EventArgs e)
        {
            txtKoltuk.Text = "1";
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            txtKoltuk.Text = "2";
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            txtKoltuk.Text = "3";
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            txtKoltuk.Text = "4";
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            txtKoltuk.Text = "5";
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            txtKoltuk.Text = "6";
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            txtKoltuk.Text = "7";
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            txtKoltuk.Text = "8";
        }

        private void btnRez_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into Tbl_SeferDetay (SeferNo,YolcuTc,KoltukNo) values (@p1,@p2,@p3)", baglanti);
            komut.Parameters.AddWithValue("@p1", txtSefer.Text);
            komut.Parameters.AddWithValue("@p2",mskYolcuTc.Text);
            komut.Parameters.AddWithValue("@p3", txtKoltuk.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Rezervasyon Oluşturuldu.");
            Yolculistesi();
            


        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen= dataGridView2.SelectedCells[0].RowIndex;
            mskYolcuTc.Text = dataGridView2.Rows[secilen].Cells[4].Value.ToString();
            txtCinsiyett.Text=dataGridView2.Rows[secilen].Cells[5].Value.ToString();
            Yolculistesi();
            
        }
        
    }
}
