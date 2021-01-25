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

namespace Billing_Module
{
    public partial class daily_collection_wf : Form
    {
        string constring = "datasource=203.177.24.82;Initial Catalog=lsa_test1;port=3306;username=ing;password=123";
        //string constring = "datasource=192.168.0.17;Initial Catalog=lsa_test1;port=3306;username=ing;password=123";
        //string constring = "datasource=localhost;Initial Catalog=lsa_test1;port=3306;username=root;password=";

        public daily_collection_wf()
        {
            InitializeComponent();
        }

        private void show_Click(object sender, EventArgs e)
        {
            returnvalues();
        }

        void returnvalues()
        {
            DataTable Transaction = new DataTable();

            MySqlConnection myConn = new MySqlConnection(constring);
            myConn.Open();
            MySqlCommand myCmd = new MySqlCommand("procshowdailycashrpt", myConn);

            myCmd.Parameters.Add("@Pdate", MySqlDbType.Date).Value = dateTimePicker1.Value.Date.ToString("yyyy-MM-dd");
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

        private void print_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            dt.TableName = "Cash Report";
            dt.Columns.Add("Date");
            dt.Columns.Add("Transaction");
            dt.Columns.Add("Cash-in");
            dt.Columns.Add("Cash-out");
            dt.Columns.Add("Student ID");
            ds.Tables.Add(dt);

            foreach (DataGridViewRow dgv in dataGridView1.Rows)
            {
                DataRow row = ds.Tables["Cash Report"].NewRow();
                row["Date"] = dgv.Cells[0].Value;
                row["Transaction"] = dgv.Cells[1].Value;
                row["Cash-in"] = dgv.Cells[2].Value;
                row["Cash-out"] = dgv.Cells[3].Value;
                row["Student ID"] = dgv.Cells[4].Value;
                ds.Tables["Cash Report"].Rows.Add(row);
                ds.WriteXml("dcr.xml"); //change location to c in the future
            }

            ReportDocument report = new ReportDocument();
            report.Load(@"C:\Users\programmer\Documents\Visual Studio 2013\Projects\Billing Module\Billing Module\receipt_registrar.rpt");

            dcr_viewer f2 = new dcr_viewer();
            f2.crystalReportViewer1.ReportSource = report;

            f2.Show();
        }
    }
}
