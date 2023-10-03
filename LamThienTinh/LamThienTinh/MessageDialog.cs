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
    public partial class MessageDialog : Form
    {
        private string message;
        public MessageDialog(string message)
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

        private void MessageDialog_Load(object sender, EventArgs e)
        {
            messageContent.Text = message;
        }

        private void messageDialogCloseBtn_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
