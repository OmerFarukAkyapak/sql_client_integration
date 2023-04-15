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

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-6VNSSH9\\SQLEXPRESS;Initial Catalog=Faruk;Integrated Security=True");

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult sonuc = MessageBox.Show("Çıkmak İstediğinizden Emin misiniz ?", "Çıkış", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (sonuc == DialogResult.No)
            {
                e.Cancel = true;
                return;
            }

        }


        private void simpleButton1_Click_1(object sender, EventArgs e)
        {
            SqlDataAdapter da = new SqlDataAdapter("Select * from Kitaplık",baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];

            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            baglanti.Open();

            SqlCommand kayit = new SqlCommand("insert into Kitaplık (KitapNo,KitapAd,KitapSayfa,Yayın,KitapFiyat) values(@k1,@k2,@k3,@k4,@k5)",baglanti);
            kayit.Parameters.AddWithValue("@k1", textBox1.Text);
            kayit.Parameters.AddWithValue("@k2", textBox2.Text);
            kayit.Parameters.AddWithValue("@k3", textBox3.Text);
            kayit.Parameters.AddWithValue("@k4", textBox4.Text);
            kayit.Parameters.AddWithValue("@k5", textBox5.Text);


            kayit.ExecuteNonQuery();

            baglanti.Close();


            SqlDataAdapter da = new SqlDataAdapter("Select * from Kitaplık", baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];


        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            
            SqlCommand sil = new SqlCommand("delete from Kitaplık where KitapNo=@no",baglanti);
           
            sil.Parameters.AddWithValue("@no",textBox1.Text);
            sil.ExecuteNonQuery();

            if (textBox1.Text=="") 
            {
                MessageBox.Show("Boş Kayıtlar Silindi.");
            }

            baglanti.Close();
                              
            SqlDataAdapter da = new SqlDataAdapter("Select * from Kitaplık", baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int click = dataGridView1.SelectedCells[0].RowIndex;

            string no = dataGridView1.Rows[click].Cells[0].Value.ToString();
            string ad = dataGridView1.Rows[click].Cells[1].Value.ToString();
            string sf = dataGridView1.Rows[click].Cells[2].Value.ToString();
            string yy = dataGridView1.Rows[click].Cells[3].Value.ToString();
            string fy = dataGridView1.Rows[click].Cells[4].Value.ToString();

            textBox1.Text = no;
            textBox2.Text = ad;
            textBox3.Text = sf;
            textBox4.Text = yy;
            textBox5.Text = fy;

        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            baglanti.Open();

            SqlCommand güncelle = new SqlCommand("update Kitaplık set KitapNo=@k1,KitapAd=@k2,KitapSayfa=@k3,Yayın=@k4,KitapFiyat=@k5 where KitapNo=@k1 ", baglanti);

            güncelle.Parameters.AddWithValue("@k1", textBox1.Text);
            güncelle.Parameters.AddWithValue("@k2", textBox2.Text);
            güncelle.Parameters.AddWithValue("@k3", textBox3.Text);
            güncelle.Parameters.AddWithValue("@k4", textBox4.Text);
            güncelle.Parameters.AddWithValue("@k5", textBox5.Text);

            güncelle.ExecuteNonQuery();

            baglanti.Close();

            SqlDataAdapter da = new SqlDataAdapter("Select * from Kitaplık", baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];

        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            
            SqlDataAdapter da = new SqlDataAdapter("Select * from Kitaplık where KitapAd='"+textBox6.Text+"'", baglanti);                                          
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];

            baglanti.Close();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
