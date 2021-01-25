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
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;
using System.Xml;

namespace Billing_Module
{
    public partial class StatementofAccount : Form
    {
        //string constring = "datasource=192.168.0.17;Initial Catalog=lsa_test1;port=3306;username=ing;password=123";
        private string constring = "datasource=203.177.24.82;Initial Catalog=lsa_test1;port=3306;username=ing;password=123";
        public string homeroom = "";
        public string paymentplan = "";
        public string idnum = "";
        public string duedate = "";
        public string yearlevel = "";
        public string midyear = "";
        public string monthly = "";

        public StatementofAccount()
        {
            InitializeComponent();
            this.dateTimePicker1.CustomFormat = "MMMM dd, yyyy";
            this.dateTimePicker1.Format = DateTimePickerFormat.Custom;
            this.dateTimePicker1.Value = DateTime.Now;
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
                name.Text = row.Cells["First Name"].Value.ToString() + " " + row.Cells["Middle Name"].Value.ToString() + " " + row.Cells["Last Name"].Value.ToString();
                getinitialtuition();
                selectfromtable();
            }
        }

        public void getinitialtuition()
        {
            MySqlConnection myConn = new MySqlConnection(constring);
            MySqlCommand myCmd = new MySqlCommand("procshowtuition", myConn);
            myCmd.Parameters.AddWithValue("@paytype", this.paymentplan);
            myCmd.Parameters.AddWithValue("@yearlevel", this.yearlevel);
            myCmd.CommandType = CommandType.StoredProcedure;

            try
            {
                myConn.Open();
                using (MySqlDataReader read = myCmd.ExecuteReader())
                {
                    while (read.Read())
                    {
                        total1.Text = (read["fldtotaltuitionandfees"].ToString());
                        this.midyear = (read["fldmidyearbalance"].ToString());
                        this.monthly = (read["fldmonthlybalance"].ToString());
                        
                        textBox1.Text = this.monthly;
                        double monthly = Double.TryParse(textBox1.Text, out monthly) ? monthly : 0.0;
                        textBox1.Text = String.Format(System.Globalization.CultureInfo.CurrentCulture, "{0:N}", monthly);
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

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DataGridViewRow dgr = dataGridView1.CurrentRow;
                string column0 = dgr.Cells[0].Value.ToString();
                this.idnumber.Text = column0;
                this.name.Text = dgr.Cells[2].Value.ToString() + " " + dgr.Cells[3].Value.ToString() + " " + dgr.Cells[1].Value.ToString();
                this.homeroom = dgr.Cells[6].Value.ToString();
                this.paymentplan = dgr.Cells[5].Value.ToString();
                this.yearlevel = dgr.Cells[4].Value.ToString();
                dataGridView1.CurrentCell = dataGridView1[0, 0];
                getinitialtuition();
                selectfromtable();
                //loadtable();
            }
        }

        private void selectfromtable()
        {
            MySqlConnection myConn = new MySqlConnection(constring);
            MySqlCommand myCmd = new MySqlCommand("procshowbill", myConn);
            myCmd.Parameters.AddWithValue("@pidnumber", idnumber.Text);
            myCmd.CommandType = CommandType.StoredProcedure;

            try
            {
                myConn.Open();
                using (MySqlDataReader read = myCmd.ExecuteReader())
                {
                    while (read.Read())
                    {
                        prevacc.Text = (read["fldprevacount"].ToString());
                        other_charges.Text = (read["fldspecialfees"].ToString());

                        tuition_less.Text = (read["fldtuition_less"].ToString());
                        scholar_less.Text = (read["fldscholar_less"].ToString());
                        others_less.Text = (read["fldother_less"].ToString());

                        double others = Double.TryParse(other_charges.Text, out others) ? others : 0.0;
                        double prevacc_var = Double.TryParse(prevacc.Text, out prevacc_var) ? prevacc_var : 0.0;
                        double total1_var = Double.TryParse(total1.Text, out total1_var) ? total1_var : 0.0;

                        double tuition_lessvar = Double.TryParse(tuition_less.Text, out tuition_lessvar) ? tuition_lessvar : 0.0;
                        double scholar_lessvar = Double.TryParse(scholar_less.Text, out scholar_lessvar) ? scholar_lessvar : 0.0;
                        double others_lessvar = Double.TryParse(others_less.Text, out others_lessvar) ? others_lessvar : 0.0;

                        totalbill.Text = (total1_var + prevacc_var + others - tuition_lessvar - scholar_lessvar - others_lessvar).ToString("#.##");
                        double totalbill_var = Double.TryParse(totalbill.Text, out totalbill_var) ? totalbill_var : 0.0;

                        prevacc.Text = String.Format(System.Globalization.CultureInfo.CurrentCulture, "{0:N}", prevacc_var);
                        total1.Text = String.Format(System.Globalization.CultureInfo.CurrentCulture, "{0:N}", total1_var);
                        other_charges.Text = String.Format(System.Globalization.CultureInfo.CurrentCulture, "{0:N}", others);
                        tuition_less.Text = String.Format(System.Globalization.CultureInfo.CurrentCulture, "{0:N}", tuition_lessvar);
                        scholar_less.Text = String.Format(System.Globalization.CultureInfo.CurrentCulture, "{0:N}", scholar_lessvar);
                        others_less.Text = String.Format(System.Globalization.CultureInfo.CurrentCulture, "{0:N}", others_lessvar);
                        totalbill.Text = String.Format(System.Globalization.CultureInfo.CurrentCulture, "{0:N}", totalbill_var);
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

        private void print_Click(object sender, EventArgs e)
        {
            
            ReportDocument report = new ReportDocument();
            report.Load(@"C:\Users\programmer\Documents\Visual Studio 2013\Projects\Billing Module\Billing Module\statement.rpt");

            statement_viewer f2 = new statement_viewer();
            f2.crystalReportViewer1.ReportSource = report;

            TextObject cName = (TextObject)report.ReportDefinition.Sections["Section1"].ReportObjects["cName"];
            TextObject cId = (TextObject)report.ReportDefinition.Sections["Section1"].ReportObjects["cId"];
            TextObject cHomeroom = (TextObject)report.ReportDefinition.Sections["Section1"].ReportObjects["cHomeroom"];
            TextObject cPlan = (TextObject)report.ReportDefinition.Sections["Section1"].ReportObjects["cPlan"];
            TextObject cYr = (TextObject)report.ReportDefinition.Sections["Section1"].ReportObjects["cYr"];
            TextObject cDue = (TextObject)report.ReportDefinition.Sections["Section1"].ReportObjects["cDue"];
            TextObject cTuitionfee = (TextObject)report.ReportDefinition.Sections["Section2"].ReportObjects["cTuitionfee"];
            TextObject cPrevacc = (TextObject)report.ReportDefinition.Sections["Section2"].ReportObjects["cPrevacc"];
            TextObject cTotalcurrent = (TextObject)report.ReportDefinition.Sections["Section2"].ReportObjects["cTotalcurrent"];
            TextObject cOthercharges = (TextObject)report.ReportDefinition.Sections["Section2"].ReportObjects["cOthercharges"];
            TextObject cTuitionpayments = (TextObject)report.ReportDefinition.Sections["Section2"].ReportObjects["cTuitionpayments"];
            TextObject cScholar = (TextObject)report.ReportDefinition.Sections["Section2"].ReportObjects["cScholar"];
            TextObject cOtherpayments = (TextObject)report.ReportDefinition.Sections["Section2"].ReportObjects["cOtherpayments"];
            TextObject cTotalBal = (TextObject)report.ReportDefinition.Sections["Section2"].ReportObjects["cTotalBal"];
            TextObject cAmountDue = (TextObject)report.ReportDefinition.Sections["Section2"].ReportObjects["cAmountDue"];

            cName.Text = name.Text;
            cId.Text = idnumber.Text;
            cPlan.Text = paymentplan;
            cYr.Text = yearlevel;
            cDue.Text = dateTimePicker1.Text.ToString();
            cHomeroom.Text = homeroom;
            cTotalcurrent.Text = totalbill.Text;
            cPrevacc.Text = prevacc.Text;
            cOthercharges.Text = other_charges.Text;
            cTuitionfee.Text = total1.Text;
            cTuitionpayments.Text = tuition_less.Text;
            cScholar.Text = scholar_less.Text;
            cOtherpayments.Text = others_less.Text;
            cTotalBal.Text = totalbill.Text;
            cAmountDue.Text = textBox1.Text;

            f2.Show();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                double balance_due_var = Double.TryParse(textBox1.Text, out balance_due_var) ? balance_due_var : 0.0;
                textBox1.Text = String.Format(System.Globalization.CultureInfo.CurrentCulture, "{0:N}", balance_due_var);
                print.Select();
            }
        }


    }
}
