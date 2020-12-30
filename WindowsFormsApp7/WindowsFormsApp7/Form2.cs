using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp7
{
    public partial class Form2 : Form
    {
        public Form2(string KullanıcıAdı)
        {
            this.KullanıcıNumaranız = KullanıcıNumaranız;
            InitializeComponent();
        }
        NpgsqlConnection baglanti = new NpgsqlConnection("server=localHost; port=5432;Database=vtys; user ID = postgres; password = alpoalpo.08 ");


        private string KullanıcıNumaranız;
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            lblKullanıcı.Text = lblKullanıcı.Text;
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            dataGridView1.ClearSelection();
            string sorgu = "select\"Yazarlar_id\",\"YazarAdı\",\"ElimizdeOlanKitaplar\"from\"Yazarlar\"";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            baglanti.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            dataGridView1.ClearSelection();
            string sorgu = "select\"YayınEvi_id\",\"YayınEviAdı\"from\"YayınEvleri\"";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            baglanti.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            string sorgu = null;
            sorgu = @"select*from SepeteKitapEkle(:ekleid,:ekleadı,:adet,:sahip,:fiyat)";
          NpgsqlCommand cmd = new NpgsqlCommand(sorgu, baglanti);
            cmd.Parameters.AddWithValue("ekleid", int.Parse(textBox1.Text));
            cmd.Parameters.AddWithValue("ekleadı", textBox2.Text);
            cmd.Parameters.AddWithValue("adet", int.Parse(textBox3.Text));
            cmd.Parameters.AddWithValue("sahip", int.Parse( textBox4.Text));
            cmd.Parameters.AddWithValue("fiyat", int.Parse(textBox5.Text));
           
            cmd.ExecuteNonQuery();
        
            MessageBox.Show("eklem tamamlandı");
            baglanti.Close();
        }
    

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            
            Form3 frm3 = new Form3();
            frm3.Show();

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void lblKullanıcı_Click(object sender, EventArgs e)
        {

        }

       


        private void button3_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            dataGridView1.ClearSelection();
            string sorgu = "select\"Kitap_id\",\"Yazar\",\"KitapAdı\",\"YayınEvi\",\"AdetFiyat\",\"Türü\"from\"Kitaplar\"";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            baglanti.Close();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form4 frm4 = new Form4();
            frm4.Show();

        }

        private void button7_Click(object sender, EventArgs e)
        {
            /* baglanti.Open();
            string Sepet =textBox6.Text;
            string sorgu = "select*from\"public\".\"kitaptür\"("+ Sepet +  ");";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            baglanti.Close();*/
         
        }

        

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
