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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        NpgsqlConnection baglanti = new NpgsqlConnection("server=localHost; port=5432;Database=vtys; user ID = postgres; password = alpoalpo.08 ");

        private void Form4_Load(object sender, EventArgs e)
        {
            label1.Text = label1.Text;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            string sorgu3 = null;
            sorgu3 = @"select*from adresGüncelle(:KullanıcıNmr,:aadrs)";
            NpgsqlCommand cmd = new NpgsqlCommand(sorgu3, baglanti);
            cmd.Parameters.AddWithValue("KullanıcıNmr", int.Parse(textBox1.Text));
            cmd.Parameters.AddWithValue("aadrs", textBox2.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Adres Değiştirme İşleminiz Başırıyla Gerçekleşti");
            baglanti.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            string sorgu3 = null;
            sorgu3 = @"select*from adresGüncelle(:KullanıcıNmr,:aadrs)";
            NpgsqlCommand cmd = new NpgsqlCommand(sorgu3, baglanti);
            cmd.Parameters.AddWithValue("kllnnmr", int.Parse(textBox1.Text));
            cmd.Parameters.AddWithValue("yenişifre", textBox2.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Şifre Değiştirme İşleminiz Başırıyla Gerçekleşti");
            baglanti.Close();
        }
    }
}
