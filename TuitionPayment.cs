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

namespace Finance_Module
{
    public partial class TuitionPayment : Form
    {
        private string constring = "datasource=203.177.24.82;Initial Catalog=lsa_system;port=3306;username=ing;password=123";
        private string currentYear = DateTime.Now.Year.ToString(), currentMonth = DateTime.Now.Month.ToString(), idnumber2;
        private string plancode = "", idnumber;
        private string cash1, cash2, check1, check2 = "";
        private string amount_in_words = "", crnumber = "";
        public string user;

        public TuitionPayment()
        {
            InitializeComponent();
        }

        public static string AmountInWords(double amount)
        {
            var n = (int)amount;

            if (n == 0)
                return "";
            else if (n > 0 && n <= 19)
            {
                var arr = new string[] { "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };
                return arr[n - 1] + " ";
            }
            else if (n >= 20 && n <= 99)
            {
                var arr = new string[] { "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };
                return arr[n / 10 - 2] + " " + AmountInWords(n % 10);
            }
            else if (n >= 100 && n <= 199)
            {
                return "One Hundred " + AmountInWords(n % 100);
            }
            else if (n >= 200 && n <= 999)
            {
                return AmountInWords(n / 100) + "Hundred " + AmountInWords(n % 100);
            }
            else if (n >= 1000 && n <= 1999)
            {
                return "One Thousand " + AmountInWords(n % 1000);
            }
            else if (n >= 2000 && n <= 999999)
            {
                return AmountInWords(n / 1000) + "Thousand " + AmountInWords(n % 1000);
            }
            else if (n >= 1000000 && n <= 1999999)
            {
                return "One Million " + AmountInWords(n % 1000000);
            }
            else if (n >= 1000000 && n <= 999999999)
            {
                return AmountInWords(n / 1000000) + "Million " + AmountInWords(n % 1000000);
            }
            else if (n >= 1000000000 && n <= 1999999999)
            {
                return "One Billion " + AmountInWords(n % 1000000000);
            }
            else
            {
                return AmountInWords(n / 1000000000) + "Billion " + AmountInWords(n % 1000000000);
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            StudentPaymentPlan student_payment_plan = new StudentPaymentPlan();
            student_payment_plan.ShowDialog();  
        }

        private void searchbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                searchname();
                dataGridView1.Select();
            }
        }

        void searchname()
        {
            MySqlConnection myConn = new MySqlConnection(constring);
            myConn.Open();
            MySqlCommand myCmd = new MySqlCommand("select_one_student_dgv_student_info", myConn);
            try
            {
                myCmd.Parameters.Add("@searchbox", MySqlDbType.VarChar, 100).Value = searchbox.Text.ToString();
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
                myConn.Close();
                myConn.Dispose();
            }
            searchbox.Focus();
        }

        private void click_table_contents()
        {
            DataGridViewRow dgr = dataGridView1.CurrentRow;
            this.idnumber2 = dgr.Cells["Column1"].Value.ToString();
            this.name.Text = dgr.Cells["Column3"].Value.ToString() + " " + dgr.Cells["Column4"].Value.ToString() + " " + dgr.Cells["Column2"].Value.ToString();

        }
        
        private void get_student_balance()
        {
            MySqlConnection myConn = new MySqlConnection(constring);
            MySqlCommand myCmd = new MySqlCommand("select_student_balance", myConn);
            myCmd.Parameters.AddWithValue("@accountid", idnumber2);
            myCmd.CommandType = CommandType.StoredProcedure;

            try
            {
                myConn.Open();
                using (MySqlDataReader read = myCmd.ExecuteReader())
                {
                    while (read.Read())
                    {
                        tuitionfees.Text = (read["tuition_fees"].ToString());
                        previousbalance.Text = (read["previous_balance"].ToString());
                        totalbalance.Text = (read["total_balance"].ToString());
                        amountdue.Text = (read["amount_due"].ToString());
                        
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

        private void get_student_amaount_due()
        {
            MySqlConnection myConn = new MySqlConnection(constring);
            MySqlCommand myCmd = new MySqlCommand("select_student_amount_due", myConn);
            myCmd.Parameters.AddWithValue("@accountid", idnumber2); 
            myCmd.Parameters.AddWithValue("@currentmonth", currentMonth);
            myCmd.CommandType = CommandType.StoredProcedure;


            try
            {
                myConn.Open();
                using (MySqlDataReader read = myCmd.ExecuteReader())
                {
                    while (read.Read())
                    {
                        amountdue.Text = (read["balance"].ToString());
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            click_table_contents();
            get_student_balance();
            get_student_amaount_due();
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                click_table_contents();
                get_student_balance();
                get_student_amaount_due();
            }
        }

        private void confirm_Click(object sender, EventArgs e)
        {
            fetchorno();
            confirm_payment();
        }

        void fetchorno()
        {
            MySqlConnection myConn = new MySqlConnection(constring);
            MySqlCommand myCmd = new MySqlCommand("select_or_number", myConn);
            try
            {
                myConn.Open();
                using (MySqlDataReader read = myCmd.ExecuteReader())
                {
                    while (read.Read())
                    {
                        this.crnumber = (read["official_receipt_number"].ToString());
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

        private void confirm_payment()
        {
            ReportDocument report = new ReportDocument();
            //report.Load(@"C:\Users\programmer\Documents\Visual Studio 2013\Projects\Billing Module\Billing Module\officialreceipt1.rpt");
            report.Load(@"C:\Users\programmer\Documents\Visual Studio 2013\Projects\Billing Module\Billing Module\officialreceipt2.rpt");

            ReportViewer reportviewer = new ReportViewer();
            reportviewer.crystalReportViewer1.ReportSource = report;

            TextObject crno1 = (TextObject)report.ReportDefinition.Sections["Section1"].ReportObjects["ccrno1"];
            TextObject crno2 = (TextObject)report.ReportDefinition.Sections["Section1"].ReportObjects["ccrno2"];
            TextObject name1 = (TextObject)report.ReportDefinition.Sections["Section1"].ReportObjects["name1"];
            TextObject name2 = (TextObject)report.ReportDefinition.Sections["Section1"].ReportObjects["name2"];
            TextObject idnum1 = (TextObject)report.ReportDefinition.Sections["Section1"].ReportObjects["idnum1"];
            TextObject idnum2 = (TextObject)report.ReportDefinition.Sections["Section1"].ReportObjects["idnum2"];
            TextObject ciw1 = (TextObject)report.ReportDefinition.Sections["Section3"].ReportObjects["ciw1"];
            TextObject ciw2 = (TextObject)report.ReportDefinition.Sections["Section3"].ReportObjects["ciw2"];
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
            TextObject ocash1 = (TextObject)report.ReportDefinition.Sections["Section4"].ReportObjects["cCash1"];
            TextObject ocash2 = (TextObject)report.ReportDefinition.Sections["Section4"].ReportObjects["cCash2"];
            TextObject ocheck1 = (TextObject)report.ReportDefinition.Sections["Section4"].ReportObjects["cCheck1"];
            TextObject ocheck2 = (TextObject)report.ReportDefinition.Sections["Section4"].ReportObjects["cCheck2"];
            TextObject checkno1 = (TextObject)report.ReportDefinition.Sections["Section4"].ReportObjects["cCheckno1"];
            TextObject checkno2 = (TextObject)report.ReportDefinition.Sections["Section4"].ReportObjects["cCheckno2"];
            TextObject bank1 = (TextObject)report.ReportDefinition.Sections["Section4"].ReportObjects["cbank1"];
            TextObject bank2 = (TextObject)report.ReportDefinition.Sections["Section4"].ReportObjects["cbank2"];

            crno1.Text = this.crnumber;
            crno2.Text = this.crnumber;
            name1.Text = name.Text;
            name2.Text = name.Text;
            idnum1.Text = idnumber;
            idnum2.Text = idnumber;
            ciw1.Text = amount_in_words;
            ciw2.Text = amount_in_words;
            //cash1.Text = cashin.Text;
            //cash2.Text = cashin.Text;
            //trans1.Text = transaction;
            //trans2.Text = transaction;
            //bal1.Text = transaction_bill;
            //bal2.Text = transaction_bill;
            //change1.Text = change.Text;
            //change2.Text = change.Text;
            //rem1.Text = rembal.Text;
            //rem2.Text = rembal.Text;
            ocash1.Text = this.cash1;
            ocash2.Text = this.cash2;
            ocheck1.Text = this.check1;
            ocheck2.Text = this.check2;
            checkno1.Text = checkno.Text;
            checkno2.Text = checkno.Text;
            bank1.Text = bank.Text;
            bank2.Text = bank.Text;
            reportviewer.Show();
        }
        
    }
}
