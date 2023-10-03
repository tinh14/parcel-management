namespace LamThienTinh
{
    partial class ChonItemsForm
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
            this.tablePanel = new System.Windows.Forms.TableLayoutPanel();
            this.closeBtn = new System.Windows.Forms.Button();
            this.dsItemsDataGridView = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tablePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dsItemsDataGridView)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tablePanel
            // 
            this.tablePanel.ColumnCount = 5;
            this.tablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tablePanel.Controls.Add(this.closeBtn, 2, 1);
            this.tablePanel.Controls.Add(this.dsItemsDataGridView, 0, 0);
            this.tablePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tablePanel.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tablePanel.Location = new System.Drawing.Point(0, 0);
            this.tablePanel.Name = "tablePanel";
            this.tablePanel.RowCount = 2;
            this.tablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.tablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tablePanel.Size = new System.Drawing.Size(617, 412);
            this.tablePanel.TabIndex = 0;
            // 
            // closeBtn
            // 
            this.closeBtn.BackColor = System.Drawing.Color.White;
            this.closeBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.closeBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.closeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeBtn.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closeBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.closeBtn.Location = new System.Drawing.Point(249, 373);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(117, 36);
            this.closeBtn.TabIndex = 39;
            this.closeBtn.Text = "THOÁT";
            this.closeBtn.UseVisualStyleBackColor = false;
            this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);
            // 
            // dsItemsDataGridView
            // 
            this.dsItemsDataGridView.AllowUserToAddRows = false;
            this.dsItemsDataGridView.AllowUserToDeleteRows = false;
            this.dsItemsDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dsItemsDataGridView.BackgroundColor = System.Drawing.Color.White;
            this.dsItemsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tablePanel.SetColumnSpan(this.dsItemsDataGridView, 5);
            this.dsItemsDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dsItemsDataGridView.GridColor = System.Drawing.Color.Black;
            this.dsItemsDataGridView.Location = new System.Drawing.Point(3, 3);
            this.dsItemsDataGridView.Name = "dsItemsDataGridView";
            this.dsItemsDataGridView.Size = new System.Drawing.Size(611, 364);
            this.dsItemsDataGridView.TabIndex = 40;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.tablePanel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(619, 414);
            this.panel1.TabIndex = 1;
            // 
            // ChonItemsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(619, 414);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ChonItemsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DSChonPhieuGui";
            this.tablePanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dsItemsDataGridView)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tablePanel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button closeBtn;
        private System.Windows.Forms.DataGridView dsItemsDataGridView;
    }
}