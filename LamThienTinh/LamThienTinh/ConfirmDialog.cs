using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LamThienTinh
{
    public partial class ConfirmDialog : Form
    {
        private string message;
        public bool confirm = false;

        public ConfirmDialog(string message)
        {
            this.message = message;
            InitializeComponent();
            setControlsInfo();
            this.ShowDialog();
        }

        public void setControlsInfo()
        {
            this.Width = Convert.ToInt32(Screen.PrimaryScreen.Bounds.Width * 0.4);
            this.Height = Convert.ToInt32(Screen.PrimaryScreen.Bounds.Width * 0.2);
            tableLayoutPanel1.Height = Convert.ToInt32(this.Height * 0.2);
        }

        private void ConfirmDialog_Load(object sender, EventArgs e)
        {
            messageContent.Text = message;
        }

        private void messageDialogCloseBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            confirm = true;
            this.Close();
        }
    }
}
