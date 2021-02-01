namespace Billing_Module
{
    partial class Cashiering3
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cr_no = new System.Windows.Forms.TextBox();
            this.change = new System.Windows.Forms.TextBox();
            this.cashin = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.acc_desc = new System.Windows.Forms.ComboBox();
            this.balance = new System.Windows.Forms.TextBox();
            this.yearlvl = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.homeroom = new System.Windows.Forms.TextBox();
            this.idnumber = new System.Windows.Forms.TextBox();
            this.name = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.searchbox = new System.Windows.Forms.TextBox();
            this.schyear = new System.Windows.Forms.TextBox();
            this.label46 = new System.Windows.Forms.Label();
            this.label44 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.cr_no);
            this.groupBox2.Controls.Add(this.change);
            this.groupBox2.Controls.Add(this.cashin);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Location = new System.Drawing.Point(262, 163);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(316, 281);
            this.groupBox2.TabIndex = 48;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Payment";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(43, 135);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "CR NO:";
            // 
            // cr_no
            // 
            this.cr_no.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cr_no.Location = new System.Drawing.Point(160, 124);
            this.cr_no.Margin = new System.Windows.Forms.Padding(2);
            this.cr_no.Name = "cr_no";
            this.cr_no.Size = new System.Drawing.Size(119, 29);
            this.cr_no.TabIndex = 3;
            // 
            // change
            // 
            this.change.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.change.Location = new System.Drawing.Point(160, 85);
            this.change.Margin = new System.Windows.Forms.Padding(2);
            this.change.Name = "change";
            this.change.Size = new System.Drawing.Size(119, 29);
            this.change.TabIndex = 1;
            this.change.Leave += new System.EventHandler(this.change_Leave);
            // 
            // cashin
            // 
            this.cashin.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cashin.Location = new System.Drawing.Point(160, 42);
            this.cashin.Margin = new System.Windows.Forms.Padding(2);
            this.cashin.Name = "cashin";
            this.cashin.Size = new System.Drawing.Size(119, 29);
            this.cashin.TabIndex = 0;
            this.cashin.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cashin_KeyDown);
            this.cashin.Leave += new System.EventHandler(this.cashin_Leave);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Gold;
            this.button1.Enabled = false;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(7, 170);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(305, 69);
            this.button1.TabIndex = 2;
            this.button1.Text = "Confirm";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(43, 96);
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
            this.label10.Location = new System.Drawing.Point(43, 53);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(113, 13);
            this.label10.TabIndex = 0;
            this.label10.Text = "Payment Received";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label44);
            this.groupBox1.Controls.Add(this.acc_desc);
            this.groupBox1.Controls.Add(this.balance);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(13, 278);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(232, 167);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Account";
            // 
            // acc_desc
            // 
            this.acc_desc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.acc_desc.FormattingEnabled = true;
            this.acc_desc.Items.AddRange(new object[] {
            "ACADEMIC DISCOUNT",
            "ATHLETIC DISCOUNT",
            "SIBLING DISCOUNT",
            "E-WARD",
            "SPECIAL CLASS",
            "ESC SCHOLARSHIP",
            "ESC REFUND",
            "PE UNIFORM",
            "PE PANTS",
            "PE SHIRT",
            "ID CARD REPLACEMENT",
            "LASAPFI",
            "QUIPPER",
            "SGS"});
            this.acc_desc.Location = new System.Drawing.Point(5, 42);
            this.acc_desc.Name = "acc_desc";
            this.acc_desc.Size = new System.Drawing.Size(212, 28);
            this.acc_desc.TabIndex = 44;
            // 
            // balance
            // 
            this.balance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.balance.Location = new System.Drawing.Point(4, 105);
            this.balance.Name = "balance";
            this.balance.Size = new System.Drawing.Size(212, 26);
            this.balance.TabIndex = 43;
            this.balance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
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
            this.yearlvl.TabIndex = 45;
            this.yearlvl.Text = "--";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 218);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 13);
            this.label5.TabIndex = 44;
            this.label5.Text = "Homeroom";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 191);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 13);
            this.label4.TabIndex = 43;
            this.label4.Text = "Grade/Year Lvl";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 163);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 42;
            this.label3.Text = "ID No.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 134);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 41;
            this.label2.Text = "Name";
            // 
            // homeroom
            // 
            this.homeroom.Enabled = false;
            this.homeroom.Location = new System.Drawing.Point(98, 212);
            this.homeroom.Name = "homeroom";
            this.homeroom.Size = new System.Drawing.Size(90, 20);
            this.homeroom.TabIndex = 40;
            // 
            // idnumber
            // 
            this.idnumber.Location = new System.Drawing.Point(98, 159);
            this.idnumber.Name = "idnumber";
            this.idnumber.ReadOnly = true;
            this.idnumber.Size = new System.Drawing.Size(90, 20);
            this.idnumber.TabIndex = 39;
            // 
            // name
            // 
            this.name.Location = new System.Drawing.Point(98, 134);
            this.name.Name = "name";
            this.name.ReadOnly = true;
            this.name.Size = new System.Drawing.Size(232, 20);
            this.name.TabIndex = 38;
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
            this.dataGridView1.Size = new System.Drawing.Size(566, 98);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridView1_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 13);
            this.label1.TabIndex = 34;
            this.label1.Text = "ID Number / Last Name";
            // 
            // searchbox
            // 
            this.searchbox.Location = new System.Drawing.Point(134, 5);
            this.searchbox.Name = "searchbox";
            this.searchbox.Size = new System.Drawing.Size(196, 20);
            this.searchbox.TabIndex = 0;
            this.searchbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.searchbox_KeyDown);
            // 
            // schyear
            // 
            this.schyear.Location = new System.Drawing.Point(98, 238);
            this.schyear.Name = "schyear";
            this.schyear.Size = new System.Drawing.Size(100, 20);
            this.schyear.TabIndex = 53;
            this.schyear.Text = "2020";
            // 
            // label46
            // 
            this.label46.AutoSize = true;
            this.label46.Location = new System.Drawing.Point(14, 245);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(65, 13);
            this.label46.TabIndex = 52;
            this.label46.Text = "School Year";
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label44.Location = new System.Drawing.Point(5, 26);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(122, 13);
            this.label44.TabIndex = 45;
            this.label44.Text = "Account Description";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(5, 89);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 13);
            this.label7.TabIndex = 46;
            this.label7.Text = "Balance";
            // 
            // Cashiering3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.ClientSize = new System.Drawing.Size(586, 455);
            this.Controls.Add(this.schyear);
            this.Controls.Add(this.label46);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
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
            this.Name = "Cashiering3";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Other Fees";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox yearlvl;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox homeroom;
        private System.Windows.Forms.TextBox idnumber;
        private System.Windows.Forms.TextBox name;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox searchbox;
        private System.Windows.Forms.TextBox balance;
        private System.Windows.Forms.TextBox change;
        private System.Windows.Forms.TextBox cashin;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox cr_no;
        private System.Windows.Forms.ComboBox acc_desc;
        private System.Windows.Forms.TextBox schyear;
        private System.Windows.Forms.Label label46;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label44;
    }
}