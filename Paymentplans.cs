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
    public partial class Paymentplans : Form
    {
        //string constring = "datasource=localhost;Initial Catalog=lsa_test1;port=3306;username=root;password=";
        //string constring = "datasource=192.168.0.17;Initial Catalog=lsa_test1;port=3306;username=ing;password=123";
        string constring = "datasource=203.177.24.82;Initial Catalog=lsa_test1;port=3306;username=ing;password=123";

        int plancode;
        float Penrollmentbalance, Pmidyearbalance, Pmonthlybalance, Ptotaltuitionbalance, Pdiscountamount, Ptotal;

        public Paymentplans()
        {
            InitializeComponent();
            plantype.Items.Add("A");
            plantype.Items.Add("B");
            plantype.Items.Add("C");
        }

        private void Save_Click(object sender, EventArgs e)
        {
            if (plantype.Text == "A" )
            {
                plancode = 1;
            }
            else if (plantype.Text == "B")
            {
                plancode = 2;
            }
            else if (plantype.Text == "C")
            {
                plancode = 3;
            }


            Penrollmentbalance = float.Parse(enrollbalance.Text);
            Pmidyearbalance = float.Parse(midyearbalance.Text);
            Pmonthlybalance = float.Parse(monthlybalance.Text);
            Ptotaltuitionbalance = float.Parse(total1.Text);
            Pdiscountamount = float.Parse(discount.Text);
            Ptotal = float.Parse(ftotal.Text);

            updatebalances();
           
            
            returnvalues();
            enrollbalance.Enabled = false;
            midyearbalance.Enabled = false;
            monthlybalance.Enabled = false;
            total1.Enabled = false;
            discount.Enabled = false;
            ftotal.Enabled = false;
        }

        void savenewbalances()
        {
            MySqlConnection myConn = new MySqlConnection(constring);
            myConn.Open();
            MySqlCommand myCmd = new MySqlCommand("procinsertpaymenttype", myConn);
            try
            {
                myCmd.Parameters.Add("@Ptypecode", MySqlDbType.Decimal).Value = plancode;
                myCmd.Parameters.Add("@Penrollmentbalance", MySqlDbType.Decimal).Value = Penrollmentbalance;
                myCmd.Parameters.Add("@Pmidyearbalance", MySqlDbType.Decimal).Value = Pmidyearbalance;
                myCmd.Parameters.Add("@Pmonthlybalance", MySqlDbType.Decimal).Value = Pmonthlybalance;
                myCmd.Parameters.Add("@Ptotaltuitionbalance", MySqlDbType.Decimal).Value = Ptotaltuitionbalance;
                myCmd.Parameters.Add("@Pdiscountamount", MySqlDbType.Decimal).Value = Pdiscountamount;
                myCmd.Parameters.Add("@Ptotal", MySqlDbType.Decimal).Value = Ptotal;
                myCmd.Parameters.Add("@Pyearlvl", MySqlDbType.VarChar, 45).Value = yearlevel.Text.ToString();
                myCmd.Parameters.Add("@Ptype", MySqlDbType.VarChar, 45).Value = plantype.Text.ToString();
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
        }

        void updatebalances()
        {
            MySqlConnection myConn = new MySqlConnection(constring);
            myConn.Open();
            MySqlCommand myCmd = new MySqlCommand("procupdatepaymenttype", myConn);
            try
            {
                myCmd.Parameters.Add("@Ptypecode", MySqlDbType.Decimal).Value = plancode;
                myCmd.Parameters.Add("@Penrollmentbalance", MySqlDbType.Decimal).Value = Penrollmentbalance;
                myCmd.Parameters.Add("@Pmidyearbalance", MySqlDbType.Decimal).Value = Pmidyearbalance;
                myCmd.Parameters.Add("@Pmonthlybalance", MySqlDbType.Decimal).Value = Pmonthlybalance;
                myCmd.Parameters.Add("@Ptotaltuitionbalance", MySqlDbType.Decimal).Value = Ptotaltuitionbalance;
                myCmd.Parameters.Add("@Pdiscountamount", MySqlDbType.Decimal).Value = Pdiscountamount;
                myCmd.Parameters.Add("@Ptotal", MySqlDbType.Decimal).Value = Ptotal;
                myCmd.Parameters.Add("@Pyearlvl", MySqlDbType.VarChar, 45).Value = yearlevel.Text.ToString();
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
        }

        void returnvalues()
        {
            if (plantype.Text == "Plan A")
            {
                plancode = 1;
            }
            else if (plantype.Text == "Plan B")
            {
                plancode = 2;
            }
            else if (plantype.Text == "Plan C")
            {
                plancode = 3;
            }

            
            MySqlConnection myConn = new MySqlConnection(constring);
            MySqlCommand myCmd = new MySqlCommand("procshowpaymenttype", myConn);
            myCmd.Parameters.AddWithValue("@Ptypecode", plancode);
            myCmd.Parameters.AddWithValue("@Pyearlvl", yearlevel.Text.ToString());
            myCmd.CommandType = CommandType.StoredProcedure;

            try
            {
                myConn.Open();
                using (MySqlDataReader read = myCmd.ExecuteReader())
                {
                    while (read.Read())
                    {
                        enrollbalance.Text = (read["fldenrollmentbalance"].ToString());
                        midyearbalance.Text = (read["fldmidyearbalance"].ToString());
                        monthlybalance.Text = (read["fldmonthlybalance"].ToString());
                        total1.Text = (read["fldtotaltuitionandfees"].ToString());
                        discount.Text = (read["flddiscountamount"].ToString());
                        ftotal.Text = (read["fldtotal"].ToString());
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

        private void plantype_SelectedIndexChanged(object sender, EventArgs e)
        {
            cleartxtboxes();
            returnvalues();
            if (enrollbalance.Text == "" || midyearbalance.Text == "" || monthlybalance.Text == "" || total1.Text == "" || discount.Text == "" || ftotal.Text == "")
            {
                enrollbalance.ReadOnly= false;
                midyearbalance.ReadOnly = false;
                monthlybalance.ReadOnly = false;
                total1.ReadOnly = false;
                discount.ReadOnly = false;
                ftotal.ReadOnly = false;
            }
            else
            {
                enrollbalance.ReadOnly = true;
                midyearbalance.ReadOnly = true;
                monthlybalance.ReadOnly = true;
                total1.ReadOnly = true;
                discount.ReadOnly = true;
                ftotal.ReadOnly = true;
            }

        }

        private void yearlevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            cleartxtboxes();
            returnvalues();
            if (enrollbalance.Text == "" || midyearbalance.Text == "" || monthlybalance.Text == "" || total1.Text == "" || discount.Text == "" || ftotal.Text == "")
            {
                enrollbalance.ReadOnly = false;
                midyearbalance.ReadOnly = false;
                monthlybalance.ReadOnly = false;
                total1.ReadOnly = false;
                discount.ReadOnly = false;
                ftotal.ReadOnly = false;
            }
            else
            {
                enrollbalance.ReadOnly = true;
                midyearbalance.ReadOnly = true;
                monthlybalance.ReadOnly = true;
                total1.ReadOnly = true;
                discount.ReadOnly = true;
                ftotal.ReadOnly = true;
            }
        }

        private void edit_Click(object sender, EventArgs e)
        {
            enrollbalance.ReadOnly = false;
            midyearbalance.ReadOnly = false;
            monthlybalance.ReadOnly = false;
            total1.ReadOnly = false;
            discount.ReadOnly = false;
            ftotal.ReadOnly = false;
            
        }

        private void savenew_Click(object sender, EventArgs e)
        {
            if (plantype.Text == "Plan A")
            {
                plancode = 1;
            }
            else if (plantype.Text == "Plan B")
            {
                plancode = 2;
            }
            else if (plantype.Text == "Plan C")
            {
                plancode = 3;
            }


            Penrollmentbalance = float.Parse(enrollbalance.Text);
            Pmidyearbalance = float.Parse(midyearbalance.Text);
            Pmonthlybalance = float.Parse(monthlybalance.Text);
            Ptotaltuitionbalance = float.Parse(total1.Text);
            Pdiscountamount = float.Parse(discount.Text);
            Ptotal = float.Parse(ftotal.Text);

            savenewbalances();

            returnvalues();
            enrollbalance.Enabled = false;
            midyearbalance.Enabled = false;
            monthlybalance.Enabled = false;
            total1.Enabled = false;
            discount.Enabled = false;
            ftotal.Enabled = false;
        }

        void cleartxtboxes()
        {
            enrollbalance.Text = "";
            midyearbalance.Text = "";
            monthlybalance.Text = "";
            total1.Text = "";
            discount.Text = "";
            ftotal.Text = "";
        }

    }
}
