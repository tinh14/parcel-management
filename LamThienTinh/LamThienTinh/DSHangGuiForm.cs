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
    public partial class DSHangGuiForm : Form
    {
        private ChiTietPhieuGuiForm parent;
        public List<HangGui> dsHangGui;
        public DSHangGuiForm(ChiTietPhieuGuiForm parent, List<HangGui> dsHangGui)
        {
            InitializeComponent();
            setControlsInfo();
            setData(parent, dsHangGui);
        }

        public void setControlsInfo()
        {
            this.Width = Convert.ToInt32(Screen.PrimaryScreen.Bounds.Width * 0.8);
            this.Height = Convert.ToInt32(Screen.PrimaryScreen.Bounds.Height * 0.8);

            tableLayoutPanel1.Height = Convert.ToInt32(this.Height * 0.1);
        }

        public void setData(ChiTietPhieuGuiForm parent, List<HangGui> dsHangGui)
        {
            this.parent = parent;
            this.dsHangGui = dsHangGui;
        }

        private void DSHangGui_Load(object sender, EventArgs e)
        {
            dshgDataGridView.Rows.Clear();
            dshgDataGridView.Columns.Clear();
            List<String> PropertiesName = HangGui.getAllProperties();
            for (int i = 0; i < PropertiesName.Count; i++)
            {
                dshgDataGridView.Columns.Add(i.ToString(), PropertiesName[i]);
            }
            dshgDataGridView.Columns[0].ReadOnly = true;
            
            PropertyInfo[] props = typeof(HangGui).GetProperties();
            foreach (HangGui hg in dsHangGui)
            {
                List<String> vals = new List<String>();
                for (int i = 0; i < props.Length; i++)
                {
                    vals.Add(props[i].GetValue(hg, null).ToString());
                }
                dshgDataGridView.Rows.Add(vals.ToArray());
            }
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            dsHangGui = new List<HangGui>();
            int row = dshgDataGridView.RowCount;
            int col = dshgDataGridView.ColumnCount;
            PropertyInfo[] props = typeof(HangGui).GetProperties();

            for (int i = 0; i < row - 1; i++)
            {
                dsHangGui.Add(new HangGui());
                for (int j = 1; j < props.Length; j++)
                {
                    object value = dshgDataGridView.Rows[i].Cells[j].Value;
                    if (value == null)
                    {
                        new MessageDialog("Trường dữ liệu không được rỗng");
                        return;
                    }
                    try
                    {
                        if (props[j].PropertyType.Equals(typeof(int)))
                        {
                            props[j].SetValue(dsHangGui[i], Convert.ToInt32(value), null);
                        }
                        else
                        {
                            props[j].SetValue(dsHangGui[i], Convert.ToString(value), null);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.Write(ex);
                        new MessageDialog("Thông tin nhập không hợp lệ");
                        return;
                    }
                }
            }
            parent.U_HangGui = dsHangGui;
            this.Close();
        }
    }
}
