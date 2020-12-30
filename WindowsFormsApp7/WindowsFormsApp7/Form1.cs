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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }
        private NpgsqlConnection baglanti;
        string baglantistring = String.Format("server=localHost; port=5432;Database=vtys; user ID = postgres; password = alpoalpo.08 ");

      
        private NpgsqlCommand cmd;
        private string sql = null;
        private void label1_Click(object sender, EventArgs e)
        {

            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //this.Hide();
            // new Form2(txtKullanıcıAdı.Text).Show();
            try
            {
                baglanti.Open();
                sql = @"select * from GİRİŞFONK(:_KullanıcıNo,:_Şifre)";
                cmd = new NpgsqlCommand(sql, baglanti);
                cmd.Parameters.AddWithValue("_KullanıcıNo", int.Parse( txtKullanıcıAdı.Text));
                cmd.Parameters.AddWithValue("_Şifre", txtŞifre.Text);
                    int rsl = (int)cmd.ExecuteScalar();

                baglanti.Close();
                if (rsl == 1)
                {
                    this.Hide();
                    new Form2(txtKullanıcıAdı.Text).Show();
                }
                else
                {
                    MessageBox.Show("Bilgilereinizi Kontrol Ediniz", "Hata1",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
                    return;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Hata:" + ex.Message, "Yanlış giden bir şeyler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                baglanti.Close();
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            baglanti = new NpgsqlConnection(baglantistring);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            string sorgu = null;
            sorgu = @"select*from ekleKullanıcı(:KullanıcıAdı,:Soyad,:KullanıcıNo,:Adres,:Şifre)";
            NpgsqlCommand cmd = new NpgsqlCommand(sorgu, baglanti);
            cmd.Parameters.AddWithValue("KullanıcıAdı", textBox1.Text);
            cmd.Parameters.AddWithValue("Soyad", textBox2.Text);
            cmd.Parameters.AddWithValue("KullanıcıNo", int.Parse(textBox3.Text));
            cmd.Parameters.AddWithValue("Adres", textBox4.Text);
            cmd.Parameters.AddWithValue("Şifre", textBox5.Text);

            cmd.ExecuteNonQuery();

            MessageBox.Show("EKLEME TAMAM GİRİŞ YAPINIZ");
            baglanti.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtKullanıcıAdı_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void txtŞifre_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
