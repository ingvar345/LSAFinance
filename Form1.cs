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
    public partial class Form1 : Form
    {
        //string constring = "datasource=192.168.0.17;Initial Catalog=lsa_test1;port=3306;username=ing;password=123";
        string constring = "datasource=203.177.24.82;Initial Catalog=lsa_test1;port=3306;username=ing;password=123";

        public Form1()
        {
            InitializeComponent();
        }

        private void paymentPlans2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Paymentplans Billing_Module = new Paymentplans();
            Billing_Module.ShowDialog();
        }

        private void cashieringToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cashiering Billing_Module = new Cashiering();
            Billing_Module.ShowDialog();
        }

        private void balanceBreakdownToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BalanceBreakdown2 Billing_Module = new BalanceBreakdown2();
            Billing_Module.ShowDialog();
        }

        private void dailyCashReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            receipt_registrar_wf Billing_Module = new receipt_registrar_wf();
            Billing_Module.ShowDialog();

        }

        private void tuitionFeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cashiering2 Billing_Module = new Cashiering2();
            Billing_Module.ShowDialog();
        }

        private void otherPaymentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cashiering3 Billing_Module = new Cashiering3();
            Billing_Module.ShowDialog();
        }

        private void studentLedgerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ledger Billing_Module = new ledger();
            Billing_Module.ShowDialog();
        }

        private void chargesAndDiscountsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Charges Billing_Module = new Charges();
            Billing_Module.ShowDialog();
        }

        private void recToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Receivables Billing_Module = new Receivables();
            Billing_Module.ShowDialog();
        }

        private void otherPaymentsNoLedgerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cashiering4 Billing_Module = new Cashiering4();
            Billing_Module.ShowDialog();
        }

        private void classListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            classlist Billing_Module = new classlist();
            Billing_Module.ShowDialog();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MySqlConnection myConn = new MySqlConnection(constring);
            myConn.Open();
            MySqlCommand myCmd = new MySqlCommand("procshowserid", myConn);
            MySqlDataReader myReader;
            try
            {
                myCmd.Parameters.Add("@Pusername", MySqlDbType.VarChar, 45).Value = user.Text;
                myCmd.CommandType = CommandType.StoredProcedure;
                myCmd.ExecuteNonQuery();

                myReader = myCmd.ExecuteReader();
                while (myReader.Read())
                {
                    userid.Text = myReader.GetString("fldidnumber");
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

        private void statementOfAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StatementofAccount Billing_Module = new StatementofAccount();
            Billing_Module.ShowDialog();
        }

        private void dailyCollectionReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            daily_collection_wf Billing_Module = new daily_collection_wf();
            Billing_Module.ShowDialog();
        }
    }
}
