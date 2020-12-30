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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        NpgsqlConnection baglanti = new NpgsqlConnection("server=localHost; port=5432;Database=vtys; user ID = postgres; password = alpoalpo.08 ");
        private void lblSepet_Click(object sender, EventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            lblSepet.Text = lblSepet.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
             baglanti.Open();
            int Sepet = int.Parse(textBox1.Text);
            string sorgu = "select*from\"public\".\"sepetbul\"(" + Sepet + ");";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            baglanti.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            string sorgu = null;
            sorgu = @"select*from sepetkitaptemizle(:silsepetid)";
            NpgsqlCommand cmd = new NpgsqlCommand(sorgu, baglanti);
            cmd.Parameters.AddWithValue("silsepetid", int.Parse(textBox2.Text));
            cmd.ExecuteNonQuery();
            MessageBox.Show("silme tamamlandı");
            baglanti.Close();

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            string sorgu3 = null;
            sorgu3 = @"select*from AdetGüncelle(:spetid,:adet)";
            NpgsqlCommand cmd = new NpgsqlCommand(sorgu3, baglanti);
            cmd.Parameters.AddWithValue("spetid", int.Parse(textBox4.Text));
            cmd.Parameters.AddWithValue("adet", int.Parse(textBox3.Text));
            cmd.ExecuteNonQuery();
            MessageBox.Show("güncellendi");
            baglanti.Close();

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
