namespace Billing_Module
{
    partial class classlist
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
            this.label4 = new System.Windows.Forms.Label();
            this.adviser = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.schoolyear = new System.Windows.Forms.TextBox();
            this.print = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.homeroom = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.yearlvl = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(441, 62);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 20);
            this.label4.TabIndex = 19;
            this.label4.Text = "Adviser";
            // 
            // adviser
            // 
            this.adviser.Location = new System.Drawing.Point(523, 58);
            this.adviser.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.adviser.Name = "adviser";
            this.adviser.ReadOnly = true;
            this.adviser.Size = new System.Drawing.Size(215, 22);
            this.adviser.TabIndex = 18;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(441, 18);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 20);
            this.label3.TabIndex = 17;
            this.label3.Text = "School Year";
            // 
            // schoolyear
            // 
            this.schoolyear.Location = new System.Drawing.Point(579, 15);
            this.schoolyear.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.schoolyear.Name = "schoolyear";
            this.schoolyear.Size = new System.Drawing.Size(159, 22);
            this.schoolyear.TabIndex = 16;
            this.schoolyear.Text = "2019";
            // 
            // print
            // 
            this.print.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.print.Location = new System.Drawing.Point(792, 15);
            this.print.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.print.Name = "print";
            this.print.Size = new System.Drawing.Size(83, 68);
            this.print.TabIndex = 15;
            this.print.Text = "Print";
            this.print.UseVisualStyleBackColor = true;
            this.print.Click += new System.EventHandler(this.print_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column2,
            this.Column3});
            this.dataGridView1.Location = new System.Drawing.Point(20, 110);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(855, 570);
            this.dataGridView1.TabIndex = 14;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "ID Number";
            this.Column2.HeaderText = "ID Number";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column3.DataPropertyName = "Student Name";
            this.Column3.HeaderText = "Student Name";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(20, 64);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 20);
            this.label2.TabIndex = 13;
            this.label2.Text = "Homeroom";
            // 
            // homeroom
            // 
            this.homeroom.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.homeroom.FormattingEnabled = true;
            this.homeroom.Location = new System.Drawing.Point(145, 55);
            this.homeroom.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.homeroom.Name = "homeroom";
            this.homeroom.Size = new System.Drawing.Size(240, 28);
            this.homeroom.Sorted = true;
            this.homeroom.TabIndex = 12;
            this.homeroom.SelectedIndexChanged += new System.EventHandler(this.homeroom_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(20, 18);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 20);
            this.label1.TabIndex = 11;
            this.label1.Text = "Year Level";
            // 
            // yearlvl
            // 
            this.yearlvl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.yearlvl.FormattingEnabled = true;
            this.yearlvl.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.yearlvl.Location = new System.Drawing.Point(145, 15);
            this.yearlvl.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.yearlvl.Name = "yearlvl";
            this.yearlvl.Size = new System.Drawing.Size(160, 28);
            this.yearlvl.TabIndex = 10;
            this.yearlvl.SelectedIndexChanged += new System.EventHandler(this.yearlvl_SelectedIndexChanged);
            // 
            // classlist
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.ClientSize = new System.Drawing.Size(891, 687);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.adviser);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.schoolyear);
            this.Controls.Add(this.print);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.homeroom);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.yearlvl);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "classlist";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Class List";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox adviser;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox schoolyear;
        private System.Windows.Forms.Button print;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox homeroom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox yearlvl;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
    }
}