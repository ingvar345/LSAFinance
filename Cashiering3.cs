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
    public partial class Cashiering3 : Form
    {
        string constring = "datasource=203.177.24.82;Initial Catalog=lsa_test1;port=3306;username=ing;password=123";
        //string constring = "datasource=localhost;Initial Catalog=lsa_test1;port=3306;username=root;password=";
        //string constring = "datasource=192.168.0.17;Initial Catalog=lsa_test1;port=3306;username=ing;password=123";
        //double totalbal = 0;


        List<string> transacetions = new List<string>();

        public Cashiering3()
        {
            InitializeComponent();
            balance.Text = "0.00";

            //acc_desc.Items.Add("ACADEMIC DISCOUNT");
            //acc_desc.Items.Add("ATHLETIC DISCOUNT");
            //acc_desc.Items.Add("SIBLING DISCOUNT");
            //acc_desc.Items.Add("E-WARD");
            //acc_desc.Items.Add("SPECIAL CLASS");
            //acc_desc.Items.Add("ESC SCHOLARSHIP");
            //acc_desc.Items.Add("ESC REFUND");
            //acc_desc.Items.Add("PE UNIFORM");
            //acc_desc.Items.Add("PE PANTS");
            //acc_desc.Items.Add("PE SHIRT");
            //acc_desc.Items.Add("ID CARD REPLACEMENT");
            //acc_desc.Items.Add("LASAPFI");
            //acc_desc.Items.Add("QUIPPER");
            //acc_desc.Items.Add("SGS");
        }

        void cleartxtboxes()
        {
            //    enrollbalance.Text = "";
            //    midyearbalance.Text = "";
            //    monthlybalance.Text = "";
            //total1.Text = "";
            //discount.Text = "";
            //totalbill.Text = "";
            //schdiscount.Text = "";

            cashin.Text = "";
            change.Text = "";

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

        void returnvalues()
        {
            MySqlConnection myConn = new MySqlConnection(constring);
            MySqlCommand myCmd = new MySqlCommand("procshowbalances_oth", myConn);
            myCmd.Parameters.AddWithValue("@Pyearlvl", yearlvl.Text.ToString());
            myCmd.CommandType = CommandType.StoredProcedure;

            try
            {
                myConn.Open();
                using (MySqlDataReader read = myCmd.ExecuteReader())
                {
                    while (read.Read())
                    {
                        //total1.Text = (read["fldpeuniformshirt"].ToString());
                    }
                    read.Close();
                    read.Dispose();
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

        private void searchbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                searchname();
                dataGridView1.Select();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                idnumber.Text = row.Cells["Id number"].Value.ToString();
                name.Text = row.Cells["Last Name"].Value.ToString() + ", " + row.Cells["First Name"].Value.ToString() + " " + row.Cells["Middle Name"].Value.ToString();
                yearlvl.Text = row.Cells["Year Level"].Value.ToString();
            }
            returnvalues();
        }

        

        private void cashin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                double paymentval = Double.TryParse(cashin.Text, out paymentval) ? paymentval : 0.0;
                double totalbill_var = Double.TryParse(balance.Text, out totalbill_var) ? totalbill_var : 0.0;
                if (paymentval < totalbill_var)
                {
                    MessageBox.Show("Payment is lesser than balance");
                    change.Text = "0.00";
                    button1.Enabled = false;
                }
                else {
                    change.Text = (paymentval - totalbill_var).ToString("#.##");
                    button1.Enabled = true; 
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            insertupdatebill();
            cleartxtboxes();
        }

        private void insertupdatebill()
        {
            //transaction type


            double cash_in = Double.TryParse(cashin.Text, out cash_in) ? cash_in : 0.0;
            double cash_out = Double.TryParse(change.Text, out cash_out) ? cash_out : 0.0;
            //double bill = Double.TryParse(totalbill.Text, out bill) ? bill : 0.0;

            MySqlConnection myConn = new MySqlConnection(constring);
            myConn.Open();
            MySqlCommand myCmd = new MySqlCommand("procinserttransac", myConn);
            try
            {
                myCmd.Parameters.Add("@Pidnumber", MySqlDbType.VarChar, 9).Value = idnumber.Text;
                myCmd.Parameters.Add("@Ptransaction", MySqlDbType.VarChar, 45).Value = acc_desc.ToString();
                myCmd.Parameters.Add("@Pamountin", MySqlDbType.Decimal).Value = cash_in;
                myCmd.Parameters.Add("@Pamountout", MySqlDbType.Decimal).Value = cash_out;
                myCmd.Parameters.Add("@Pcrno", MySqlDbType.Decimal).Value = cr_no.Text;
                //myCmd.Parameters.Add("@Pbill", MySqlDbType.Decimal).Value = totalbill;
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
            ReportDocument report = new ReportDocument();
            //report.Load(@"C:\Users\programmer\Documents\Visual Studio 2013\Projects\Billing Module\Billing Module\officialreceipt1.rpt");
            report.Load(@"C:\Users\programmer\Documents\Visual Studio 2013\Projects\Billing Module\Billing Module\officialreceipt1.rpt");

            receiptviewer f2 = new receiptviewer();
            f2.crystalReportViewer1.ReportSource = report;

            TextObject name1 = (TextObject)report.ReportDefinition.Sections["Section2"].ReportObjects["name1"];
            TextObject name2 = (TextObject)report.ReportDefinition.Sections["Section2"].ReportObjects["name2"];
            TextObject idnum1 = (TextObject)report.ReportDefinition.Sections["Section2"].ReportObjects["idnum1"];
            TextObject idnum2 = (TextObject)report.ReportDefinition.Sections["Section2"].ReportObjects["idnum2"];
            TextObject cash1 = (TextObject)report.ReportDefinition.Sections["Section3"].ReportObjects["cashin1"];
            TextObject cash2 = (TextObject)report.ReportDefinition.Sections["Section3"].ReportObjects["cashin2"];
            TextObject trans1 = (TextObject)report.ReportDefinition.Sections["Section4"].ReportObjects["transaction1"];
            TextObject trans2 = (TextObject)report.ReportDefinition.Sections["Section4"].ReportObjects["transaction2"];
            TextObject bal1 = (TextObject)report.ReportDefinition.Sections["Section4"].ReportObjects["balance1"];
            TextObject bal2 = (TextObject)report.ReportDefinition.Sections["Section4"].ReportObjects["balance2"];
            TextObject change1 = (TextObject)report.ReportDefinition.Sections["Section4"].ReportObjects["change1"];
            TextObject change2 = (TextObject)report.ReportDefinition.Sections["Section4"].ReportObjects["change2"];
            TextObject rem1 = (TextObject)report.ReportDefinition.Sections["Section4"].ReportObjects["rembal1"];
            TextObject rem2 = (TextObject)report.ReportDefinition.Sections["Section4"].ReportObjects["rembal2"];
            name1.Text = name.Text;
            name2.Text = name.Text;
            idnum1.Text = idnumber.Text;
            idnum2.Text = idnumber.Text;
            cash1.Text = cashin.Text;
            cash2.Text = cashin.Text;
            trans1.Text = acc_desc.Text;
            trans2.Text = acc_desc.Text;
            //bal1.Text = total1.Text;
            //bal2.Text = total1.Text;
            change1.Text = change.Text;
            change2.Text = change.Text;
            //rem1.Text = change.Text;
            //rem2.Text = change.Text;
            f2.Show();
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DataGridViewRow dgr = dataGridView1.CurrentRow;
                idnumber.Text = dgr.Cells["Id number"].Value.ToString();
                name.Text = dgr.Cells["Last Name"].Value.ToString() + ", " + dgr.Cells["First Name"].Value.ToString() + " " + dgr.Cells["Middle Name"].Value.ToString();
                yearlvl.Text = dgr.Cells["Year Level"].Value.ToString();
                returnvalues();
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        private void cashin_Leave(object sender, EventArgs e)
        {
            //Double value;
            //if (Double.TryParse(cashin.Text, out value))
            //    cashin.Text = String.Format(System.Globalization.CultureInfo.CurrentCulture, "{0:N}", value);
            //else
            //    cashin.Text = String.Empty;
        }

        private void change_Leave(object sender, EventArgs e)
        {
            //Double value;
            //if (Double.TryParse(change.Text, out value))
            //    change.Text = String.Format(System.Globalization.CultureInfo.CurrentCulture, "{0:N}", value);
            //else
            //    change.Text = String.Empty;
        }


    }
}
