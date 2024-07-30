using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProDesign
{
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Cart cart = new Cart();
            cart.Show();
            Visible = false;

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Search search = new Search();
            search.Show();
            Visible = false;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Payment payment = new Payment();
            payment.Show();
            Visible=false;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("You are already here !");
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Customer customer = new Customer();
            customer.Show();
            Visible = false;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void About_Load(object sender, EventArgs e)
        {
            FILLDGV();
        }
        private void FILLDGV()
        {
            string connectionString = "Data Source=LAPTOP-CS73CLQC;Initial Catalog=supermarketSystemDB;Integrated Security=True";
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            LogIn formLogIn = new LogIn();
            string id = formLogIn.sendUsername();
            string query = "select * from Table4 where id like '"+id+"%'";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            LogIn logIn = new LogIn();
            logIn.Show();
            Visible = false;
        }
    }
}
