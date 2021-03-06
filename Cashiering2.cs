﻿using System;
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
    public partial class Cashiering2 : Form
    {
        private string plancode = "";
        private string cash1, cash2, check1, check2 = "";
        private string amount_in_words = "", crnumber = "";

        //private string constring = "datasource=192.168.0.17;Initial Catalog=lsa_test1;port=3306;username=ing;password=123";
        private string constring = "datasource=203.177.24.82;Initial Catalog=lsa_test1;port=3306;username=ing;password=123";
        //private string constring = "datasource=localhost;Initial Catalog=lsa_test1;port=3306;username=root;password=";

        public Cashiering2()
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

        void insertnewledger()
        {
            //payment plan
            if (paymentplan.Text == "A")
            {
                this.plancode = "A";
            }
            else if (paymentplan.Text == "B")
            {
                this.plancode = "B";
            }
            else if (paymentplan.Text == "C")
            {
                this.plancode = "C";
            }

            MySqlConnection myConn = new MySqlConnection(constring);
            myConn.Open();
            MySqlCommand myCmd = new MySqlCommand("procinsertnewledger", myConn);
            try
            {
                myCmd.Parameters.Add("@Pidnumber", MySqlDbType.VarChar, 9).Value = idnumber.Text;
                myCmd.Parameters.Add("@Pyearlvl", MySqlDbType.VarChar, 9).Value = yearlvl.Text;
                myCmd.Parameters.Add("@Ppaymentcode", MySqlDbType.VarChar, 9).Value = plancode;
                myCmd.Parameters.Add("@Ppaymenttype", MySqlDbType.VarChar, 9).Value = paymentplan.Text;
                myCmd.Parameters.Add("@Pschyear", MySqlDbType.VarChar, 50).Value = schyear.Text.ToString();
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

        void fetchorno()
        {
            MySqlConnection myConn = new MySqlConnection(constring);
            MySqlCommand myCmd = new MySqlCommand("procfetchorno", myConn);
            try
            {
                myConn.Open();
                using (MySqlDataReader read = myCmd.ExecuteReader())
                {
                    while (read.Read())
                    {
                        this.crnumber = (read["fldornumber"].ToString());
                        cr_no.Text = this.crnumber;
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
        
        void insertupdatebill()
        {
            double prevaccbal = Double.TryParse(prevacc.Text, out prevaccbal) ? prevaccbal : 0.0;
            double totalbal = Double.TryParse(total1.Text, out totalbal) ? totalbal : 0.0;
            decimal balancedueval = Decimal.TryParse(balancedue.Text, out balancedueval) ? balancedueval : 0;
            decimal ptotalbill = Decimal.TryParse(rembal.Text, out ptotalbill) ? ptotalbill : 0;
            

            double cash_in = Double.TryParse(cashin.Text, out cash_in) ? cash_in : 0.0;
            double cash_out = Double.TryParse(change.Text, out cash_out) ? cash_out : 0.0;

            double yrlvl = Double.TryParse(yearlvl.Text, out yrlvl) ? yrlvl : 0.0;

            double kinderval = 0.0, gradeschoolval = 0.0, highschoolval = 0.0, seniorhsval = 0.0, nighthsval = 0.0, othersval = 0.0; 
            
            amount_in_words = AmountInWords(cash_in) + " Pesos only";

            
            //transaction type
            string transaction = "Tuition Payment";
            string transaction_bill = "";

            transaction_bill = String.Format(System.Globalization.CultureInfo.CurrentCulture, "{0:N}", balancedueval);
            

            //yearlvl transaction
            if (yearlvl.Text == "K-1" || yearlvl.Text == "K-2")
            {
                kinderval = cash_in - cash_out;
                gradeschoolval = 0;
                highschoolval = 0;
                seniorhsval = 0;
                nighthsval = 0;
                othersval = 0;
            }
            else if (yearlvl.Text == "01" || yearlvl.Text == "02" || yearlvl.Text == "03" || yearlvl.Text == "04" || yearlvl.Text == "05" || yearlvl.Text == "06")
            {

                kinderval = 0;
                gradeschoolval = cash_in - cash_out;
                highschoolval = 0;
                seniorhsval = 0;
                nighthsval = 0;
                othersval = 0;
            }
            else if (yearlvl.Text == "07" || yearlvl.Text == "08" || yearlvl.Text == "09" || yearlvl.Text == "10")
            {
                kinderval = 0;
                gradeschoolval = 0;
                highschoolval = cash_in - cash_out;
                seniorhsval = 0;
                nighthsval = 0;
                othersval = 0;
            }
            else if (yearlvl.Text == "07N" || yearlvl.Text == "08N" || yearlvl.Text == "09N" || yearlvl.Text == "10N")
            {
                kinderval = 0;
                gradeschoolval = 0;
                highschoolval = 0;
                seniorhsval = cash_in - cash_out;
                nighthsval = 0;
                othersval = 0;
            }
            else if (yearlvl.Text == "11" || yearlvl.Text == "12")
            {
                kinderval = 0;
                gradeschoolval = 0;
                highschoolval = 0;
                seniorhsval = cash_in - cash_out;
                nighthsval = 0;
                othersval = 0;
            }

            //database
            MySqlConnection myConn = new MySqlConnection(constring);
            myConn.Open();
            MySqlCommand myCmd = new MySqlCommand("procinsertupdatebill", myConn);
            try
            {
                myCmd.Parameters.Add("@Pidnumber", MySqlDbType.VarChar, 9).Value = idnumber.Text.ToString();
                myCmd.Parameters.Add("@Pyearlevel", MySqlDbType.VarChar, 9).Value = yearlvl.Text.ToString();
                myCmd.Parameters.Add("@Pprevacc", MySqlDbType.Decimal).Value = prevaccbal;
                myCmd.Parameters.Add("@Ptotal1", MySqlDbType.Decimal).Value = totalbal;
                myCmd.Parameters.Add("@Ppaymentcode", MySqlDbType.VarChar, 9).Value = this.plancode;
                myCmd.Parameters.Add("@Ptotalbill", MySqlDbType.Decimal).Value = ptotalbill;
                myCmd.Parameters.Add("@Pcrno", MySqlDbType.Decimal).Value = this.crnumber.ToString();

                myCmd.Parameters.Add("@Ptransaction", MySqlDbType.VarChar, 45).Value = transaction.ToString();
                myCmd.Parameters.Add("@Pamountin", MySqlDbType.Decimal).Value = cash_in;
                myCmd.Parameters.Add("@Pamountout", MySqlDbType.Decimal).Value = cash_out;

                myCmd.Parameters.Add("@Pkinder", MySqlDbType.Decimal).Value = kinderval;
                myCmd.Parameters.Add("@Pgradeschool", MySqlDbType.Decimal).Value = gradeschoolval;
                myCmd.Parameters.Add("@Phighschool", MySqlDbType.Decimal).Value = highschoolval;
                myCmd.Parameters.Add("@Pseniorhs", MySqlDbType.Decimal).Value = seniorhsval;
                myCmd.Parameters.Add("@Pnighths", MySqlDbType.Decimal).Value = nighthsval;
                myCmd.Parameters.Add("@Pothers", MySqlDbType.Decimal).Value = othersval;
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
            report.Load(@"C:\Users\programmer\Documents\Visual Studio 2013\Projects\Billing Module\Billing Module\officialreceipt2.rpt");

            receiptviewer f2 = new receiptviewer();
            f2.crystalReportViewer1.ReportSource = report;

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
            idnum1.Text = idnumber.Text;
            idnum2.Text = idnumber.Text;
            ciw1.Text = amount_in_words;
            ciw2.Text = amount_in_words;
            cash1.Text = cashin.Text;
            cash2.Text = cashin.Text;
            trans1.Text = transaction;
            trans2.Text = transaction;
            bal1.Text = transaction_bill;
            bal2.Text = transaction_bill;
            change1.Text = change.Text;
            change2.Text = change.Text;
            rem1.Text = rembal.Text;
            rem2.Text = rembal.Text;
            ocash1.Text = this.cash1;
            ocash2.Text = this.cash2;
            ocheck1.Text = this.check1;
            ocheck2.Text = this.check2;
            checkno1.Text = checkno.Text;
            checkno2.Text = checkno.Text;
            bank1.Text = bank.Text;
            bank2.Text = bank.Text;
            f2.Show();
        }

        void returnvalues()
        {
            string enrollmentbal;
            if (paymentplan.Text == "A")
            {
                this.plancode = "A";
            }
            else if (paymentplan.Text == "B")
            {
                this.plancode = "B";
            }
            else if (paymentplan.Text == "C")
            {
                this.plancode = "C";
            }

            
            MySqlConnection myConn = new MySqlConnection(constring);
            MySqlCommand myCmd = new MySqlCommand("procshowpaymenttype", myConn);
            myCmd.Parameters.AddWithValue("@Ptypecode", plancode);
            myCmd.Parameters.AddWithValue("@Pyearlvl", yearlvl.Text.ToString());
            myCmd.CommandType = CommandType.StoredProcedure;
            
            try
            {
                myConn.Open();
                using (MySqlDataReader read = myCmd.ExecuteReader())
                {
                    while (read.Read())
                    {
                        enrollmentbal = (read["fldenrollmentbalance"].ToString());

                        total1.Text = (read["fldtotaltuitionandfees"].ToString());

                        double total1_var = Double.TryParse(total1.Text, out total1_var) ? total1_var : 0.0;
                        double enbal = Convert.ToDouble(enrollmentbal);


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
                myConn.Close();
                myConn.Dispose();
            }
        }

        private void selectfromtable()
        {
            DataGridViewRow dgr = dataGridView1.CurrentRow;
            idnumber.Text = dgr.Cells["Id number"].Value.ToString();
            name.Text = dgr.Cells["Last Name"].Value.ToString() + ", " + dgr.Cells["First Name"].Value.ToString() + " " + dgr.Cells["Middle Name"].Value.ToString();
            yearlvl.Text = dgr.Cells["Year Level"].Value.ToString();

            string plancodetemp = dgr.Cells["Code"].Value.ToString();

            if (plancodetemp == "A")
            {
                paymentplan.Text = "A";
            }
            else if (plancodetemp == "B")
            {
                paymentplan.Text = "B";
            }
            else if (plancodetemp == "C")
            {
                paymentplan.Text = "C";
            }

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
                        total1.Text = (read["fldtuitionandfees"].ToString());

                        double prevacc_var = Double.TryParse(prevacc.Text, out prevacc_var) ? prevacc_var : 0.0;
                        double total1_var = Double.TryParse(total1.Text, out total1_var) ? total1_var : 0.0;

                        totalbill.Text = (total1_var + prevacc_var).ToString("#.##");
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
                myConn.Close();
                myConn.Dispose();
            }
        }

        void cleartxtboxes()
        {
            total1.Text = "";
            totalbill.Text = "";
            cashin.Text = "";
            change.Text = "";
            rembal.Text = "";
        }

        void searchname()
        {
            MySqlConnection myConn = new MySqlConnection(constring);
            myConn.Open();
            MySqlCommand myCmd = new MySqlCommand("procshowstudent5", myConn);
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
                myConn.Close();
                myConn.Dispose();
            }
            searchbox.Focus();
        }

        private void searchbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                searchname();
                dataGridView1.Select();
                //if (total1.Text == "")
                //{
                //    returnvalues();
                //    dataGridView1.Select();
                //}
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                selectfromtable();
            //    DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
            //    idnumber.Text = row.Cells["Id number"].Value.ToString();
            //    name.Text = row.Cells["Last Name"].Value.ToString() + ", " + row.Cells["First Name"].Value.ToString() + " " + row.Cells["Middle Name"].Value.ToString();
            //    yearlvl.Text = row.Cells["Year Level"].Value.ToString();


            //    string plancodetemp = row.Cells["Code"].Value.ToString();

            //    if (plancodetemp == "1")
            //    {
            //        paymentplan.Text = "Plan A";
            //    }
            //    else if (plancodetemp == "2")
            //    {
            //        paymentplan.Text = "Plan B";
            //    }
            //    else if (plancodetemp == "3")
            //    {
            //        paymentplan.Text = "Plan C";
            //    }
            //    //homeroom.Text = row.Cells["Middle Name"].Value.ToString();
            //    //paymentplan.Text = row.Cells["Homeroom"].Value.ToString();
            //}

            ////returnvalues();

            //MySqlConnection myConn = new MySqlConnection(constring);
            //MySqlCommand myCmd = new MySqlCommand("procshowbill", myConn);
            //myCmd.Parameters.AddWithValue("@pidnumber", idnumber.Text);
            //myCmd.CommandType = CommandType.StoredProcedure;

            //try
            //{
            //    myConn.Open();
            //    using (MySqlDataReader read = myCmd.ExecuteReader())
            //    {
            //        while (read.Read())
            //        {
            //            prevacc.Text = (read["fldprevacount"].ToString());
            //            total1.Text = (read["fldtuitionandfees"].ToString());
            //            //sch_fee.Text = (read["fldschoolfees"].ToString());
            //            //sp_fee.Text = (read["fldspecialfees"].ToString());
            //            //tuit_fee.Text = (read["fldspecialfees"].ToString());
            //            //discount.Text = (read["fldplandiscount"].ToString());
            //            //schdiscount.Text = (read["fldschdiscount"].ToString());
            //            //totalbill.Text = (read["fldtotalbalance"].ToString());
            //            //schdiscount.Text = (read["fldschdiscount"].ToString());

            //            double prevacc_var = Double.TryParse(prevacc.Text, out prevacc_var) ? prevacc_var : 0.0;
            //            double total1_var = Double.TryParse(total1.Text, out total1_var) ? total1_var : 0.0;

            //            totalbill.Text = (total1_var + prevacc_var ).ToString("#.##");
            //        }
            //        read.Close();
            //        read.Dispose();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}

            //finally
            //{
            //    myConn.Dispose();
            }
        }

        private void check_Click(object sender, EventArgs e)
        {
            insertnewledger();
            selectfromtable();
        }

        private void paymentplan_SelectedIndexChanged(object sender, EventArgs e)
        {
            cleartxtboxes();
            returnvalues();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            fetchorno();
            insertupdatebill();
            cleartxtboxes();
        }

        private void radio3_CheckedChanged(object sender, EventArgs e)
        {
            button1.Enabled = false;
        }

        private void radio2_CheckedChanged(object sender, EventArgs e)
        {
            button1.Enabled = false;
        }

        private void radio1_CheckedChanged(object sender, EventArgs e)
        {
            button1.Enabled = false;
        }

        private void radio4_CheckedChanged(object sender, EventArgs e)
        {
            button1.Enabled = false;
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                selectfromtable();
            }
        }


        private void change_Leave(object sender, EventArgs e)
        {
            Double value;
            if (Double.TryParse(change.Text, out value))
                change.Text = String.Format(System.Globalization.CultureInfo.CurrentCulture, "{0:N}", value);
            else
                change.Text = String.Empty;
        }

        private void cashin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                double cashout_val = Double.TryParse(change.Text, out cashout_val) ? cashout_val : 0.0;
                double cashin_val = Double.TryParse(cashin.Text, out cashin_val) ? cashin_val : 0.0;
                //double collection = cashin_val - cashout_val;
                double totalbill_var = Double.TryParse(totalbill.Text, out totalbill_var) ? totalbill_var : 0.0;
                //double paymentval = Double.TryParse(collection, out paymentval) ? paymentval : 0.0;
                double paymentval = cashin_val - cashout_val;

                double balance = Double.TryParse(balancedue.Text, out balance) ? balance : 0.0;
                double rembalvar = totalbill_var - balance;
                if (paymentval < balance)
                {
                    MessageBox.Show("Payment is lesser than bill");
                    button1.Enabled = false;
                }
                else
                {
                    button1.Enabled = true;
                    if (rembalvar >= 0)
                    {
                        rembal.Text = String.Format(System.Globalization.CultureInfo.CurrentCulture, "{0:N}", rembalvar);

                    }
                    else
                    {
                        rembal.Text = "0.00";
                    }
                    change.Text = String.Format(System.Globalization.CultureInfo.CurrentCulture, "{0:N}", (paymentval - balance));
                }
                
                Double value;
                if (Double.TryParse(cashin.Text, out value))
                    cashin.Text = String.Format(System.Globalization.CultureInfo.CurrentCulture, "{0:N}", value);
                else
                    cashin.Text = String.Empty;
                
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            checkno.ReadOnly = false;
            bank.ReadOnly = false;
            this.cash1 = "";
            this.cash2 = "";
            this.check1 = "/";
            this.check2 = "/";
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            checkno.ReadOnly = true;
            bank.ReadOnly = true;
            checkno.Text = "";
            bank.Text = "";
            this.cash1 = "/";
            this.cash2 = "/";
            this.check1 = "";
            this.check2 = "";
        }


    }
}
