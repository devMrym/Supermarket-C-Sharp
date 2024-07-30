using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ProDesign
{
    public partial class Payment : Form
    {
        public Payment()
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
            Visible=false;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("You are already here !");
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

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text) || string.IsNullOrWhiteSpace(textBox3.Text) || string.IsNullOrWhiteSpace(textBox4.Text) || string.IsNullOrWhiteSpace(textBox5.Text))
            {
                label10.Text = "enter valid information";

            }
            else
            {
                label10.Text = "";
                LogIn formLogIn = new LogIn();
                
                insertIntoHistory(formLogIn.sendUsername());
                MessageBox.Show("Purchase completed", "Thank You");
                clearDGV();
                pictureBox8.Visible = true;
                label4.Text = "0";
            }
            
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar)&& !char.IsWhiteSpace(e.KeyChar)) { 
            e.Handled = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Payment_Load(object sender, EventArgs e)
        {
            
            label4.Text = getTotal().ToString();

            FILLDGV();
        }

        private int getTotal() {


            int total=0;
            int price;
            int quantity;
                  SqlConnection conn = new SqlConnection("Data Source=LAPTOP-CS73CLQC;Initial Catalog=supermarketSystemDB;Integrated Security=True");
                conn.Open();
            SqlDataAdapter cmd1= new SqlDataAdapter(" SELECT * FROM table3", conn);

            DataTable dt = new DataTable();
            cmd1.Fill(dt);
            foreach (DataRow row in dt.Rows)
            {
                string id = row["ID"].ToString();
                SqlCommand cmd = new SqlCommand(" SELECT price * quantity FROM table3 where ID = '"+id+"'", conn);
                int result = (int)cmd.ExecuteScalar();
                total += result;
 
            }   
            conn.Close();
            return total;
        }

        private void FILLDGV()
        {
            string connectionString = "Data Source=LAPTOP-CS73CLQC;Initial Catalog=supermarketSystemDB;Integrated Security=True";
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            string query = "select id,name,price,quantity from Table3";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();

        }

        private void clearDGV() {
            string connectionString = "Data Source=LAPTOP-CS73CLQC;Initial Catalog=supermarketSystemDB;Integrated Security=True";
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            string query = "truncate table Table3";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();

        }

        public void insertIntoHistory(string username)
        {
            
            SqlConnection conn = new SqlConnection("Data Source=LAPTOP-CS73CLQC;Initial Catalog=supermarketSystemDB;Integrated Security=True");
            conn.Open();
            SqlDataAdapter cmd1 = new SqlDataAdapter(" SELECT * FROM table3", conn);

            DataTable dt = new DataTable();
            cmd1.Fill(dt);
            foreach (DataRow row in dt.Rows)
            {
                string id = row["ID"].ToString();
                string name = row["Name"].ToString();
                string price = row["price"].ToString();
                string quantity = row["quantity"].ToString();

                string userandId = username + "-" + id;
                SqlCommand cmd = new SqlCommand( " INSERT INTO Table4 (id,name,price,quantity,date) VALUES('" + userandId + "', '" + name +  "', '" + price + "', '" + quantity + "',GETDATE())", conn);
                cmd.ExecuteNonQuery();

            }
            conn.Close();


        }



    }
}
