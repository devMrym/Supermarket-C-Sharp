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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Xml.Linq;

namespace ProDesign
{
    public partial class Customer : Form
    {


        static string id;
        static string name;
        static string price;
        static string quantity;

        public Customer()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            LogIn openf = new LogIn();
            openf.Show();
            Visible = false;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Cart cart = new Cart();
            cart.Show();
            Visible=false;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Search search = new Search();   
            search.Show();
            Visible = false;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            About about = new About();
            about.Show();
            Visible = false;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Payment payment = new Payment();
            payment.Show();
            Visible = false;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = "Data Source=LAPTOP-CS73CLQC;Initial Catalog=supermarketSystemDB;Integrated Security=True";
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();


                if (string.IsNullOrEmpty(textBox1.Text))
                {
                    MessageBox.Show("please click on item and type desired quantity", "Wrong", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    quantity = textBox1.Text;

                    string query = " INSERT INTO Table3 (id,name,price,quantity) VALUES('" + id + "', '" + name + "', '" + price + "', '" + quantity + "')";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();

                    con.Close();

                    MessageBox.Show("item has been added to cart! ");
                }
            }
            catch (Exception ex){

                MessageBox.Show("item is either not selected or already added to cart.", "Wrong", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
           
        }


        private void FILLDGV()
        {
            string connectionString = "Data Source=LAPTOP-CS73CLQC;Initial Catalog=supermarketSystemDB;Integrated Security=True";
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            string query = "select id,name,price,quantity from Table2"; //query 
            SqlDataAdapter da = new SqlDataAdapter(query, con); //to execute query
            DataTable dt = new DataTable(); //data table initialization
            da.Fill(dt); //fill data table with info from sql table
            dataGridView1.DataSource = dt; //fill data grid view with datatable
            con.Close();


        }

        private void Customer_Load(object sender, EventArgs e)
        {
            FILLDGV();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var rN = e.RowIndex;

            id = dataGridView1.Rows[rN].Cells[0].Value.ToString();
            name = dataGridView1.Rows[rN].Cells[1].Value.ToString();
            price = dataGridView1.Rows[rN].Cells[2].Value.ToString();


        }
    }
}
