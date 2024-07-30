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
using System.Data.SqlClient;


namespace ProDesign
{
    public partial class LogIn : Form
    {
        static string usernameInput;
        public LogIn()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            SqlConnection conn = new SqlConnection("Data Source=LAPTOP-CS73CLQC;Initial Catalog=supermarketSystemDB;Integrated Security=True");
            conn.Open();
            SqlCommand cmd1 = new SqlCommand("Select * from table1 where username=@username", conn);
            cmd1.Parameters.AddWithValue("username", textBox1.Text);
            SqlDataReader reader1;
            reader1 = cmd1.ExecuteReader();
            if (reader1.Read())
            {
                //check if username and password are the same
                Admin formAdmin = new Admin();

                 usernameInput = textBox1.Text;
                string passwordInput = textBox2.Text;
                bool idDB = reader1["ID"].ToString().StartsWith("SME");
                string usernameDB = reader1["username"].ToString();
                string passwordDB = reader1["password"].ToString();


                if (usernameInput == usernameDB && passwordInput == passwordDB )
                {



                    if (radioButton1.Checked && idDB)
                    {
                        formAdmin.Show();
                        Visible = false;
                    }
                    else if (radioButton2.Checked && !idDB)
                    {
                        Payment formPayment = new Payment();
                        formPayment.insertIntoHistory(usernameInput.ToString());
                        Customer formCustomer = new Customer();
                        formCustomer.Show();
                        Visible = false;
                    }
                    else
                    {
                        MessageBox.Show("please check if you are Customer or Admin :)", "Wrong", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("username and password do not match", "Wrong", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }


        }

        public string sendUsername() { 

        return usernameInput.ToString();
        }
    

        private void LogIn_Load(object sender, EventArgs e)
        {

        }
    }
}
