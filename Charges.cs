using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;
using MySql.Data.MySqlClient;
using System.Text.RegularExpressions;

namespace Billing_Module
{
    public partial class Charges : Form
    {
        string constring = "datasource=203.177.24.82;Initial Catalog=lsa_test1;port=3306;username=ing;password=123";
        //string constring = "datasource=192.168.0.17;Initial Catalog=lsa_test1;port=3306;username=ing;password=123";
        //string constring = "datasource=localhost;Initial Catalog=lsa_test1;port=3306;username=root;password=";
        

        public Charges()
        {
            InitializeComponent();
            yearlvl.Items.Add("G01");
            yearlvl.Items.Add("G02");
            yearlvl.Items.Add("G03");
            yearlvl.Items.Add("G04");
            yearlvl.Items.Add("G05");
            yearlvl.Items.Add("G06");
            yearlvl.Items.Add("7");
            yearlvl.Items.Add("G08");
            yearlvl.Items.Add("G09");
            yearlvl.Items.Add("G07N");
            yearlvl.Items.Add("G08N");
            yearlvl.Items.Add("G09N");
            yearlvl.Items.Add("G10");
            yearlvl.Items.Add("G11");
            yearlvl.Items.Add("G12");

            acc_desc.Items.Add("ACADEMIC DISCOUNT");
            acc_desc.Items.Add("ATHLETIC DISCOUNT");
            acc_desc.Items.Add("SIBLING DISCOUNT");
            acc_desc.Items.Add("E-WARD");
            acc_desc.Items.Add("SPECIAL CLASS");
            acc_desc.Items.Add("ESC SCHOLARSHIP");
            acc_desc.Items.Add("ESC REFUND");
            acc_desc.Items.Add("PE UNIFORM");
            acc_desc.Items.Add("PE PANTS");
            acc_desc.Items.Add("PE SHIRT");
            acc_desc.Items.Add("ID CARD REPLACEMENT");
            acc_desc.Items.Add("LASAPFI");
            acc_desc.Items.Add("QUIPPER");
            acc_desc.Items.Add("SGS");


        }
        void resettextbox()
        {
            name.Text = "";
            idnumber.Text = "";
        }

        void loadtable1()
        {
            MySqlConnection myConn = new MySqlConnection(constring);
            myConn.Open();
            MySqlCommand myCmd = new MySqlCommand("procshowgrade7_2", myConn);
            try
            {
                myCmd.Parameters.Add("@Pschoolyear", MySqlDbType.VarChar, 45).Value = schyear.Text.ToString();
                myCmd.Parameters.Add("@Phomeroom", MySqlDbType.VarChar, 45).Value = homeroom.Text.ToString();
                myCmd.CommandType = CommandType.StoredProcedure;
                myCmd.ExecuteNonQuery();
                MySqlDataAdapter da = new MySqlDataAdapter(myCmd);
                da.SelectCommand = myCmd;
                DataTable dbdatasheet = new DataTable();
                da.Fill(dbdatasheet);
                BindingSource bSource = new BindingSource();

                bSource.DataSource = dbdatasheet;
                dataGridView1.DataSource = bSource;
                da.Update(dbdatasheet);
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

        void fillcombo1()
        {
            MySqlConnection myConn = new MySqlConnection(constring);
            myConn.Open();
            MySqlCommand myCmd = new MySqlCommand("procshowhomeroombygrade", myConn);
            MySqlDataReader myReader;
            try
            {
                myCmd.Parameters.Add("@Pgrade", MySqlDbType.VarChar, 50).Value = yearlvl.Text;
                myCmd.CommandType = CommandType.StoredProcedure;
                myCmd.ExecuteNonQuery();

                myReader = myCmd.ExecuteReader();
                while (myReader.Read())
                {
                    string sName = myReader.GetString("Homeroom");
                    homeroom.Items.Add(sName);
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

        void searchname()
        {
            MySqlConnection myConn = new MySqlConnection(constring);
            myConn.Open();
            MySqlCommand myCmd = new MySqlCommand("procshowstudent3", myConn);
            try
            {
                myCmd.Parameters.Add("@Psearchentry", MySqlDbType.VarChar, 100).Value = searchbox.Text.ToString();
                myCmd.CommandType = CommandType.StoredProcedure;
                myCmd.ExecuteNonQuery();
                MySqlDataAdapter da = new MySqlDataAdapter(myCmd);
                da.SelectCommand = myCmd;
                DataTable dbdatasheet = new DataTable();
                da.Fill(dbdatasheet);
                BindingSource bSource = new BindingSource();

                bSource.DataSource = dbdatasheet;
                dataGridView1.DataSource = bSource;
                da.Update(dbdatasheet);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            finally
            {
                myConn.Dispose();
            }
            searchbox.Focus();
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Double value;
                if (Double.TryParse(amount.Text, out value))
                    amount.Text = String.Format(System.Globalization.CultureInfo.CurrentCulture, "{0:N}", value);
                else
                    amount.Text = String.Empty;
            }
        }

        private void searchbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                searchname();
                dataGridView1.Select();
            }
        }

        private void yearlvl_SelectedIndexChanged(object sender, EventArgs e)
        {
            homeroom.Items.Clear();
            fillcombo1();
        }

        private void homeroom_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadtable1();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                idnumber.Text = row.Cells["Id number"].Value.ToString();
                name.Text = row.Cells["Last Name"].Value.ToString() + ", " + row.Cells["First Name"].Value.ToString() + " " + row.Cells["Middle Name"].Value.ToString();
                //yearlvl2.Text = row.Cells["Year Level"].Value.ToString();            
            }

            //returnvalues();

            if (checkBox1.Checked)
            {
                idnumber.Text = "";
                name.Text = "";
            }
        }

        private void debit_Click(object sender, EventArgs e)
        {
            if(checkBox1.Checked)
            {
                // for-loop table entries
                //
                //try
                //{
                //    for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                //    {
                //        MySqlConnection myConn = new MySqlConnection(constring);
                //        myConn.Open();
                //        MySqlCommand myCmd = new MySqlCommand("procinsertcharges", myConn);
                //        myCmd.Parameters.AddWithValue("@Pidnumber", dataGridView1.Rows[i].Cells[0].Value);
                //        myCmd.Parameters.Add("@Ptransaction", MySqlDbType.VarChar, 100).Value = account;
                //        myCmd.Parameters.Add("@Pamount", MySqlDbType.Decimal).Value = amount.Text.ToString();

                //        myCmd.CommandType = CommandType.StoredProcedure;
                //        myCmd.ExecuteNonQuery();
                //        myConn.Close();
                //    }
                //}

                //catch (Exception ex)
                //{
                //    MessageBox.Show(ex.Message);
                //}
            }
            else if (!checkBox1.Checked)
            {
                MySqlConnection myConn = new MySqlConnection(constring);
                myConn.Open();
                MySqlCommand myCmd = new MySqlCommand("procinsertcharges", myConn);
                try
                {
                    myCmd.Parameters.Add("@Pidnumber", MySqlDbType.VarChar, 9).Value = idnumber.Text.ToString();
                    myCmd.Parameters.Add("@Ptransaction", MySqlDbType.VarChar, 100).Value = acc_desc.Text.ToString();
                    myCmd.Parameters.Add("@Pamount", MySqlDbType.Decimal).Value = amount.Text.ToString();
                    myCmd.CommandType = CommandType.StoredProcedure;
                    myCmd.ExecuteNonQuery();
                    myConn.Close();
                    MessageBox.Show("Saved!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    myConn.Dispose();
                }
                resettextbox();
            }
        }

        private void credit_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    MySqlConnection myConn = new MySqlConnection(constring);
                    myConn.Open();
                    MySqlCommand myCmd = new MySqlCommand("procinsertdiscounts", myConn);
                    myCmd.Parameters.AddWithValue("@Pidnumber", dataGridView1.Rows[i].Cells[0].Value);
                    myCmd.Parameters.Add("@Ptransaction", MySqlDbType.VarChar, 100).Value = acc_desc.Text.ToString();
                    myCmd.Parameters.Add("@Pamount", MySqlDbType.Decimal).Value = amount.Text.ToString();

                    myCmd.CommandType = CommandType.StoredProcedure;
                    myCmd.ExecuteNonQuery();
                    myConn.Close();
                }
            }
            else if (!checkBox1.Checked)
            {
                MySqlConnection myConn = new MySqlConnection(constring);
                myConn.Open();
                MySqlCommand myCmd = new MySqlCommand("procinsertdiscounts", myConn);
                try
                {
                    myCmd.Parameters.Add("@Pidnumber", MySqlDbType.VarChar, 9).Value = idnumber.Text.ToString();
                    myCmd.Parameters.Add("@Ptransaction", MySqlDbType.VarChar, 100).Value = acc_desc.Text.ToString(); ;
                    myCmd.Parameters.Add("@Pamount", MySqlDbType.Decimal).Value = amount.Text.ToString();
                    myCmd.CommandType = CommandType.StoredProcedure;
                    myCmd.ExecuteNonQuery();
                    myConn.Close();
                    MessageBox.Show("Saved!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    myConn.Dispose();
                }
                resettextbox();

            }
        }


        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                dataGridView1.ClearSelection();  
                idnumber.Text = "";
                name.Text = "";
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                yearlvl.Text = "";
                schyear.Text = "";
                homeroom.Text = "";

                searchbox.ReadOnly = false;
                yearlvl.Enabled = false;
                schyear.ReadOnly = true;
                homeroom.Enabled = false;
            }

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                searchbox.Text = "";
                searchbox.ReadOnly = true;
                yearlvl.Enabled = true;
                schyear.ReadOnly = false;
                homeroom.Enabled = true;
            }
        }

    }
}
