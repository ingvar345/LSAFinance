namespace Billing_Module
{
    partial class StatementofAccount
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StatementofAccount));
            this.name = new System.Windows.Forms.TextBox();
            this.idnumber = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.searchbox = new System.Windows.Forms.TextBox();
            this.label44 = new System.Windows.Forms.Label();
            this.totalbill = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.total1 = new System.Windows.Forms.TextBox();
            this.prevacc = new System.Windows.Forms.TextBox();
            this.other_charges = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.others_less = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.scholar_less = new System.Windows.Forms.TextBox();
            this.tuition_less = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.print = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // name
            // 
            this.name.Location = new System.Drawing.Point(443, 13);
            this.name.Margin = new System.Windows.Forms.Padding(4);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(339, 22);
            this.name.TabIndex = 47;
            // 
            // idnumber
            // 
            this.idnumber.Location = new System.Drawing.Point(349, 13);
            this.idnumber.Margin = new System.Windows.Forms.Padding(4);
            this.idnumber.Name = "idnumber";
            this.idnumber.Size = new System.Drawing.Size(84, 22);
            this.idnumber.TabIndex = 46;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 46);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(771, 170);
            this.dataGridView1.TabIndex = 45;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridView1_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 16);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(155, 17);
            this.label1.TabIndex = 44;
            this.label1.Text = "ID Number / Last Name";
            // 
            // searchbox
            // 
            this.searchbox.Location = new System.Drawing.Point(175, 14);
            this.searchbox.Margin = new System.Windows.Forms.Padding(4);
            this.searchbox.Name = "searchbox";
            this.searchbox.Size = new System.Drawing.Size(145, 22);
            this.searchbox.TabIndex = 43;
            this.searchbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.searchbox_KeyDown);
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label44.Location = new System.Drawing.Point(13, 327);
            this.label44.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(108, 17);
            this.label44.TabIndex = 53;
            this.label44.Text = "Total Balance";
            // 
            // totalbill
            // 
            this.totalbill.Location = new System.Drawing.Point(199, 322);
            this.totalbill.Margin = new System.Windows.Forms.Padding(4);
            this.totalbill.Name = "totalbill";
            this.totalbill.ReadOnly = true;
            this.totalbill.Size = new System.Drawing.Size(125, 22);
            this.totalbill.TabIndex = 52;
            this.totalbill.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(13, 237);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(114, 17);
            this.label8.TabIndex = 51;
            this.label8.Text = "Tuition and Fees";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 265);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(118, 17);
            this.label7.TabIndex = 50;
            this.label7.Text = "Previous Account";
            // 
            // total1
            // 
            this.total1.Location = new System.Drawing.Point(199, 232);
            this.total1.Margin = new System.Windows.Forms.Padding(4);
            this.total1.Name = "total1";
            this.total1.ReadOnly = true;
            this.total1.Size = new System.Drawing.Size(125, 22);
            this.total1.TabIndex = 49;
            this.total1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // prevacc
            // 
            this.prevacc.Location = new System.Drawing.Point(199, 262);
            this.prevacc.Margin = new System.Windows.Forms.Padding(4);
            this.prevacc.Name = "prevacc";
            this.prevacc.ReadOnly = true;
            this.prevacc.Size = new System.Drawing.Size(125, 22);
            this.prevacc.TabIndex = 48;
            this.prevacc.Text = "0";
            this.prevacc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // other_charges
            // 
            this.other_charges.Location = new System.Drawing.Point(199, 292);
            this.other_charges.Margin = new System.Windows.Forms.Padding(4);
            this.other_charges.Name = "other_charges";
            this.other_charges.ReadOnly = true;
            this.other_charges.Size = new System.Drawing.Size(125, 22);
            this.other_charges.TabIndex = 54;
            this.other_charges.Text = "0";
            this.other_charges.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 297);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 17);
            this.label2.TabIndex = 55;
            this.label2.Text = "Other Charges";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(471, 297);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 17);
            this.label3.TabIndex = 63;
            this.label3.Text = "Other Payments";
            // 
            // others_less
            // 
            this.others_less.Location = new System.Drawing.Point(657, 292);
            this.others_less.Margin = new System.Windows.Forms.Padding(4);
            this.others_less.Name = "others_less";
            this.others_less.ReadOnly = true;
            this.others_less.Size = new System.Drawing.Size(125, 22);
            this.others_less.TabIndex = 62;
            this.others_less.Text = "0";
            this.others_less.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(471, 267);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(122, 17);
            this.label5.TabIndex = 59;
            this.label5.Text = "Scholar/Discounts";
            // 
            // scholar_less
            // 
            this.scholar_less.Location = new System.Drawing.Point(657, 262);
            this.scholar_less.Margin = new System.Windows.Forms.Padding(4);
            this.scholar_less.Name = "scholar_less";
            this.scholar_less.ReadOnly = true;
            this.scholar_less.Size = new System.Drawing.Size(125, 22);
            this.scholar_less.TabIndex = 57;
            this.scholar_less.Text = "0";
            this.scholar_less.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tuition_less
            // 
            this.tuition_less.Location = new System.Drawing.Point(657, 232);
            this.tuition_less.Margin = new System.Windows.Forms.Padding(4);
            this.tuition_less.Name = "tuition_less";
            this.tuition_less.ReadOnly = true;
            this.tuition_less.Size = new System.Drawing.Size(125, 22);
            this.tuition_less.TabIndex = 56;
            this.tuition_less.Text = "0";
            this.tuition_less.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(471, 235);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(117, 17);
            this.label6.TabIndex = 58;
            this.label6.Text = "Tuition Payments";
            // 
            // print
            // 
            this.print.BackColor = System.Drawing.Color.Gold;
            this.print.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.print.Location = new System.Drawing.Point(195, 412);
            this.print.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.print.Name = "print";
            this.print.Size = new System.Drawing.Size(407, 85);
            this.print.TabIndex = 64;
            this.print.Text = "Print";
            this.print.UseVisualStyleBackColor = false;
            this.print.Click += new System.EventHandler(this.print_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(471, 331);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 17);
            this.label4.TabIndex = 65;
            this.label4.Text = "Due Date";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(563, 327);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(219, 22);
            this.dateTimePicker1.TabIndex = 66;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(471, 362);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(100, 17);
            this.label9.TabIndex = 67;
            this.label9.Text = "Balance Due";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(657, 356);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(125, 22);
            this.textBox1.TabIndex = 68;
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            // 
            // StatementofAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.ClientSize = new System.Drawing.Size(796, 508);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.print);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.others_less);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.scholar_less);
            this.Controls.Add(this.tuition_less);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.other_charges);
            this.Controls.Add(this.label44);
            this.Controls.Add(this.totalbill);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.total1);
            this.Controls.Add(this.prevacc);
            this.Controls.Add(this.name);
            this.Controls.Add(this.idnumber);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.searchbox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "StatementofAccount";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " Statement of Accounts";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox name;
        private System.Windows.Forms.TextBox idnumber;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox searchbox;
        private System.Windows.Forms.Label label44;
        private System.Windows.Forms.TextBox totalbill;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox total1;
        private System.Windows.Forms.TextBox prevacc;
        private System.Windows.Forms.TextBox other_charges;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox others_less;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox scholar_less;
        private System.Windows.Forms.TextBox tuition_less;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button print;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBox1;

    }
}