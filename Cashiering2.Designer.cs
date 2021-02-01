namespace Billing_Module
{
    partial class Cashiering2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.searchbox = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.check = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.paymentplan = new System.Windows.Forms.ComboBox();
            this.yearlvl = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.homeroom = new System.Windows.Forms.TextBox();
            this.idnumber = new System.Windows.Forms.TextBox();
            this.name = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label15 = new System.Windows.Forms.Label();
            this.balancedue = new System.Windows.Forms.TextBox();
            this.label44 = new System.Windows.Forms.Label();
            this.totalbill = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.total1 = new System.Windows.Forms.TextBox();
            this.prevacc = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.bank = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.checkno = new System.Windows.Forms.TextBox();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.label13 = new System.Windows.Forms.Label();
            this.cr_no = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.rembal = new System.Windows.Forms.TextBox();
            this.change = new System.Windows.Forms.TextBox();
            this.cashin = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.schyear = new System.Windows.Forms.TextBox();
            this.label46 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "ID Number / Last Name";
            // 
            // searchbox
            // 
            this.searchbox.Location = new System.Drawing.Point(134, 5);
            this.searchbox.Name = "searchbox";
            this.searchbox.Size = new System.Drawing.Size(110, 20);
            this.searchbox.TabIndex = 0;
            this.searchbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.searchbox_KeyDown);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 30);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(563, 98);
            this.dataGridView1.TabIndex = 10;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridView1_KeyDown);
            // 
            // check
            // 
            this.check.BackColor = System.Drawing.Color.PowderBlue;
            this.check.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.check.Location = new System.Drawing.Point(17, 296);
            this.check.Name = "check";
            this.check.Size = new System.Drawing.Size(233, 46);
            this.check.TabIndex = 30;
            this.check.Text = "Save Payment Plan";
            this.check.UseVisualStyleBackColor = false;
            this.check.Click += new System.EventHandler(this.check_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 245);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 13);
            this.label6.TabIndex = 21;
            this.label6.Text = "Payment Plan";
            // 
            // paymentplan
            // 
            this.paymentplan.FormattingEnabled = true;
            this.paymentplan.Items.AddRange(new object[] {
            "A",
            "B",
            "C"});
            this.paymentplan.Location = new System.Drawing.Point(98, 237);
            this.paymentplan.Name = "paymentplan";
            this.paymentplan.Size = new System.Drawing.Size(152, 21);
            this.paymentplan.TabIndex = 20;
            this.paymentplan.SelectedIndexChanged += new System.EventHandler(this.paymentplan_SelectedIndexChanged);
            // 
            // yearlvl
            // 
            this.yearlvl.FormattingEnabled = true;
            this.yearlvl.Items.AddRange(new object[] {
            "K-1",
            "K-2",
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12",
            "07N",
            "08N",
            "09N",
            "10N"});
            this.yearlvl.Location = new System.Drawing.Point(98, 185);
            this.yearlvl.Name = "yearlvl";
            this.yearlvl.Size = new System.Drawing.Size(90, 21);
            this.yearlvl.TabIndex = 29;
            this.yearlvl.Text = "--";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 218);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 13);
            this.label5.TabIndex = 28;
            this.label5.Text = "Homeroom";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 191);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 13);
            this.label4.TabIndex = 27;
            this.label4.Text = "Grade/Year Lvl";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 163);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 26;
            this.label3.Text = "ID No.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 134);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 25;
            this.label2.Text = "Name";
            // 
            // homeroom
            // 
            this.homeroom.Location = new System.Drawing.Point(98, 211);
            this.homeroom.Name = "homeroom";
            this.homeroom.ReadOnly = true;
            this.homeroom.Size = new System.Drawing.Size(152, 20);
            this.homeroom.TabIndex = 24;
            // 
            // idnumber
            // 
            this.idnumber.Location = new System.Drawing.Point(98, 159);
            this.idnumber.Name = "idnumber";
            this.idnumber.ReadOnly = true;
            this.idnumber.Size = new System.Drawing.Size(90, 20);
            this.idnumber.TabIndex = 23;
            // 
            // name
            // 
            this.name.Location = new System.Drawing.Point(98, 134);
            this.name.Name = "name";
            this.name.ReadOnly = true;
            this.name.Size = new System.Drawing.Size(352, 20);
            this.name.TabIndex = 22;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.balancedue);
            this.groupBox1.Controls.Add(this.label44);
            this.groupBox1.Controls.Add(this.totalbill);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.total1);
            this.groupBox1.Controls.Add(this.prevacc);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(10, 356);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(245, 149);
            this.groupBox1.TabIndex = 31;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Balance";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(5, 107);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(80, 13);
            this.label15.TabIndex = 47;
            this.label15.Text = "Balance Due";
            // 
            // balancedue
            // 
            this.balancedue.Location = new System.Drawing.Point(145, 101);
            this.balancedue.Name = "balancedue";
            this.balancedue.Size = new System.Drawing.Size(95, 19);
            this.balancedue.TabIndex = 46;
            this.balancedue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label44.Location = new System.Drawing.Point(5, 80);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(86, 13);
            this.label44.TabIndex = 42;
            this.label44.Text = "Total Balance";
            // 
            // totalbill
            // 
            this.totalbill.Location = new System.Drawing.Point(145, 76);
            this.totalbill.Name = "totalbill";
            this.totalbill.ReadOnly = true;
            this.totalbill.Size = new System.Drawing.Size(95, 19);
            this.totalbill.TabIndex = 41;
            this.totalbill.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(5, 55);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(86, 13);
            this.label8.TabIndex = 30;
            this.label8.Text = "Tuition and Fees";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(5, 29);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(91, 13);
            this.label7.TabIndex = 29;
            this.label7.Text = "Previous Account";
            // 
            // total1
            // 
            this.total1.Location = new System.Drawing.Point(145, 51);
            this.total1.Name = "total1";
            this.total1.ReadOnly = true;
            this.total1.Size = new System.Drawing.Size(95, 19);
            this.total1.TabIndex = 26;
            this.total1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // prevacc
            // 
            this.prevacc.Location = new System.Drawing.Point(145, 26);
            this.prevacc.Name = "prevacc";
            this.prevacc.ReadOnly = true;
            this.prevacc.Size = new System.Drawing.Size(95, 19);
            this.prevacc.TabIndex = 25;
            this.prevacc.Text = "0";
            this.prevacc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.bank);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.checkno);
            this.groupBox2.Controls.Add(this.radioButton2);
            this.groupBox2.Controls.Add(this.radioButton1);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.cr_no);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.rembal);
            this.groupBox2.Controls.Add(this.change);
            this.groupBox2.Controls.Add(this.cashin);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Location = new System.Drawing.Point(259, 163);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(316, 342);
            this.groupBox2.TabIndex = 49;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Payment";
            // 
            // bank
            // 
            this.bank.Location = new System.Drawing.Point(115, 84);
            this.bank.Name = "bank";
            this.bank.ReadOnly = true;
            this.bank.Size = new System.Drawing.Size(194, 20);
            this.bank.TabIndex = 11;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(10, 87);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(32, 13);
            this.label14.TabIndex = 10;
            this.label14.Text = "Bank";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(10, 64);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(58, 13);
            this.label9.TabIndex = 9;
            this.label9.Text = "Check No.";
            // 
            // checkno
            // 
            this.checkno.Location = new System.Drawing.Point(115, 61);
            this.checkno.Name = "checkno";
            this.checkno.ReadOnly = true;
            this.checkno.Size = new System.Drawing.Size(194, 20);
            this.checkno.TabIndex = 8;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(10, 41);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(56, 17);
            this.radioButton2.TabIndex = 7;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Check";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(10, 18);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(49, 17);
            this.radioButton1.TabIndex = 6;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Cash";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(7, 209);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(32, 13);
            this.label13.TabIndex = 5;
            this.label13.Text = "CR#:";
            // 
            // cr_no
            // 
            this.cr_no.Location = new System.Drawing.Point(115, 203);
            this.cr_no.Name = "cr_no";
            this.cr_no.Size = new System.Drawing.Size(95, 20);
            this.cr_no.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Gold;
            this.button1.Enabled = false;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(4, 248);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(305, 69);
            this.button1.TabIndex = 3;
            this.button1.Text = "Confirm";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // rembal
            // 
            this.rembal.Location = new System.Drawing.Point(115, 178);
            this.rembal.Margin = new System.Windows.Forms.Padding(2);
            this.rembal.Name = "rembal";
            this.rembal.Size = new System.Drawing.Size(95, 20);
            this.rembal.TabIndex = 2;
            // 
            // change
            // 
            this.change.Location = new System.Drawing.Point(115, 153);
            this.change.Margin = new System.Windows.Forms.Padding(2);
            this.change.Name = "change";
            this.change.Size = new System.Drawing.Size(95, 20);
            this.change.TabIndex = 2;
            this.change.Leave += new System.EventHandler(this.change_Leave);
            // 
            // cashin
            // 
            this.cashin.Location = new System.Drawing.Point(115, 126);
            this.cashin.Margin = new System.Windows.Forms.Padding(2);
            this.cashin.Name = "cashin";
            this.cashin.Size = new System.Drawing.Size(95, 20);
            this.cashin.TabIndex = 2;
            this.cashin.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cashin_KeyDown);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(4, 180);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(99, 13);
            this.label12.TabIndex = 1;
            this.label12.Text = "Remaining Balance";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(4, 155);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(44, 13);
            this.label11.TabIndex = 0;
            this.label11.Text = "Change";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(4, 128);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(113, 13);
            this.label10.TabIndex = 0;
            this.label10.Text = "Payment Received";
            // 
            // schyear
            // 
            this.schyear.Location = new System.Drawing.Point(98, 264);
            this.schyear.Name = "schyear";
            this.schyear.Size = new System.Drawing.Size(100, 20);
            this.schyear.TabIndex = 51;
            this.schyear.Text = "2020";
            // 
            // label46
            // 
            this.label46.AutoSize = true;
            this.label46.Location = new System.Drawing.Point(14, 271);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(65, 13);
            this.label46.TabIndex = 50;
            this.label46.Text = "School Year";
            // 
            // Cashiering2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.ClientSize = new System.Drawing.Size(586, 512);
            this.Controls.Add(this.schyear);
            this.Controls.Add(this.label46);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.check);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.paymentplan);
            this.Controls.Add(this.yearlvl);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.homeroom);
            this.Controls.Add(this.idnumber);
            this.Controls.Add(this.name);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.searchbox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "Cashiering2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tuition Cashiering";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox searchbox;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button check;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox paymentplan;
        private System.Windows.Forms.ComboBox yearlvl;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox homeroom;
        private System.Windows.Forms.TextBox idnumber;
        private System.Windows.Forms.TextBox name;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label44;
        private System.Windows.Forms.TextBox totalbill;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox total1;
        private System.Windows.Forms.TextBox prevacc;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox rembal;
        private System.Windows.Forms.TextBox change;
        private System.Windows.Forms.TextBox cashin;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox balancedue;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox cr_no;
        private System.Windows.Forms.TextBox checkno;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox bank;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox schyear;
        private System.Windows.Forms.Label label46;
    }
}