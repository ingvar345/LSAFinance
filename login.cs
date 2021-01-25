using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Billing_Module
{
    public partial class login : Form
    {
        //string constring = "datasource=192.168.0.17;Initial Catalog=lsa_test1;port=3306;username=ing;password=123";
        string constring = "datasource=203.177.24.82;Initial Catalog=lsa_test1;port=3306;username=ing;password=123";
        
        public login()
        {
            InitializeComponent();
        }

        private void cleartextboxes()
        {
            username.Text = "";
            password.Text = "";
        }

        private void login_fcn()
        {
            int count = 0;
            MySqlConnection myConn = new MySqlConnection(constring);
            MySqlCommand myCmd = new MySqlCommand("procuserlogin", myConn);
            myCmd.Parameters.AddWithValue("@Puserid", username.Text.ToString());
            myCmd.Parameters.AddWithValue("@Ppassword", password.Text.ToString());
            myCmd.CommandType = CommandType.StoredProcedure;
            try
            {
                myConn.Open();
                using (MySqlDataReader read = myCmd.ExecuteReader())
                {

                    while (read.Read())
                    {
                        count = Convert.ToInt32(read["count"]);
                    }

                    if (count == 1)
                    {
                        this.Hide();
                        Form1 Registrar_Module = new Form1();
                        Registrar_Module.user.Text = this.username.Text;
                        Registrar_Module.Show();
                    }
                    else
                    {
                        MessageBox.Show("Invalid username or password");
                        cleartextboxes();
                        username.Select();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            finally
            {
                myConn.Dispose();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            login_fcn();
        }

        private void password_Enter(object sender, EventArgs e)
        {
            password.Text = "";
            password.ForeColor = Color.Black;
            password.UseSystemPasswordChar = true;
        }

        private void password_Leave(object sender, EventArgs e)
        {
            if (password.Text.Length == 0)
            {
                password.ForeColor = Color.Gray;

                password.Text = "Enter password";

                password.UseSystemPasswordChar = false;

                SelectNextControl(password, true, true, false, true);
            }
        }

        private void password_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                login_fcn();
            }
        }

        private void login_Load(object sender, EventArgs e)
        {
            if (password.Text.Length == 0)
            {
                password.ForeColor = Color.Gray;

                password.Text = "Enter password";

                password.UseSystemPasswordChar = false;

                SelectNextControl(password, true, true, false, true);
            }
        }
    }
}
