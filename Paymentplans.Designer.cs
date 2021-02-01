namespace Billing_Module
{
    partial class Paymentplans
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Paymentplans));
            this.edit = new System.Windows.Forms.Button();
            this.Save = new System.Windows.Forms.Button();
            this.ftotal = new System.Windows.Forms.TextBox();
            this.monthlybalance = new System.Windows.Forms.TextBox();
            this.midyearbalance = new System.Windows.Forms.TextBox();
            this.enrollbalance = new System.Windows.Forms.TextBox();
            this.discount = new System.Windows.Forms.TextBox();
            this.total1 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.yearlevel = new System.Windows.Forms.ComboBox();
            this.plantype = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.savenew = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // edit
            // 
            this.edit.Location = new System.Drawing.Point(20, 275);
            this.edit.Name = "edit";
            this.edit.Size = new System.Drawing.Size(75, 23);
            this.edit.TabIndex = 42;
            this.edit.Text = "Edit";
            this.edit.UseVisualStyleBackColor = true;
            this.edit.Click += new System.EventHandler(this.edit_Click);
            // 
            // Save
            // 
            this.Save.Location = new System.Drawing.Point(240, 275);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(75, 23);
            this.Save.TabIndex = 41;
            this.Save.Text = "Save";
            this.Save.UseVisualStyleBackColor = true;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // ftotal
            // 
            this.ftotal.Location = new System.Drawing.Point(200, 220);
            this.ftotal.Name = "ftotal";
            this.ftotal.ReadOnly = true;
            this.ftotal.Size = new System.Drawing.Size(100, 20);
            this.ftotal.TabIndex = 7;
            // 
            // monthlybalance
            // 
            this.monthlybalance.Location = new System.Drawing.Point(200, 193);
            this.monthlybalance.Name = "monthlybalance";
            this.monthlybalance.ReadOnly = true;
            this.monthlybalance.Size = new System.Drawing.Size(100, 20);
            this.monthlybalance.TabIndex = 6;
            // 
            // midyearbalance
            // 
            this.midyearbalance.Location = new System.Drawing.Point(200, 163);
            this.midyearbalance.Name = "midyearbalance";
            this.midyearbalance.ReadOnly = true;
            this.midyearbalance.Size = new System.Drawing.Size(100, 20);
            this.midyearbalance.TabIndex = 5;
            // 
            // enrollbalance
            // 
            this.enrollbalance.Location = new System.Drawing.Point(200, 136);
            this.enrollbalance.Name = "enrollbalance";
            this.enrollbalance.ReadOnly = true;
            this.enrollbalance.Size = new System.Drawing.Size(100, 20);
            this.enrollbalance.TabIndex = 4;
            // 
            // discount
            // 
            this.discount.Location = new System.Drawing.Point(200, 109);
            this.discount.Name = "discount";
            this.discount.ReadOnly = true;
            this.discount.Size = new System.Drawing.Size(100, 20);
            this.discount.TabIndex = 3;
            // 
            // total1
            // 
            this.total1.Location = new System.Drawing.Point(200, 83);
            this.total1.Name = "total1";
            this.total1.ReadOnly = true;
            this.total1.Size = new System.Drawing.Size(100, 20);
            this.total1.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(25, 223);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 16);
            this.label6.TabIndex = 34;
            this.label6.Text = "Total Fee";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(25, 196);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 16);
            this.label5.TabIndex = 33;
            this.label5.Text = "Monthly Fee";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(25, 166);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 16);
            this.label4.TabIndex = 32;
            this.label4.Text = "Mid-Year Fee";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(25, 139);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 16);
            this.label3.TabIndex = 31;
            this.label3.Text = "Enrollment Fee";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(25, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(154, 16);
            this.label2.TabIndex = 30;
            this.label2.Text = "Tuition Discount Amount:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(25, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(170, 16);
            this.label1.TabIndex = 29;
            this.label1.Text = "Total Tuition and other fees";
            // 
            // yearlevel
            // 
            this.yearlevel.FormattingEnabled = true;
            this.yearlevel.Items.AddRange(new object[] {
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
            this.yearlevel.Location = new System.Drawing.Point(20, 43);
            this.yearlevel.Name = "yearlevel";
            this.yearlevel.Size = new System.Drawing.Size(121, 21);
            this.yearlevel.TabIndex = 0;
            this.yearlevel.SelectedIndexChanged += new System.EventHandler(this.yearlevel_SelectedIndexChanged);
            // 
            // plantype
            // 
            this.plantype.FormattingEnabled = true;
            this.plantype.Items.AddRange(new object[] {
            "A",
            "B",
            "C"});
            this.plantype.Location = new System.Drawing.Point(194, 43);
            this.plantype.Name = "plantype";
            this.plantype.Size = new System.Drawing.Size(121, 21);
            this.plantype.TabIndex = 1;
            this.plantype.SelectedIndexChanged += new System.EventHandler(this.plantype_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(35, 24);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(92, 13);
            this.label7.TabIndex = 45;
            this.label7.Text = "Grade/Year Level";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(206, 23);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(99, 13);
            this.label8.TabIndex = 46;
            this.label8.Text = "Payment Plan Type";
            // 
            // savenew
            // 
            this.savenew.Location = new System.Drawing.Point(132, 275);
            this.savenew.Name = "savenew";
            this.savenew.Size = new System.Drawing.Size(75, 23);
            this.savenew.TabIndex = 8;
            this.savenew.Text = "Save New";
            this.savenew.UseVisualStyleBackColor = true;
            this.savenew.Click += new System.EventHandler(this.savenew_Click);
            // 
            // Paymentplans
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.ClientSize = new System.Drawing.Size(344, 321);
            this.Controls.Add(this.savenew);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.plantype);
            this.Controls.Add(this.yearlevel);
            this.Controls.Add(this.edit);
            this.Controls.Add(this.Save);
            this.Controls.Add(this.ftotal);
            this.Controls.Add(this.monthlybalance);
            this.Controls.Add(this.midyearbalance);
            this.Controls.Add(this.enrollbalance);
            this.Controls.Add(this.discount);
            this.Controls.Add(this.total1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Paymentplans";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Paymentplans";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button edit;
        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.TextBox ftotal;
        private System.Windows.Forms.TextBox monthlybalance;
        private System.Windows.Forms.TextBox midyearbalance;
        private System.Windows.Forms.TextBox enrollbalance;
        private System.Windows.Forms.TextBox discount;
        private System.Windows.Forms.TextBox total1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox yearlevel;
        private System.Windows.Forms.ComboBox plantype;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button savenew;
    }
}