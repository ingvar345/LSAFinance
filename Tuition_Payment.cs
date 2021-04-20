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
    public partial class Tuition_Payment : Form
    {
        private string constring = "datasource=203.177.24.82;Initial Catalog=lsa_database;port=3306;username=ing;password=123";
        private string currentYear = DateTime.Now.Year.ToString(), currentMonth = DateTime.Now.Month.ToString(), idnumber2;
        private string plancode = "", idnumber, schoolyearid, yearlevelid, enrollmentid, accountid, transactionid, transactionidreceipt;
        private string paymentplanname, paymentplanprice, paymentplanenrollment, paymentplaninstallment, enrollmentstatus;
        private string cash1, cash2, check1, check2 = "";
        private string amount_in_words = "", crnumber = "";
        private string paymentplantype;
        public string employeeid;
        float totalcharge;
        float totalpayment;
        float totaldiscount;
        float totalcredit;
        float totalstudentbalance;
        double amountbalance, enrollmentpayment, enrollmenttotalcredit, enrollmenttotalbalance, studentpayment;
        public string user;
        string datetimetoday;

        public Tuition_Payment()
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
            Student_PaymentPlan student_payment_plan = new Student_PaymentPlan();
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
            this.idnumber2 = "";
            this.name.Text = "";
            this.schoolyear.Text = "";
            this.paymentplantype = "";
            this.yearlevel.Text = "";
            this.tuitionfees.Text = "";
            this.totalbalance.Text = "";
            //totalbalance.Text = Convert.ToString(totalstudentbalance);

            MySqlConnection myConn = new MySqlConnection(constring);
            myConn.Open();
            MySqlCommand myCmd = new MySqlCommand("search_student_cashier", myConn);
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

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void Tuition_Payment_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            get_studentmonthlyduebalance();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            double paymentreceived = Double.TryParse(textBox5.Text, out paymentreceived) ? paymentreceived : 0.0;
            double studentamountdue = Double.TryParse(amountdue.Text, out studentamountdue) ? studentamountdue : 0.0;
            double studenttotalbalance = Double.TryParse(totalbalance.Text, out studenttotalbalance) ? studenttotalbalance : 0.0;

            double change = studentamountdue - paymentreceived;

            if (change >= 0)
            {
                textBox2.Text = "0";
            }
            else
            {
                textBox2.Text = Convert.ToString(Math.Abs(change));
            }

            double remainingbalance = studenttotalbalance - paymentreceived + Convert.ToDouble(textBox2.Text);

            textBox4.Text = Convert.ToString(remainingbalance);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox5_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
            //{
                //double paymentreceived = Double.TryParse(textBox5.Text, out paymentreceived) ? paymentreceived : 0.0;
                //double studentamountdue = Double.TryParse(amountdue.Text, out studentamountdue) ? studentamountdue : 0.0;
                //double studenttotalbalance = Double.TryParse(totalbalance.Text, out studenttotalbalance) ? studenttotalbalance : 0.0;

                //double change = studentamountdue - paymentreceived;

                //if (change >= 0)
                //{
                //    textBox2.Text = "0";
                //}
                //else
                //{
                //    textBox2.Text = Convert.ToString(Math.Abs(change));
                //}

                //double remainingbalance = studenttotalbalance - paymentreceived + Convert.ToDouble(textBox2.Text);

                //textBox4.Text = Convert.ToString(remainingbalance);

            //}
        }

        private void amountdue_TextChanged(object sender, EventArgs e)
        {

        }

        private void click_table_contents()
        {
            DataGridViewRow dgr = dataGridView1.CurrentRow;
            if (dgr != null)
            {
                this.idnumber2 = dgr.Cells["Column1"].Value.ToString();
                this.name.Text = dgr.Cells["Column3"].Value.ToString() + " " + dgr.Cells["Column4"].Value.ToString() + " " + dgr.Cells["Column2"].Value.ToString();
                this.schoolyear.Text = dgr.Cells["Column9"].Value.ToString();
                this.paymentplantype = dgr.Cells["Column7"].Value.ToString();
                this.yearlevel.Text = dgr.Cells["Column10"].Value.ToString();
            }
        }

        //private void get_student_balance()
        //{
        //    MySqlConnection myConn = new MySqlConnection(constring);
        //    MySqlCommand myCmd = new MySqlCommand("select_student_balance", myConn);
        //    myCmd.Parameters.AddWithValue("@accountid", idnumber2);
        //    myCmd.CommandType = CommandType.StoredProcedure;

        //    try
        //    {
        //        myConn.Open();
        //        using (MySqlDataReader read = myCmd.ExecuteReader())
        //        {
        //            while (read.Read())
        //            {
        //                tuitionfees.Text = (read["tuition_fees"].ToString());
        //                previousbalance.Text = (read["previous_balance"].ToString());
        //                totalbalance.Text = (read["total_balance"].ToString());
        //                amountdue.Text = (read["amount_due"].ToString());

        //            }
        //            read.Close();
        //            read.Dispose();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }

        //    finally
        //    {
        //        myConn.Dispose();
        //    }
        //}

        private void get_student_amount_due()
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
            get_yearlevelid();
            get_schoolyearid();
            get_accountid();
            get_enrollmentid();
            get_paymentplan();
            get_studentmonthlydue();

            tuitionfees.Text = this.paymentplanprice;
            totalbalance.Text = Convert.ToString(totalstudentbalance);

            //get_student_balance();
            //get_student_amount_due();
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                click_table_contents();
                get_yearlevelid();
                get_schoolyearid();
                get_accountid();
                get_enrollmentid();
                get_paymentplan();
                get_studentmonthlydue();

                tuitionfees.Text = this.paymentplanprice;
                totalbalance.Text = Convert.ToString(totalstudentbalance);
            }
        }

        private void confirm_Click(object sender, EventArgs e)
        {
            save_tuitionpayment();
            select_monthly_due_balance();
            insert_tuition_transaction_payment();
            if (totalcredit == 0)
            {
                update_studentenrollmentstatus();
            }
            update_enrollment_total_payment();
            update_enrollment_total_credit();
            update_enrollment_total_balance();
            select_transaction_id();
            insert_transaction_receipt();
            print_receipt();
        }

        private void print_receipt()
        {
            double paymentreceived = Double.TryParse(textBox5.Text, out paymentreceived) ? paymentreceived : 0.0;
            double studentamountdue = Double.TryParse(amountdue.Text, out studentamountdue) ? studentamountdue : 0.0;
            amount_in_words = AmountInWords(paymentreceived) + " Pesos only";
            ReportDocument report = new ReportDocument();
            report.Load(@"C:\LSA\Finance Module\Finance Module\officialreceipt2.rpt");

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

            //crno1.Text = this.crnumber;
            //crno2.Text = this.crnumber;

            crno1.Text = or.Text;
            crno2.Text = or.Text;
            name1.Text = name.Text;
            name2.Text = name.Text;
            idnum1.Text = idnumber2;
            idnum2.Text = idnumber2;
            ciw1.Text = amount_in_words;
            ciw2.Text = amount_in_words;
            cash1.Text = textBox5.Text;
            cash2.Text = textBox5.Text;
            trans1.Text = "Tuition Payment";
            trans2.Text = "Tuition Payment";
            bal1.Text = amountdue.Text;
            bal2.Text = amountdue.Text;
            change1.Text = textBox2.Text;
            change2.Text = textBox2.Text;
            rem1.Text = textBox4.Text;
            rem2.Text = textBox4.Text;
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

        private void dataGridView1_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            get_yearlevelid();
            get_schoolyearid();
            get_accountid();
            get_enrollmentid();
            get_paymentplan();
            if (enrollmentstatus == "Pending")
            {
                Change_Payment_Plan change_payment_plan = new Change_Payment_Plan();
                change_payment_plan.name.Text = this.name.Text;
                change_payment_plan.paymentplan.Text = this.paymentplantype;
                change_payment_plan.yearlevelid = this.yearlevelid;
                change_payment_plan.schoolyearid = this.schoolyearid;
                change_payment_plan.enrollmentid = this.enrollmentid;
                change_payment_plan.accountid = this.accountid;
                change_payment_plan.enrollmentstatus = this.enrollmentstatus;
                change_payment_plan.employeeid = this.employeeid;
                change_payment_plan.ShowDialog();
                
            }
            else
            {
                MessageBox.Show("You can only charge one tuition payments.");
            }

        }

        private void get_yearlevelid()
        {
            MySqlConnection myConn = new MySqlConnection(constring);
            myConn.Open();
            MySqlCommand myCmd = new MySqlCommand("get_year_level_id", myConn);
            try
            {
                myCmd.Parameters.Add("@yearlevel", MySqlDbType.VarChar, 45).Value = yearlevel.Text.ToString();
                myCmd.CommandType = CommandType.StoredProcedure;
                using (MySqlDataReader read = myCmd.ExecuteReader())
                {
                    while (read.Read())
                    {
                        this.yearlevelid = (read["year_level_id"].ToString());
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

        private void get_schoolyearid()
        {
            MySqlConnection myConn = new MySqlConnection(constring);
            myConn.Open();
            MySqlCommand myCmd = new MySqlCommand("get_school_year_id", myConn);
            try
            {
                myCmd.Parameters.Add("@schoolyear", MySqlDbType.VarChar, 45).Value = schoolyear.Text.ToString();
                myCmd.CommandType = CommandType.StoredProcedure;
                using (MySqlDataReader read = myCmd.ExecuteReader())
                {
                    while (read.Read())
                    {
                        this.schoolyearid = (read["school_year_id"].ToString());
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

        private void get_accountid()
        {
            MySqlConnection myConn = new MySqlConnection(constring);
            myConn.Open();
            MySqlCommand myCmd = new MySqlCommand("get_account_id", myConn);
            try
            {
                myCmd.Parameters.Add("@idnumber", MySqlDbType.VarChar, 45).Value = idnumber2;
                myCmd.CommandType = CommandType.StoredProcedure;
                using (MySqlDataReader read = myCmd.ExecuteReader())
                {
                    while (read.Read())
                    {
                        this.accountid = (read["account_id"].ToString());
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

        private void get_enrollmentid()
        {
            MySqlConnection myConn = new MySqlConnection(constring);
            myConn.Open();
            MySqlCommand myCmd = new MySqlCommand("get_enrollment_id", myConn);
            try
            {
                myCmd.Parameters.Add("@accountid", MySqlDbType.VarChar, 45).Value = accountid;
                myCmd.Parameters.Add("@schoolyearid", MySqlDbType.VarChar, 45).Value = schoolyearid;
                myCmd.Parameters.Add("@yearlevelid", MySqlDbType.VarChar, 45).Value = yearlevelid;
                myCmd.CommandType = CommandType.StoredProcedure;
                using (MySqlDataReader read = myCmd.ExecuteReader())
                {
                    while (read.Read())
                    {
                        this.enrollmentid = (read["enrollment_id"].ToString());
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

        private void get_paymentplan()
        {
            MySqlConnection myConn = new MySqlConnection(constring);
            myConn.Open();
            MySqlCommand myCmd = new MySqlCommand("get_payment_plan", myConn);
            try
            {
                myCmd.Parameters.Add("@enrollmentid", MySqlDbType.VarChar, 45).Value = enrollmentid;
                myCmd.CommandType = CommandType.StoredProcedure;
                using (MySqlDataReader read = myCmd.ExecuteReader())
                {
                    while (read.Read())
                    {
                        this.paymentplanname = read["payment_plan_name"].ToString();
                        this.totalcharge = Convert.ToSingle(read["total_charge"]);
                        this.totalpayment = Convert.ToSingle(read["total_payment"]);
                        this.totaldiscount = Convert.ToSingle(read["total_discount"]);
                        this.totalcredit = Convert.ToSingle(read["total_credit"]);
                        this.totalstudentbalance = Convert.ToSingle(read["total_balance"]);
                        this.paymentplanprice = read["payment_plan_price"].ToString();
                        this.paymentplanenrollment = read["payment_plan_enrollment"].ToString();
                        this.paymentplaninstallment = read["payment_plan_installment"].ToString();
                        this.enrollmentstatus = read["status"].ToString();
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

        private void get_studentmonthlydue()
        {
            comboBox1.Items.Clear();
            comboBox1.ResetText();
            amountdue.ResetText();

            MySqlConnection myConn = new MySqlConnection(constring);
            myConn.Open();
            MySqlCommand myCmd = new MySqlCommand("get_student_monthly_due", myConn);
            try
            {
                myCmd.Parameters.Add("@accountid", MySqlDbType.VarChar, 45).Value = accountid;
                myCmd.Parameters.Add("@enrollmentid", MySqlDbType.VarChar, 45).Value = enrollmentid;
                myCmd.CommandType = CommandType.StoredProcedure;
                using (MySqlDataReader read = myCmd.ExecuteReader())
                {
                    while (read.Read())
                    {
                        string studentmonthlydue = read["monthly_due_number"].ToString();
                        comboBox1.Items.Add(studentmonthlydue);
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

        private void get_studentmonthlyduebalance()
        {
            MySqlConnection myConn = new MySqlConnection(constring);
            myConn.Open();
            MySqlCommand myCmd = new MySqlCommand("get_student_monthly_due_balance", myConn);
            try
            {
                myCmd.Parameters.Add("@accountid", MySqlDbType.VarChar, 45).Value = accountid;
                myCmd.Parameters.Add("@enrollmentid", MySqlDbType.VarChar, 45).Value = enrollmentid;
                myCmd.Parameters.Add("@monthlyduenumber", MySqlDbType.VarChar, 45).Value = comboBox1.Text;
                myCmd.CommandType = CommandType.StoredProcedure;

                using (MySqlDataReader read = myCmd.ExecuteReader())
                {
                    while (read.Read())
                    {
                        amountdue.Text = read["amount_balance"].ToString();
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

        private void save_tuitionpayment()
        {
            if (textBox5.Text != null || textBox2.Text == null || textBox5.Text == "0")
            {
                double paymentreceived = Convert.ToDouble(textBox5.Text);
                double change = Convert.ToDouble(textBox2.Text);

                double studentpayment = paymentreceived - change;

                MySqlConnection myConn = new MySqlConnection(constring);
                myConn.Open();
                MySqlCommand myCmd = new MySqlCommand("select_student_monthly_due", myConn);

                try
                {
                    myCmd.Parameters.Add("@accountid", MySqlDbType.Int32).Value = accountid;
                    myCmd.Parameters.Add("@enrollmentid", MySqlDbType.Int32).Value = enrollmentid;
                    myCmd.CommandType = CommandType.StoredProcedure;

                    using (MySqlDataReader read = myCmd.ExecuteReader())
                    {
                        while (read.Read())
                        {
                            string monthlyduenumber = Convert.ToString(read["monthly_due_number"]);
                            float amountdue = Convert.ToSingle(read["amount_due"]);
                            float amountpaid = Convert.ToSingle(read["amount_paid"]);

                            studentpayment = amountpaid + studentpayment;

                            if (studentpayment >= amountdue)
                            {
                                studentpayment = studentpayment - amountdue;
                                MySqlConnection updatepaidconnection = new MySqlConnection(constring);
                                MySqlCommand updatepaidcommand = new MySqlCommand("update_monthly_due_paid", updatepaidconnection);

                                try
                                {
                                    updatepaidconnection.Open();
                                    updatepaidcommand.Parameters.Add("@monthlyduenumber", MySqlDbType.VarChar, 45).Value = monthlyduenumber;
                                    updatepaidcommand.Parameters.Add("@amountpaid", MySqlDbType.Float, 45).Value = amountdue;
                                    updatepaidcommand.CommandType = CommandType.StoredProcedure;
                                    updatepaidcommand.ExecuteNonQuery();
                                    updatepaidconnection.Close();
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message);
                                }
                            }
                            else
                            {
                                MySqlConnection updatepaidconnection = new MySqlConnection(constring);
                                MySqlCommand updatepaidcommand = new MySqlCommand("update_monthly_due_paid", updatepaidconnection);

                                try
                                {
                                    updatepaidconnection.Open();
                                    updatepaidcommand.Parameters.Add("@monthlyduenumber", MySqlDbType.VarChar, 45).Value = monthlyduenumber;
                                    updatepaidcommand.Parameters.Add("@amountpaid", MySqlDbType.Float, 45).Value = studentpayment;
                                    updatepaidcommand.CommandType = CommandType.StoredProcedure;
                                    updatepaidcommand.ExecuteNonQuery();
                                    updatepaidconnection.Close();
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message);
                                }

                                studentpayment = studentpayment - studentpayment;
                            }
                        }

                        read.Close();
                        read.Dispose();

                        MessageBox.Show("Successfully added tuition payment.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Please input payment received.");
            }
        }

        private void select_monthly_due_balance()
        {
            MySqlConnection myConn = new MySqlConnection(constring);
            myConn.Open();
            MySqlCommand myCmd = new MySqlCommand("select_monthly_due_computation", myConn);
            try
            {
                myCmd.Parameters.Add("@accountid", MySqlDbType.Int32).Value = accountid;
                myCmd.Parameters.Add("@enrollmentid", MySqlDbType.Int32).Value = enrollmentid;
                myCmd.CommandType = CommandType.StoredProcedure;

                using (MySqlDataReader read = myCmd.ExecuteReader())
                {
                    while (read.Read())
                    {
                        string monthlyduenumber = Convert.ToString(read["monthly_due_number"]);
                        float amountdue = Convert.ToSingle(read["amount_due"]);
                        float amountpaid = Convert.ToSingle(read["amount_paid"]);
                        amountbalance = (amountdue - amountpaid) + amountbalance;

                        MySqlConnection updateconnection = new MySqlConnection(constring);
                        MySqlCommand updatecommand = new MySqlCommand("update_monthly_due_balance", updateconnection);

                        try
                        {
                            updateconnection.Open();
                            updatecommand.Parameters.Add("@monthlyduenumber", MySqlDbType.VarChar, 45).Value = monthlyduenumber;
                            updatecommand.Parameters.Add("@amountbalance", MySqlDbType.Float, 45).Value = amountbalance;
                            updatecommand.CommandType = CommandType.StoredProcedure;
                            updatecommand.ExecuteNonQuery();
                            updateconnection.Close();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }

                    MessageBox.Show("Successfully computed tuition payment.");

                    read.Close();
                    read.Dispose();
                    myConn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void update_studentenrollmentstatus()
        {
            MySqlConnection myConn = new MySqlConnection(constring);
            MySqlCommand myCmd = new MySqlCommand("update_student_enrollment_status", myConn);

            try
            {
                myConn.Open();
                myCmd.Parameters.Add("@accountid", MySqlDbType.VarChar, 45).Value = this.accountid;
                myCmd.Parameters.Add("@enrollmentid", MySqlDbType.VarChar, 45).Value = this.enrollmentid;
                myCmd.CommandType = CommandType.StoredProcedure;
                myCmd.ExecuteNonQuery();
                myConn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void insert_tuition_transaction_payment()
        {
            MySqlConnection myConn = new MySqlConnection(constring);
            MySqlCommand myCmd = new MySqlCommand("insert_tuition_transaction_payment", myConn);

            double paymentreceived = Convert.ToDouble(textBox5.Text);
            double change = Convert.ToDouble(textBox2.Text);

            studentpayment = paymentreceived - change;

            datetimetoday = Convert.ToString(DateTime.Today);

            try
            {
                myConn.Open();
                myCmd.Parameters.Add("@employeeid", MySqlDbType.Int32).Value = this.employeeid;
                myCmd.Parameters.Add("@accountid", MySqlDbType.Int32).Value = this.accountid;
                myCmd.Parameters.Add("@enrollmentid", MySqlDbType.Int32).Value = this.enrollmentid;
                myCmd.Parameters.Add("@transactionname", MySqlDbType.VarChar, 45).Value = this.paymentplanname;
                myCmd.Parameters.Add("@transactionfee", MySqlDbType.Float, 45).Value = studentpayment;
                myCmd.Parameters.Add("@transactiondate", MySqlDbType.Float, 45).Value = datetimetoday;
                myCmd.CommandType = CommandType.StoredProcedure;
                myCmd.ExecuteNonQuery();

                myConn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void update_enrollment_total_payment()
        {
            MySqlConnection myConn = new MySqlConnection(constring);
            myConn.Open();
            MySqlCommand myCmd = new MySqlCommand("select_transaction_payment", myConn);
            try
            {
                myCmd.Parameters.Add("@accountid", MySqlDbType.Int32).Value = accountid;
                myCmd.Parameters.Add("@enrollmentid", MySqlDbType.Int32).Value = enrollmentid;
                myCmd.CommandType = CommandType.StoredProcedure;

                using (MySqlDataReader read = myCmd.ExecuteReader())
                {
                    while (read.Read())
                    {
                        this.transactionid = Convert.ToString(read["transaction_id"]);
                        float payment = Convert.ToSingle(read["transaction_fee"]);
                        enrollmentpayment = payment + enrollmentpayment;
                    }

                    MySqlConnection updateconnection = new MySqlConnection(constring);
                    MySqlCommand updatecommand = new MySqlCommand("update_enrollment_total_payment", updateconnection);

                    try
                    {
                        updateconnection.Open();
                        updatecommand.Parameters.Add("@enrollmentid", MySqlDbType.Int32).Value = enrollmentid;
                        updatecommand.Parameters.Add("@enrollmentpayment", MySqlDbType.Float, 45).Value = enrollmentpayment;
                        updatecommand.CommandType = CommandType.StoredProcedure;
                        updatecommand.ExecuteNonQuery();
                        updateconnection.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                    read.Close();
                    read.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void update_enrollment_total_credit()
        {
            MySqlConnection myConn = new MySqlConnection(constring);
            myConn.Open();
            MySqlCommand myCmd = new MySqlCommand("select_enrollment_total_credit", myConn);
            try
            {
                myCmd.Parameters.Add("@enrollmentid", MySqlDbType.Int32).Value = enrollmentid;
                myCmd.CommandType = CommandType.StoredProcedure;

                using (MySqlDataReader read = myCmd.ExecuteReader())
                {
                    while (read.Read())
                    {
                        float totalpayment = Convert.ToSingle(read["total_payment"]);
                        float totaldiscount = Convert.ToSingle(read["total_discount"]);
                        enrollmenttotalcredit = totalpayment + totaldiscount;
                    }

                    MySqlConnection updateconnection = new MySqlConnection(constring);
                    MySqlCommand updatecommand = new MySqlCommand("update_enrollment_total_credit", updateconnection);

                    try
                    {
                        updateconnection.Open();
                        updatecommand.Parameters.Add("@enrollmentid", MySqlDbType.Int32).Value = enrollmentid;
                        updatecommand.Parameters.Add("@enrollmenttotalcredit", MySqlDbType.Float, 45).Value = enrollmenttotalcredit;
                        updatecommand.CommandType = CommandType.StoredProcedure;
                        updatecommand.ExecuteNonQuery();
                        updateconnection.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                    read.Close();
                    read.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void update_enrollment_total_balance()
        {
            MySqlConnection myConn = new MySqlConnection(constring);
            myConn.Open();
            MySqlCommand myCmd = new MySqlCommand("select_enrollment_total_balance", myConn);
            try
            {
                myCmd.Parameters.Add("@enrollmentid", MySqlDbType.Int32).Value = enrollmentid;
                myCmd.CommandType = CommandType.StoredProcedure;

                using (MySqlDataReader read = myCmd.ExecuteReader())
                {
                    while (read.Read())
                    {
                        float totalcharge = Convert.ToSingle(read["total_charge"]);
                        this.totalcredit = Convert.ToSingle(read["total_credit"]);
                        enrollmenttotalbalance = totalcharge - totalcredit;
                    }

                    MySqlConnection updateconnection = new MySqlConnection(constring);
                    MySqlCommand updatecommand = new MySqlCommand("update_enrollment_total_balance", updateconnection);

                    try
                    {
                        updateconnection.Open();
                        updatecommand.Parameters.Add("@enrollmentid", MySqlDbType.Int32).Value = enrollmentid;
                        updatecommand.Parameters.Add("@enrollmenttotalbalance", MySqlDbType.Float, 45).Value = enrollmenttotalbalance;
                        updatecommand.CommandType = CommandType.StoredProcedure;
                        updatecommand.ExecuteNonQuery();
                        updateconnection.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                    read.Close();
                    read.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void select_transaction_id()
        {
            MySqlConnection myConn = new MySqlConnection(constring);
            MySqlCommand myCmd = new MySqlCommand("select_transaction_id", myConn);

            try
            {
                myConn.Open();
                myCmd.Parameters.Add("@employeeid", MySqlDbType.Int32).Value = this.employeeid;
                myCmd.Parameters.Add("@accountid", MySqlDbType.Int32).Value = this.accountid;
                myCmd.Parameters.Add("@enrollmentid", MySqlDbType.Int32).Value = this.enrollmentid;
                myCmd.Parameters.Add("@transactionname", MySqlDbType.VarChar, 45).Value = this.paymentplanname;
                myCmd.Parameters.Add("@transactionfee", MySqlDbType.Float, 45).Value = studentpayment;
                myCmd.Parameters.Add("@transactiondate", MySqlDbType.Float, 45).Value = datetimetoday;
                myCmd.CommandType = CommandType.StoredProcedure;
                myCmd.ExecuteNonQuery();

                using (MySqlDataReader read = myCmd.ExecuteReader())
                {
                    while (read.Read())
                    {
                        this.transactionidreceipt = Convert.ToString(read["transaction_id"]);
                    }

                    read.Close();
                    read.Dispose();
                    myConn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void insert_transaction_receipt()
        {
            MySqlConnection myConn = new MySqlConnection(constring);
            MySqlCommand myCmd = new MySqlCommand("insert_tuition_transaction_payment", myConn);

            double paymentreceived = Convert.ToDouble(textBox5.Text);
            double change = Convert.ToDouble(textBox2.Text);

            studentpayment = paymentreceived - change;

            datetimetoday = Convert.ToString(DateTime.Today);

            try
            {
                myConn.Open();
                myCmd.Parameters.Add("@employeeid", MySqlDbType.Int32).Value = this.employeeid;
                myCmd.Parameters.Add("@accountid", MySqlDbType.Int32).Value = this.accountid;
                myCmd.Parameters.Add("@enrollmentid", MySqlDbType.Int32).Value = this.enrollmentid;
                myCmd.Parameters.Add("@transactionname", MySqlDbType.VarChar, 45).Value = this.paymentplanname;
                myCmd.Parameters.Add("@transactionfee", MySqlDbType.Float, 45).Value = studentpayment;
                myCmd.Parameters.Add("@transactiondate", MySqlDbType.Float, 45).Value = datetimetoday;
                myCmd.CommandType = CommandType.StoredProcedure;
                myCmd.ExecuteNonQuery();

                myConn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
