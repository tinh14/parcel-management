using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using DAL;
using DTO;

namespace LamThienTinh
{
    public partial class DSKhachHangForm : Form
    {
        private ChiTietPhieuGuiForm parent;
        private int mode;

        public List<KhachHang> dsKhachHang;
        public DSKhachHangForm(ChiTietPhieuGuiForm parent, int mode)
        {
            InitializeComponent();

            setControlsInfo();
            setData(parent, mode);
        }

        public void setControlsInfo()
        {
            this.Width = Convert.ToInt32(Screen.PrimaryScreen.Bounds.Width * 0.8);
            this.Height = Convert.ToInt32(Screen.PrimaryScreen.Bounds.Height * 0.8);

            tableLayoutPanel1.Height = Convert.ToInt32(this.Height * 0.1);
        }

        public void setData(ChiTietPhieuGuiForm parent, int mode)
        {
            this.parent = parent;
            this.mode = mode;
            this.dsKhachHang = NhanVienGiaoDichDAL.getAllKhachHang();
        }

        private void DSKhachHangForm_Load(object sender, EventArgs e)
        {
            List<String> PropertiesName = KhachHang.getAllProperties();
            foreach (String name in PropertiesName)
            {
                dskhDataGridView.Columns.Add("", name);
            }
            PropertyInfo[] props = typeof(KhachHang).GetProperties();
            foreach (KhachHang kh in dsKhachHang)
            {
                List<String> vals = new List<String>();
                for (int i = 0; i < props.Length; i++)
                {
                    vals.Add(props[i].GetValue(kh, null).ToString());
                }
                dskhDataGridView.Rows.Add(vals.ToArray());
            }

            foreach (DataGridViewColumn column in dskhDataGridView.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {   
            this.Close();
        }

        private void chooseBtn_Click(object sender, EventArgs e)
        {
            int index = dskhDataGridView.CurrentCell.RowIndex;
            if (index == dsKhachHang.Count)
            {
                return;
            }
            if (mode == 1)
            {
                parent.khachHangGui = dsKhachHang[index];
            }
            else
            {
                parent.khachHangNhan = dsKhachHang[index];
            }
            this.Close();
        }
    }
}
