using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        AdresDefterDal ad= new AdresDefterDal();
        private void Form1_Load(object sender, EventArgs e)
        {

            dataGridView1.DataSource = ad.GetAll();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


        }

        private void button1_Click(object sender, EventArgs e)
        {
            ad.Ekle(new Adresler

            {
                Ad = txtAd.Text,
                Soyad = txtSoyad.Text,
                Telefon = txtTelefon.Text,
                Email = txtEmail.Text,
                Adres = txtAdres.Text,
                Il = txtIl.Text,
                Ilce = txtIlce.Text

            });
            dataGridView1.DataSource = ad.GetAll();


        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            ad.Delete(id);
            dataGridView1.DataSource = ad.GetAll();
            MessageBox.Show("kayıt silindi");




        }

        private void gnctelefon_TextChanged(object sender, EventArgs e)
        {

        }

        private void gncbtn_Click(object sender, EventArgs e)
        {
            AdresDefterDal adrsdal = new AdresDefterDal();
            Adresler adres = new Adresler
            {
                id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString()),
                Ad = gncad.Text,
                Soyad = gncsoyad.Text,
                Telefon = gnctelefon.Text,
                Email = gncemail.Text,
                Adres=gncadres.Text,
                Il = gncil.Text,
                Ilce=gncilce.Text
            };
            adrsdal.Update(adres);

            MessageBox.Show("güncellendi");
            dataGridView1.DataSource = ad.GetAll();
        }

        private void gncad_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void btnAra_Click(object sender, EventArgs e)
        {

            SqlConnection connections = new SqlConnection("Data Source=IDEA\\SQLEXPRESS;Initial Catalog=Crud;Integrated Security=True");
            if (connections.State == ConnectionState.Closed)
            {
                connections.Open();
            }
            SqlCommand ara = new SqlCommand("select * from Person where ad like'%" + txtAra.Text + "%'", connections);
            SqlDataAdapter da = new SqlDataAdapter(ara);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            connections.Close();

        }
        private void button2_Click(object sender, EventArgs e)
        {

           
        }

        private void dataGridView1_CellBorderStyleChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            gncad.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            gncsoyad.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            gnctelefon.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            gncemail.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            gncadres.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            gncil.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            gncilce.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
        }
    }
}