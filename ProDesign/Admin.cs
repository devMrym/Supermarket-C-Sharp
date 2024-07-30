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
using System.Xml.Linq;
using System.Security.Cryptography.X509Certificates;

namespace ProDesign
{
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            LogIn logIn = new LogIn();
            logIn.Show();
            Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                string connectionString = "Data Source=LAPTOP-CS73CLQC;Initial Catalog=supermarketSystemDB;Integrated Security=True";
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();

                string id = textBox1.Text;
                string name = textBox2.Text;
                string category = textBox6.Text;
                string brand = textBox4.Text;
                string price = textBox5.Text;
                string quantity = textBox3.Text;

                if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(name) || string.IsNullOrEmpty(category) || string.IsNullOrEmpty(brand) || string.IsNullOrEmpty(price) || string.IsNullOrEmpty(quantity))
                {
                    MessageBox.Show("please enter all information of the item to be added", "Wrong", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else
                {
                    string query = " INSERT INTO Table2 (id,name,category,brand,price,quantity) VALUES('" + id + "', '" + name + "', '" + category + "', '" + brand + "', '" + price + "', '" + quantity + "')";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();

                    con.Close();

                    MessageBox.Show("Data has been added!");
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox6.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "";
                    textBox3.Text = "";
                    FILLDGV();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("please enter all information of the item to be added", "Wrong", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }



        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Admin_Load(object sender, EventArgs e)
        {
            FILLDGV();

        }

        private void FILLDGV()
        {
            string connectionString = "Data Source=LAPTOP-CS73CLQC;Initial Catalog=supermarketSystemDB;Integrated Security=True";
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            string query = "select * from Table2";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {

            try
            {
                string connectionString = "Data Source=LAPTOP-CS73CLQC;Initial Catalog=supermarketSystemDB;Integrated Security=True";
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();

                string id = textBox1.Text;
                string name = textBox2.Text;
                string category = textBox6.Text;
                string brand = textBox4.Text;
                string price = textBox5.Text;
                string quantity = textBox3.Text;

                string query = "update Table2 SET name  = '" + name + "' , category = '" + category + "' , brand = '" + brand + "' , quantity = '" + quantity + "' , price = '" + price + "'  where ID = " + id;
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();

                con.Close();

                MessageBox.Show("Data has been updated!");
                textBox1.Text = "";
                textBox2.Text = "";
                textBox6.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox3.Text = "";
                FILLDGV();
            }
            catch (Exception ex)
            {
                MessageBox.Show("please enter all correct information of the item to be updated", "Wrong", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            try
            {

               
                string connectionString = "Data Source=LAPTOP-CS73CLQC;Initial Catalog=supermarketSystemDB;Integrated Security=True";
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();

                //string idFromDB ="empty";
              
               string id = textBox1.Text;
               
                    string query = "DELETE FROM Table2 WHERE ID =" + id;
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();

                    con.Close();

                    MessageBox.Show("selected item has been deleted!");
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox6.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "";
                    textBox3.Text = "";
                    FILLDGV();
              
             }
            catch (Exception ex)
            {
                MessageBox.Show("please enter correct ID of the item to be deleted", "Wrong", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            

        }
    }
}
