namespace Billing_Module
{
    partial class BalanceBreakdown2
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.export = new System.Windows.Forms.Button();
            this.select = new System.Windows.Forms.Button();
            this.fileloc = new System.Windows.Forms.TextBox();
            this.sheetname = new System.Windows.Forms.TextBox();
            this.load = new System.Windows.Forms.Button();
            this.save = new System.Windows.Forms.Button();
            this.refresh = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(230)))), ((int)(((byte)(202)))));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 64);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(920, 385);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridView1_KeyDown);
            // 
            // export
            // 
            this.export.Location = new System.Drawing.Point(857, 11);
            this.export.Name = "export";
            this.export.Size = new System.Drawing.Size(75, 23);
            this.export.TabIndex = 2;
            this.export.Text = "Export";
            this.export.UseVisualStyleBackColor = true;
            this.export.Visible = false;
            this.export.Click += new System.EventHandler(this.export_Click);
            // 
            // select
            // 
            this.select.Location = new System.Drawing.Point(12, 12);
            this.select.Name = "select";
            this.select.Size = new System.Drawing.Size(75, 23);
            this.select.TabIndex = 3;
            this.select.Text = "Select File";
            this.select.UseVisualStyleBackColor = true;
            this.select.Visible = false;
            this.select.Click += new System.EventHandler(this.select_Click);
            // 
            // fileloc
            // 
            this.fileloc.Location = new System.Drawing.Point(93, 12);
            this.fileloc.Name = "fileloc";
            this.fileloc.Size = new System.Drawing.Size(262, 20);
            this.fileloc.TabIndex = 4;
            this.fileloc.Visible = false;
            // 
            // sheetname
            // 
            this.sheetname.Location = new System.Drawing.Point(93, 40);
            this.sheetname.Margin = new System.Windows.Forms.Padding(2);
            this.sheetname.Name = "sheetname";
            this.sheetname.Size = new System.Drawing.Size(262, 20);
            this.sheetname.TabIndex = 5;
            this.sheetname.Text = "Sheet1";
            this.sheetname.Visible = false;
            // 
            // load
            // 
            this.load.Location = new System.Drawing.Point(12, 40);
            this.load.Margin = new System.Windows.Forms.Padding(2);
            this.load.Name = "load";
            this.load.Size = new System.Drawing.Size(75, 19);
            this.load.TabIndex = 6;
            this.load.Text = "load";
            this.load.UseVisualStyleBackColor = true;
            this.load.Visible = false;
            this.load.Click += new System.EventHandler(this.load_Click);
            // 
            // save
            // 
            this.save.Location = new System.Drawing.Point(380, 12);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(75, 23);
            this.save.TabIndex = 7;
            this.save.Text = "Save";
            this.save.UseVisualStyleBackColor = true;
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // refresh
            // 
            this.refresh.Location = new System.Drawing.Point(461, 12);
            this.refresh.Name = "refresh";
            this.refresh.Size = new System.Drawing.Size(75, 23);
            this.refresh.TabIndex = 8;
            this.refresh.Text = "Refresh";
            this.refresh.UseVisualStyleBackColor = true;
            this.refresh.Click += new System.EventHandler(this.refresh_Click);
            // 
            // BalanceBreakdown2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.ClientSize = new System.Drawing.Size(944, 461);
            this.Controls.Add(this.refresh);
            this.Controls.Add(this.save);
            this.Controls.Add(this.load);
            this.Controls.Add(this.sheetname);
            this.Controls.Add(this.fileloc);
            this.Controls.Add(this.select);
            this.Controls.Add(this.export);
            this.Controls.Add(this.dataGridView1);
            this.Name = "BalanceBreakdown2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Balance Breakdown";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button export;
        private System.Windows.Forms.Button select;
        private System.Windows.Forms.TextBox fileloc;
        private System.Windows.Forms.TextBox sheetname;
        private System.Windows.Forms.Button load;
        private System.Windows.Forms.Button save;
        private System.Windows.Forms.Button refresh;

    }
}