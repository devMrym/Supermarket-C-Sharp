using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ProDesign
{
    public partial class Cart : Form
    {


        static string id;
        static string name;
        static string price;
        static string quantity;


        public Cart()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("You are already here !");
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            LogIn logIn = new LogIn();
            logIn.Show();
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
            Visible = false;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            About about = new About();  
            about.Show();
            Visible=false;
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

        private void button1_Click(object sender, EventArgs e)
        {
  
            string connectionString = "Data Source=LAPTOP-CS73CLQC;Initial Catalog=supermarketSystemDB;Integrated Security=True";
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            string query = "DELETE FROM Table3 WHERE id ='" + id + "'";

            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();

            con.Close();
            FILLDGV();
 


        }


        private void FILLDGV()
        {

            string connectionString = "Data Source=LAPTOP-CS73CLQC;Initial Catalog=supermarketSystemDB;Integrated Security=True";
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            string query = "select * from Table3";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();


        }
        
      
       
        private void Cart_Load(object sender, EventArgs e)
        {
            FILLDGV();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            var rN = e.RowIndex;

            id = dataGridView1.Rows[rN].Cells[0].Value.ToString();
            name = dataGridView1.Rows[rN].Cells[1].Value.ToString();
            price = dataGridView1.Rows[rN].Cells[2].Value.ToString();
            quantity = dataGridView1.Rows[rN].Cells[3].Value.ToString();
        }
    }
}
