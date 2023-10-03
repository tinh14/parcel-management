namespace LamThienTinh
{
    partial class DSKhachHangForm
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
            this.dsKhachHangPanel = new System.Windows.Forms.Panel();
            this.closeBtn = new System.Windows.Forms.Button();
            this.chooseBtn = new System.Windows.Forms.Button();
            this.dskhDataGridView = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dsKhachHangPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dskhDataGridView)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dsKhachHangPanel
            // 
            this.dsKhachHangPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dsKhachHangPanel.Controls.Add(this.dskhDataGridView);
            this.dsKhachHangPanel.Controls.Add(this.tableLayoutPanel1);
            this.dsKhachHangPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dsKhachHangPanel.Location = new System.Drawing.Point(0, 0);
            this.dsKhachHangPanel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dsKhachHangPanel.Name = "dsKhachHangPanel";
            this.dsKhachHangPanel.Size = new System.Drawing.Size(944, 626);
            this.dsKhachHangPanel.TabIndex = 0;
            // 
            // closeBtn
            // 
            this.closeBtn.BackColor = System.Drawing.Color.White;
            this.closeBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.closeBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.closeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeBtn.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closeBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.closeBtn.Location = new System.Drawing.Point(568, 4);
            this.closeBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(180, 63);
            this.closeBtn.TabIndex = 1;
            this.closeBtn.Text = "THOÁT";
            this.closeBtn.UseVisualStyleBackColor = false;
            this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);
            // 
            // chooseBtn
            // 
            this.chooseBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.chooseBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chooseBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chooseBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chooseBtn.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chooseBtn.ForeColor = System.Drawing.Color.White;
            this.chooseBtn.Location = new System.Drawing.Point(192, 4);
            this.chooseBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chooseBtn.Name = "chooseBtn";
            this.chooseBtn.Size = new System.Drawing.Size(180, 63);
            this.chooseBtn.TabIndex = 0;
            this.chooseBtn.Text = "CHỌN";
            this.chooseBtn.UseVisualStyleBackColor = false;
            this.chooseBtn.Click += new System.EventHandler(this.chooseBtn_Click);
            // 
            // dskhDataGridView
            // 
            this.dskhDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dskhDataGridView.BackgroundColor = System.Drawing.Color.White;
            this.dskhDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dskhDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dskhDataGridView.Location = new System.Drawing.Point(0, 0);
            this.dskhDataGridView.Margin = new System.Windows.Forms.Padding(4);
            this.dskhDataGridView.MultiSelect = false;
            this.dskhDataGridView.Name = "dskhDataGridView";
            this.dskhDataGridView.ReadOnly = true;
            this.dskhDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dskhDataGridView.Size = new System.Drawing.Size(942, 553);
            this.dskhDataGridView.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Controls.Add(this.chooseBtn, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.closeBtn, 3, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 553);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(942, 71);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // DSKhachHangForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(944, 626);
            this.Controls.Add(this.dsKhachHangPanel);
            this.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "DSKhachHangForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DSKhachHangForm";
            this.Load += new System.EventHandler(this.DSKhachHangForm_Load);
            this.dsKhachHangPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dskhDataGridView)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel dsKhachHangPanel;
        private System.Windows.Forms.Button closeBtn;
        private System.Windows.Forms.Button chooseBtn;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView dskhDataGridView;
    }
}