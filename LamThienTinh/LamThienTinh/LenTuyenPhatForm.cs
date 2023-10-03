using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DAL;
using DTO;

namespace LamThienTinh
{
    public partial class LenTuyenPhatForm : Form
    {
        private List<NhanVien> dsNhanVien;
        private int SHBuuCuc;

        private int currentIndex;
        private int currentBuuGuiIndex;

        public LenTuyenPhatForm(int SHBuuCuc)
        {
            InitializeComponent();
            setData(SHBuuCuc);
            setControlsInfo();
            setTableHeaders();
            loadData();
            renderNhanVienTable();
        }

        private void setControlsInfo()
        {
            this.Width = Convert.ToInt32(Screen.PrimaryScreen.Bounds.Width * 0.9);
            this.Height = Convert.ToInt32(Screen.PrimaryScreen.Bounds.Height * 0.9);

            tableLayoutPanel1.Height = Convert.ToInt32(this.Height * 0.1);
        }

        private void setData(int SHBuuCuc)
        {
            this.SHBuuCuc = SHBuuCuc;
        }

        private void setTableHeaders()
        {
            List<string> props = NhanVien.getAllProperties();
            foreach (string prop in props)
            {
                dsNhanVienDataGridView.Columns.Add("", prop);
            }
            dsBuuGuiDataGridView.Columns.Add("", "Số Hiệu");

            foreach (DataGridViewColumn column in dsNhanVienDataGridView.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            foreach (DataGridViewColumn column in dsBuuGuiDataGridView.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private void loadData()
        {
            dsNhanVien = NhanVienVanChuyenDAL.getAllNhanVienVanChuyen(SHBuuCuc);
        }

        private void renderNhanVienTable() {
            if (dsNhanVien == null)
            {
                currentIndex = -1;
                return;
            }
            foreach (NhanVien nv in dsNhanVien)
            {
                dsNhanVienDataGridView.Rows.Add(new object[] {nv.SH,nv.Ten, nv.Ho, nv.DiaChi, nv.Email, nv.SDT, nv.NgaySinh.ToString("dd/MM/yyyy")});
            }
            currentIndex = 0;
            dsNhanVienDataGridView.Rows[currentIndex].Cells[0].Selected = true;
            renderBuuGuiTable();
        }

        private void renderBuuGuiTable()
        {
            dsBuuGuiDataGridView.Rows.Clear();
            if (dsNhanVien == null || dsNhanVien[currentIndex].dsPhieuGui == null)
            {
                return;
            }
            foreach (PhieuGui pg in dsNhanVien[currentIndex].dsPhieuGui)
            {
                dsBuuGuiDataGridView.Rows.Add(new object[]{pg.SH});
            }
            currentBuuGuiIndex = 0;
            dsBuuGuiDataGridView.Rows[currentBuuGuiIndex].Cells[0].Selected = true;
        }

        private void messageDialogCloseBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chonBuuGuiBtn_Click(object sender, EventArgs e)
        {
            if (dsNhanVien[currentIndex].dsPhieuGui == null)
            {
                dsNhanVien[currentIndex].dsPhieuGui = new List<PhieuGui>();
            }
            var form = new ChonItemsForm(SHBuuCuc, dsNhanVien[currentIndex].dsPhieuGui, this);
            loadData();
            renderNhanVienTable();
        }

        private void chonTbx_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F4)
            {
                // Không thể bỏ bưu gửi vào túi đã đóng được :))
                // Vì túi đã đóng có số hiệu nên chỉ việc kiểm tra số hiệu của túi
                if (dsNhanVien == null || dsNhanVien[currentIndex].dsPhieuGui != null)
                {
                    return;
                }

                dsNhanVien[currentIndex].dsPhieuGui = new List<PhieuGui>();

                // Dùng tham chiếu để nhận các bưu gửi từ chonPhieuGuiForm
                var chonPhieuGuiForm = new ChonItemsForm(SHBuuCuc, dsNhanVien[currentIndex].dsPhieuGui, this);
                if (dsNhanVien[currentIndex].dsPhieuGui.Count == 0)
                {
                    dsNhanVien[currentIndex].dsPhieuGui = null;
                    return;
                }
                NhanVienVanChuyenDAL.lenTuyenPhat(SHBuuCuc, dsNhanVien[currentIndex]);
                loadData();
                renderBuuGuiTable();
            }                                                                                                                                                                   
        }

        private void dsNhanVienDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }
            currentIndex = e.RowIndex;
            dsNhanVienDataGridView.Rows[currentIndex].Cells[0].Selected = true;
            renderBuuGuiTable();
        }

        private void dsBuuGuiDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }
            currentBuuGuiIndex = e.RowIndex;
            dsBuuGuiDataGridView.Rows[currentBuuGuiIndex].Cells[0].Selected = true;
        }

        private void xoaBuuGuiBtn_Click(object sender, EventArgs e)
        {
            if (dsNhanVien == null || dsNhanVien[currentIndex].dsPhieuGui == null)
            {
                return;
            }
            ConfirmDialog cf = new ConfirmDialog("Xác nhận xóa");
            if (cf.confirm)
            {
                NhanVienVanChuyenDAL.xoaBuuGui(SHBuuCuc, dsNhanVien[currentIndex].dsPhieuGui[currentBuuGuiIndex].SH);
                loadData();
                renderBuuGuiTable();
                new MessageDialog("Xóa thành công");
            }
        }
    }
}
