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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
namespace ProDesign
{
    public partial class Search : Form
    {

        static string id;
        static string name;
        static string price;
        static string quantity;
        public Search()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("You are already here !");
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Cart cart = new Cart();
            cart.Show();
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
            About about = new About();
            about.Show();
            Visible = false;
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            LogIn logIn = new LogIn();
            logIn.Show();
            Visible = false;
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Customer customer = new Customer();
            customer.Show();
            Visible = false;
        }


        private void FILLDGV()
        {
            string connectionString = "Data Source=LAPTOP-CS73CLQC;Initial Catalog=supermarketSystemDB;Integrated Security=True";
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            string query = "select id,name,price,quantity from Table2";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();


        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var rN = e.RowIndex;

            id = dataGridView1.Rows[rN].Cells[0].Value.ToString();
            name = dataGridView1.Rows[rN].Cells[1].Value.ToString();
            price = dataGridView1.Rows[rN].Cells[2].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=LAPTOP-CS73CLQC;Initial Catalog=supermarketSystemDB;Integrated Security=True";
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            string category = comboBox1.Text;
            string query = "select id,name,price,quantity from Table2 where category = '" + category + "'";


            SqlCommand cmd = new SqlCommand(query, con);
            var reader = cmd.ExecuteReader();
            DataTable table = new DataTable();
            table.Load(reader);
            dataGridView1.DataSource = table;
            con.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=LAPTOP-CS73CLQC;Initial Catalog=supermarketSystemDB;Integrated Security=True";
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();


            if (string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("please click on item and type desired quantity", "Wrong", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                try
                {
                    quantity = textBox2.Text;

                    string query = " INSERT INTO Table3 (id,name,price,quantity) VALUES('" + id + "', '" + name + "', '" + price + "', '" + quantity + "')";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();

                    con.Close();

                    MessageBox.Show("item has been added to cart! ");
                }catch(Exception ex)
                {
                    MessageBox.Show("item is either not selected or already added to cart.", "Wrong", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void fillComboSearchCode()
        {

            comboBox1.Items.Clear();
            string connectionString = "Data Source=LAPTOP-CS73CLQC;Initial Catalog=supermarketSystemDB;Integrated Security=True";
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT distinct category from Table2";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                comboBox1.Items.Add(dr["category"].ToString());
            }
            con.Close();

        }

        private void Search_Load(object sender, EventArgs e)
        {

            fillComboSearchCode();
            FILLDGV();
        }
    }
}
