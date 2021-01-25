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
    public partial class ledger : Form
    {
        //string constring = "datasource=192.168.0.17;Initial Catalog=lsa_test1;port=3306;username=ing;password=123";
        string constring = "datasource=203.177.24.82;Initial Catalog=lsa_test1;port=3306;username=ing;password=123";
        
        public ledger()
        {
            InitializeComponent();
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

        void loadtable()
        {
            MySqlConnection myConn = new MySqlConnection(constring);
            myConn.Open();
            MySqlCommand myCmd = new MySqlCommand("procshowledger", myConn);
            try
            {
                myCmd.Parameters.Add("@Pidnumber", MySqlDbType.VarChar, 9).Value = idnumber.Text.ToString();
                myCmd.CommandType = CommandType.StoredProcedure;
                myCmd.ExecuteNonQuery();
                MySqlDataAdapter da = new MySqlDataAdapter(myCmd);
                da.SelectCommand = myCmd;
                DataTable dbdatasheet = new DataTable();
                da.Fill(dbdatasheet);
                dataGridView2.DataSource = dbdatasheet;
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                idnumber.Text = row.Cells["Id number"].Value.ToString();
                name.Text = row.Cells["First Name"].Value.ToString() + " " + row.Cells["Middle Name"].Value.ToString() + " " + row.Cells["Last Name"].Value.ToString();
                loadtable();
            }
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.KeyCode == Keys.Enter)
            {
                DataGridViewRow dgr = dataGridView1.CurrentRow;
                string column0 = dgr.Cells[0].Value.ToString();
                idnumber.Text = column0;
                name.Text = dgr.Cells[2].Value.ToString() + " " + dgr.Cells[3].Value.ToString() + " " + dgr.Cells[1].Value.ToString();
                dataGridView1.CurrentCell = dataGridView1[0,0];
                loadtable();
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            dt.TableName = "Student Ledger";
            dt.Columns.Add("Account Description");
            dt.Columns.Add("Debit");
            dt.Columns.Add("Credit");
            dt.Columns.Add("Balance");
            ds.Tables.Add(dt);

            foreach (DataGridViewRow dgv in dataGridView2.Rows)
            {
                DataRow row = ds.Tables["Student Ledger"].NewRow();
                row["Account Description"] = dgv.Cells[0].Value;
                row["Debit"] = dgv.Cells[1].Value;
                row["Credit"] = dgv.Cells[2].Value;
                row["Balance"] = dgv.Cells[3].Value;
                ds.Tables["Student Ledger"].Rows.Add(row);
                ds.WriteXml("stud_ledger.xml"); //change location to c in the future
            }

            ReportDocument report = new ReportDocument();
            report.Load(@"C:\Users\programmer\Documents\Visual Studio 2013\Projects\Billing Module\Billing Module\ledger_cr.rpt");

            receiptviewer f2 = new receiptviewer();
            f2.crystalReportViewer1.ReportSource = report;

            TextObject cName = (TextObject)report.ReportDefinition.Sections["Section1"].ReportObjects["cName"];
            TextObject cidnumber = (TextObject)report.ReportDefinition.Sections["Section1"].ReportObjects["cidnumber"];
            cName.Text = name.Text;
            cidnumber.Text = idnumber.Text;
            f2.Show();
        }

        
    }
}
